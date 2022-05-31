using NUnit.Framework;
using WebDriver_POM.Pages;

namespace WebDriver_POM.Tests
{
	public class HomePageTests : BaseTests
	{
		private HomePage home_page;

		[Test]
		public void Test_HomePage_Url_Heading_Title()
		{
			home_page = new HomePage(driver);
			home_page.Open();
			Assert.AreEqual(home_page.GetPageUrl(), driver.Url);
			Assert.That(home_page.GetPageHeading(), Is.EqualTo("Students Registry"));
			Assert.That(home_page.GetPageTitle(), Is.EqualTo("MVC Example"));
		}

		[Test]
		public void Test_If_HomePage_isOpen()
		{
			home_page = new HomePage(driver);
			home_page.Open();
			Assert.That(home_page.isOpen());
		}

		[Test]
		public void Test_HomePage_HomeLink()
		{
			home_page = new HomePage(driver);
			home_page.Open();
			home_page.HomeLink.Click();
			Assert.That(home_page.GetPageTitle(), Is.EqualTo("MVC Example"));
		}

		[Test]
		public void Test_HomePage_ViewStudentsLink()
		{
			home_page = new HomePage(driver);
			home_page.Open();
			home_page.ViewStudentsLink.Click();
			var view_student = new ViewStudentsPage(driver);
			Assert.That(view_student.GetPageTitle(), Is.EqualTo("Students"));
			Assert.That(view_student.GetPageUrl(), Is.EqualTo(driver.Url));
		}

		[Test]
		public void Test_HomePage_AddStudentLink()
		{
			home_page = new HomePage(driver);
			home_page.Open();
			home_page.AddStudentLink.Click();
			var add_student = new AddStudentPage(driver);
			Assert.That(add_student.GetPageTitle(), Is.EqualTo("Add Student"));
			Assert.That(add_student.GetPageUrl, Is.EqualTo(driver.Url));
		}

		[Test]
		public void Test_HomePage_StudentCount()
		{
			home_page = new HomePage(driver);
			home_page.Open();
			Assert.Greater(home_page.GetStudentCount(), 0);
		}
	}
}
