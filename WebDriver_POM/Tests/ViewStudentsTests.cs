using NUnit.Framework;
using WebDriver_POM.Pages;

namespace WebDriver_POM.Tests
{
	public class ViewStudentsTests : BaseTests
	{
		private ViewStudentsPage view_students;

		[Test]
		public void Test_ViewStudents_Url_Heading_Title()
		{
			view_students = new ViewStudentsPage(driver);
			view_students.Open();
			Assert.AreEqual(view_students.GetPageUrl(), driver.Url);
			Assert.That(view_students.GetPageHeading(), Is.EqualTo("Registered Students"));
			Assert.That(view_students.GetPageTitle(), Is.EqualTo("Students"));
		}

		[Test]
		public void Test_If_ViewStudents_isOpen()
		{
			view_students = new ViewStudentsPage(driver);
			view_students.Open();
			Assert.That(view_students.isOpen());
		}

		[Test]
		public void Test_ViewStudents_ViewStudentsLink()
		{
			view_students = new ViewStudentsPage(driver);
			view_students.Open();
			view_students.ViewStudentsLink.Click();
			Assert.That(view_students.GetPageTitle(), Is.EqualTo("Students"));
		}

		[Test]
		public void Test_ViewStudents_HomeLink()
		{
			view_students = new ViewStudentsPage(driver);
			view_students.Open();
			view_students.HomeLink.Click();
			var home_page = new HomePage(driver);
			Assert.That(home_page.GetPageTitle(), Is.EqualTo("MVC Example"));
			Assert.That(home_page.GetPageUrl(), Is.EqualTo(driver.Url));
		}

		[Test]
		public void Test_ViewStudents_AddStudentLink()
		{
			view_students = new ViewStudentsPage(driver);
			view_students.Open();
			view_students.AddStudentLink.Click();
			var add_student = new AddStudentPage(driver);
			Assert.That(add_student.GetPageTitle(), Is.EqualTo("Add Student"));
			Assert.That(add_student.GetPageUrl, Is.EqualTo(driver.Url));
		}

		[Test]
		public void Test_ViewStudents_RegesteredStudents()
		{
			view_students = new ViewStudentsPage(driver);
			view_students.Open();

			Assert.IsNotEmpty(view_students.Table);
		}
	}
}
