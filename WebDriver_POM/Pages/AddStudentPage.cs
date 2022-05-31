using OpenQA.Selenium;


namespace WebDriver_POM.Pages
{
	public class AddStudentPage : BasePage
	{
		public AddStudentPage(IWebDriver driver) : base(driver)
		{
		}

		public override string PageUrl => "https://mvc-app-node-express.nakov.repl.co/add-student";

		public IWebElement Name => driver.FindElement(By.Id("name"));
		public IWebElement Email => driver.FindElement(By.Id("email"));
		public IWebElement AddButton => driver.FindElement(By.CssSelector("form[method='post'] > button[type='submit']"));

		public void RegisterStudent(string name, string email) 
		{
			Name.Click();
			Name.SendKeys(name);

			Email.Click();
			Email.SendKeys(email);

			AddButton.Click();
		}

	}
}
