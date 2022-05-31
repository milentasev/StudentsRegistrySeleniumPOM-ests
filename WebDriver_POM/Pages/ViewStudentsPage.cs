using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace WebDriver_POM.Pages
{
	public class ViewStudentsPage : BasePage
	{
		public ViewStudentsPage(IWebDriver driver) : base(driver)
		{
		}

		public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/students";

		public ReadOnlyCollection<IWebElement> Table => driver.FindElements(By.CssSelector("body > ul"));

	}
}
