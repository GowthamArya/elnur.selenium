using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace elnur.selenium.HomePage
{
	public class Header
	{
		public string Logo { get; set; }
		public Header()
		{
			Logo = "elnurLogo";
		}

		public static void TestHeaderNavigate()
		{
			IWebDriver driver = new ChromeDriver();
			try{
				driver.Navigate().GoToUrl("https://www.elnursolutions.com/");
				Task.Delay(1000).Wait();

				driver.FindElement(By.LinkText("Home")).Click();
				Console.WriteLine("Navigated to Page: " + driver.Title);
				
				Task.Delay(1000).Wait();

				driver.FindElement(By.LinkText("Products")).Click();
				Console.WriteLine("Navigated to Page: " + driver.Title);

				Task.Delay(1000).Wait();

				driver.FindElement(By.LinkText("Contact")).Click();
				Console.WriteLine("Navigated to Page: " + driver.Title);
			}
			catch
			{
				Console.WriteLine("Error initializing ChromeDriver. Ensure ChromeDriver is installed and in PATH.");
				return;
			}
			
			Console.ReadKey();
			driver.Quit();
		}
	}
}
