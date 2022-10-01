namespace Singleton
{
    public class Sound
    {
        static Sound sound;

        protected Sound() { }

        public static Sound Instance => sound is null ? new Sound() : sound;
    }
}
