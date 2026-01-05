using System.Runtime.InteropServices;
using DavyKager;

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
    }
}
