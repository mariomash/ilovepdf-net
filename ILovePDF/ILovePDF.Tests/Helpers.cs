namespace ILovePDF.Tests
{
    public class Helpers
    {

        public static LovePdfApi InitApiWithWrongCredentials()
        {
            return new LovePdfApi(Settings.WRONG_PUBLIC_KEY, Settings.WRONG_SECRET_KEY);
        }

        public static LovePdfApi InitApiWithRightCredentials()
        {
            return new LovePdfApi(Settings.RIGHT_PUBLIC_KEY, Settings.RIGHT_SECRET_KEY);
        }

    }
}
