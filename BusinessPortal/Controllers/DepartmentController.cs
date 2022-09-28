using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using BusinessPortal.Models;

namespace BusinessPortal.Controllers
{
	public class DepartmentController : Controller
	{
		// C(R)UD - View that lists all departments
		public IActionResult Index()
		{
			// List all of the departments
			var db = new MySqlConnection("Server=127.0.0.1;Database=business;Uid=root;Pwd=abc123;");
			IEnumerable<Department> depts = db.GetAll<Department>();
			return View(depts);
		}

		// C(R)UD - View a single department and its details
		public IActionResult Detail(string id)
		{
			// I started with a Content(id) just for testing. I wanted to see
			// if this function is in fact receiving the department ID, and
			// to test it I'm just sending that ID back to the browser.
			//return Content(id);
			var db = new MySqlConnection("Server=127.0.0.1;Database=business;Uid=root;Pwd=abc123;");
			Department dep = db.Get<Department>(id);

			// Now let's get a list of people who work there
			List<Employee> emps = db.Query<Employee>(
				$"select * from employee where department = '{id}'").ToList();
			ViewData["employees"] = emps;
			return View(dep);
		}

		// View that presents a form for adding a new department

		public IActionResult AddForm()
		{
			return View();
		}

		// (C)RUD - An action that responds to the form for adding a new department

		// CRU(D) Delete a department

		public IActionResult Delete(string id)
		{
			var db = new MySqlConnection("Server=127.0.0.1;Database=business;Uid=root;Pwd=abc123;");
			Department dep = new Department() { id = id };
			db.Delete<Department>(dep);
			return Redirect("/Department");
		}

		// CR(U)D Edit a department
	}
}
