namespace Ritmo.Core
{
    public static class SceneNames
    {
        public const string Bootstrap = "00_Bootstrap";
        public const string Profile = "01_Profile";
        public const string Training = "02_Training";
        public const string Gameplay = "03_Gameplay";
        public const string SessionEnd = "04_SessionEnd";

        public static readonly string[] AllOrdered =
        {
            Bootstrap,
            Profile,
            Training,
            Gameplay,
            SessionEnd
        };
    }
}
