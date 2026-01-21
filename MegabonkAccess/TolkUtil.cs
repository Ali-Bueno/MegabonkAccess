using System.Runtime.InteropServices;
using DavyKager;

#pragma warning disable CA1416 // Platform compatibility

namespace MegabonkAccess
{
    public static class TolkUtil
    {
        public static void Load()
        {
            Tolk.Load();
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
