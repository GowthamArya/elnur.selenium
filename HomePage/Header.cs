using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace elnur.selenium.HomePage
{
    public class Header : Test
    {
        public string Logo { get; set; }
        public Header()
        {
            Logo = "elnurLogo";
        }

        public static void TestHeaderNavigate()
        {
            IWebDriver driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://www.elnursolutions.com/");
                Task.Delay(3000).Wait();
                
                IWebElement productsMenu = driver.FindElement(By.Id("productsDropdownLink"));
                Actions action = new Actions(driver);
                action.MoveToElement(productsMenu).Perform();
                Task.Delay(3000).Wait();

                var listItems = driver.FindElements(By.CssSelector("#ulproductsDropdown a"));
                for (var item = 0; item < listItems.Count; item++)
                {
                    IWebElement dropdownMenu = driver.FindElement(By.Id("productsDropdownLink"));
                    Actions hoverAction = new Actions(driver);
                    hoverAction.MoveToElement(dropdownMenu).Perform();
                    Task.Delay(1000).Wait();

                    var refreshedList = driver.FindElements(By.CssSelector("#ulproductsDropdown a"));
                    string linkText = refreshedList[item].Text;
                    refreshedList[item].Click();
                    Task.Delay(1000).Wait();

                    Console.WriteLine("Navigated to Page: " + driver.Title + "--> Clicked - " + linkText);

                    Task.Delay(2000).Wait();
                }


                IWebElement aboutMenu = driver.FindElement(By.Id("aboutDropdownLink"));
                Actions actions = new Actions(driver);
                action.MoveToElement(aboutMenu).Perform();
                Task.Delay(3000).Wait();

                var listItem = driver.FindElements(By.CssSelector("#ulaboutDropdown a"));
                for (var item = 0; item < listItems.Count; item++)
                {
                    IWebElement dropdownMenu = driver.FindElement(By.Id("aboutDropdownLink"));
                    Actions hoverAction = new Actions(driver);
                    hoverAction.MoveToElement(dropdownMenu).Perform();
                    Task.Delay(1000).Wait();

                    var refreshedList = driver.FindElements(By.ClassName("dropdown-menu p-0 m-0 bg-light-theme"));
                    string linkText = refreshedList[item].Text;
                    refreshedList[item].Click();
                    Task.Delay(1000).Wait();

                    Console.WriteLine("Navigated to Page: " + driver.Title + "--> Clicked - " + linkText);

                    Task.Delay(2000).Wait();
                }

                driver.FindElement(By.LinkText("Contact")).Click();
                Console.WriteLine("Navigated to Page: " + driver.Title);
                Console.ReadKey();
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
