using NUnit.Framework;
using System;
using System.Linq;
using WebDriver_POM.Pages;

namespace WebDriver_POM.Tests
{
	public class AddStudentTests : BaseTests
	{
		private AddStudentPage add_student;

		[Test]
		public void Test_AddStudent_Url_Heading_Title()
		{
			add_student = new AddStudentPage(driver);
			add_student.Open();
			Assert.AreEqual(add_student.GetPageUrl(), driver.Url);
			Assert.That(add_student.GetPageHeading(), Is.EqualTo("Register New Student"));
			Assert.That(add_student.GetPageTitle(), Is.EqualTo("Add Student"));
		}

		[Test]
		public void Test_If_AddStudent_IsOpen()
		{
			add_student = new AddStudentPage(driver);
			add_student.Open();
			Assert.That(add_student.isOpen());
		}

		[Test]
		public void Test_AddStudent_AddStudentLink()
		{
			add_student = new AddStudentPage(driver);
			add_student.Open();
			add_student.AddStudentLink.Click();
			Assert.That(add_student.GetPageTitle(), Is.EqualTo("Add Student"));
		}

		[Test]
		public void Test_AddStudent_HomeLink()
		{
			add_student = new AddStudentPage(driver);
			add_student.Open();
			add_student.HomeLink.Click();
			var home_page = new HomePage(driver);
			Assert.That(home_page.GetPageTitle(), Is.EqualTo("MVC Example"));
			Assert.That(home_page.GetPageUrl(), Is.EqualTo(driver.Url));
		}

		[Test]
		public void Test_AddStudent_ViewStudentsLink()
		{
			add_student = new AddStudentPage(driver);
			add_student.Open();
			add_student.ViewStudentsLink.Click();
			var view_students = new ViewStudentsPage(driver);
			Assert.That(view_students.GetPageTitle(), Is.EqualTo("Students"));
			Assert.That(view_students.GetPageUrl, Is.EqualTo(driver.Url));
		}

		[Test]
		public void Test_AddStudent_RegisterStudent_WithValidData()
		{
			add_student = new AddStudentPage(driver);
			add_student.Open();
			
			var name = DateTime.Now.Ticks.ToString();
			var validEmail = DateTime.Now.Ticks.ToString() + "@" + DateTime.Now.Ticks.ToString();

			add_student.RegisterStudent(name, validEmail);

			var view_students = new ViewStudentsPage(driver);
			view_students.Open();
			
			var lastTableElement = view_students.Table.Last();

			Assert.That(lastTableElement.Text.Contains($"{name} ({validEmail})"));
		}

		[Test]
		public void Test_AddStudent_RegisterStudent_WithInvalidData()
		{
			add_student = new AddStudentPage(driver);
			add_student.Open();
			//add_student.RegisterStudent("Ivan Petrov", "ivanpetrovgmail.com");

			var name = DateTime.Now.Ticks.ToString();
			var invalidEmail = DateTime.Now.Ticks.ToString();
			add_student.RegisterStudent(name, invalidEmail);

			var view_students = new ViewStudentsPage(driver);
			view_students.Open();

			var lastTableElement = view_students.Table.Last();

			Assert.That(lastTableElement.Text, Does.Not.Contains(invalidEmail));
		}

	}
}
