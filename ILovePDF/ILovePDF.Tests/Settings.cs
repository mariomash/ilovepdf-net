using System;
using System.IO;

namespace ILovePDF.Tests
{
    /// <summary>
    /// ILovePDF Test settings
    /// </summary>
    internal static class Settings
    {
        public const string RIGHT_PUBLIC_KEY = "project_public_3fedaeb8b6ff0e34a849c049422f4725_ZQHs-56404af1d4525a22201eeacc0b8e4ed0";
        public const string WRONG_PUBLIC_KEY = "wrong";
        public const string RIGHT_SECRET_KEY = "secret_key_e6e42ebc47aaa75f7161b307a3464297__tMrk149492f181e7a12e0eae08527cfa166a";
        public const string WRONG_SECRET_KEY = "wrong";
        public static string BASE_PATH => $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}";
        public static string DATA_PATH => $"{BASE_PATH}{Path.DirectorySeparatorChar}Data";
        public const string GOOD_PDF_FILE = "should-work.pdf";
        public const string BAD_PDF_FILE = "should-fail.pdf";
        public const string BAD_TXT_FILE = "should-fail.txt";
        public const int MAX_ALLOWED_FiLES = 1000;
    }

}
