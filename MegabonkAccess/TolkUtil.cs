using System.Runtime.InteropServices;
using DavyKager;

#pragma warning disable CA1416 // Platform compatibility

namespace MegabonkAccess
{
    public static class TolkUtil
    {
        // Coordination system: when specialized patches speak, they set this timestamp
        // Generic patches check this and skip if a specialized patch recently spoke
        private static float lastSpecializedSpeakTime = 0f;
        private const float SPECIALIZED_BLOCK_DURATION = 0.5f; // Block generic patches for 0.5s

        // Delayed speech system - allows UI to update before reading
        private static string pendingDelayedSpeech = null;
        private static float delayedSpeechTime = 0f;
        private const float DEFAULT_SPEECH_DELAY = 0.15f; // 150ms delay for UI to update

        // Delayed action system - for when we need to delay the entire reading process
        private static System.Action pendingAction = null;
        private static float pendingActionTime = 0f;

        public static void Load()
        {
            Tolk.Load();
        }

        /// <summary>
        /// Called by specialized patches (Shop, Unlock, Character) to speak with priority
        /// </summary>
        public static void SpeakFromSpecializedPatch(string text)
        {
            lastSpecializedSpeakTime = UnityEngine.Time.unscaledTime;
            Tolk.Silence();
            Tolk.Speak(text);
        }

        /// <summary>
        /// Schedule speech with a delay to allow UI to update first.
        /// Used by patches where the UI updates after the method call.
        /// </summary>
        public static void SpeakFromSpecializedPatchDelayed(string text, float delay = DEFAULT_SPEECH_DELAY)
        {
            // Mark as specialized immediately to block generic patches
            lastSpecializedSpeakTime = UnityEngine.Time.unscaledTime;

            // Schedule the actual speech for later
            pendingDelayedSpeech = text;
            delayedSpeechTime = UnityEngine.Time.unscaledTime + delay;
        }

        /// <summary>
        /// Schedule an action to run after a delay. Used when we need to delay reading UI text.
        /// </summary>
        public static void ScheduleDelayedAction(System.Action action, float delay = DEFAULT_SPEECH_DELAY)
        {
            // Mark as specialized immediately to block generic patches
            lastSpecializedSpeakTime = UnityEngine.Time.unscaledTime;

            pendingAction = action;
            pendingActionTime = UnityEngine.Time.unscaledTime + delay;
        }

        /// <summary>
        /// Process any pending delayed speech or actions. Called from DirectionalAudioManager.Update()
        /// </summary>
        public static void ProcessDelayedSpeech()
        {
            // Process pending delayed speech
            if (pendingDelayedSpeech != null && UnityEngine.Time.unscaledTime >= delayedSpeechTime)
            {
                string textToSpeak = pendingDelayedSpeech;
                pendingDelayedSpeech = null;

                // Update specialized time again when actually speaking
                lastSpecializedSpeakTime = UnityEngine.Time.unscaledTime;
                Tolk.Silence();
                Tolk.Speak(textToSpeak);
            }

            // Process pending delayed action
            if (pendingAction != null && UnityEngine.Time.unscaledTime >= pendingActionTime)
            {
                var actionToRun = pendingAction;
                pendingAction = null;

                try
                {
                    actionToRun();
                }
                catch (System.Exception e)
                {
                    Plugin.Log.LogError($"Delayed action error: {e.Message}");
                }
            }
        }

        /// <summary>
        /// Check if a specialized patch recently spoke (used by generic patches to skip)
        /// </summary>
        public static bool ShouldSkipGenericPatch()
        {
            float timeSinceSpecialized = UnityEngine.Time.unscaledTime - lastSpecializedSpeakTime;
            return timeSinceSpecialized < SPECIALIZED_BLOCK_DURATION;
        }

        public static void Speak(string text, bool interrupt = true)
        {
            if (interrupt)
            {
                Tolk.Silence();
            }
            Tolk.Speak(text);
        }

        public static void Silence()
        {
            Tolk.Silence();
        }

        public static void Beep()
        {
            try
            {
                // Use system beep - simple and reliable on Windows
                System.Console.Beep(800, 100); // 800Hz frequency, 100ms duration
            }
            catch
            {
                // Fallback to Tolk if console beep fails
                Tolk.Output("\a", false);
            }
        }

        public static void Beep(int frequency, int durationMs)
        {
            try
            {
                // Clamp frequency to valid range (37-32767 Hz)
                frequency = System.Math.Max(37, System.Math.Min(32767, frequency));
                // Clamp duration to reasonable range
                durationMs = System.Math.Max(10, System.Math.Min(1000, durationMs));

                System.Console.Beep(frequency, durationMs);
            }
            catch
            {
                // Silent fallback - don't crash the game
            }
        }
    }
}
