using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver? driver = null;

            try
            {
                var browserPaths = new[]
                {
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "CocCoc", "Browser", "Application", "browser.exe"),
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "CocCoc", "Browser", "Application", "browser.exe"),
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CocCoc", "Browser", "Application", "browser.exe")
                };
                var browserPath = browserPaths.FirstOrDefault(File.Exists)
                    ?? throw new FileNotFoundException("Không tìm thấy trình duyệt Cốc Cốc. Hãy kiểm tra vị trí cài đặt.");

                var options = new ChromeOptions { BinaryLocation = browserPath };      
                driver = new ChromeDriver(options);
                driver.Navigate().GoToUrl("https://example.com");

                var title = driver.Title;
                Console.WriteLine($"Page title: {title}");

                Assert.That(title, Is.EqualTo("Example Domain"));
            }
            finally
            {
                driver?.Quit();
            }
        }
    }
}
