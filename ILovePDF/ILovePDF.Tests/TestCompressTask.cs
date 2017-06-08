using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using ILovePDF.Model.Task;
using System.Net.Http;
using System.Collections.Generic;

namespace ILovePDF.Tests
{

    [TestClass]
    public class TestCompressTask
    {
        [TestMethod]
        [ExpectedException(typeof(HttpRequestException), "A user with invalid credentials was inappropriately allowed.")]
        public void TestCompressWrongCredentials_ShouldThrowException()
        {
            var api = Helpers.InitApiWithWrongCredentials();

            string[] files = { $"{Settings.DATA_PATH}{Path.DirectorySeparatorChar}{Settings.GOOD_PDF_FILE}" };

            TestCompress(api, files);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException), "A Damaged File was inappropriately allowed.")]
        public void TestCompressWrongFile_ShouldThrowException()
        {
            var api = Helpers.InitApiWithRightCredentials();

            string[] files = { $"{Settings.DATA_PATH}{Path.DirectorySeparatorChar}{Settings.BAD_PDF_FILE}" };

            TestCompress(api, files);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException), "More files than allowed were inappropriately allowed.")]
        public void TestCompressMaxFiles_ShouldThrowException()
        {
            var api = Helpers.InitApiWithRightCredentials();

            var files = new List<string>();
            for (var i = 0; i < Settings.MAX_ALLOWED_FiLES; i++)
                files.Add($"{Settings.DATA_PATH}{Path.DirectorySeparatorChar}{Settings.GOOD_PDF_FILE}");

            TestCompress(api, files);
        }

        public void TestCompress(LovePdfApi api, ICollection<string> files)
        {
            var taskCompress = api.CreateTask<CompressTask>();

            foreach (var file in files)
                taskCompress.AddFile(file);

            taskCompress.Process();

            var resultFile = $"{Settings.BASE_PATH}{Path.DirectorySeparatorChar}{Settings.GOOD_PDF_FILE}";
            if (File.Exists(resultFile))
                File.Delete(resultFile);

            taskCompress.DownloadFile(Settings.BASE_PATH);

            Assert.IsTrue(File.Exists(resultFile));
        }
    }
}
