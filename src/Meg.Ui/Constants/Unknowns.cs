namespace Meg.Ui.Constants
{
    public static class Unknowns
    {
        public const string X = "x";
        public const string Y = "y";
        public const string Z = "z";

        private static string[] all = { X, Y, Z };

        public static string[] All { get => all; set => all = value; }
    }
}
