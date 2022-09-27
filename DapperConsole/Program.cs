using Dapper;
using Dapper.Contrib.Extensions;
using DapperConsole;
using MySql.Data.MySqlClient;

var db = new MySqlConnection("Server=127.0.0.1;Database=business;Uid=root;Pwd=abc123;");
List<Employee> emps = db.GetAll<Employee>().ToList();

foreach (Employee emp in emps)
{
	Console.WriteLine(emp);
}

// Let's add a new employee
// Leave out the id. Let the database create that for us.

//Employee e1 = new Employee() { firstname = "Jeff", lastname = "Cogswell",
//	phone = "517-111-2222", email = "jeff@google.com", department = "ACCT" };
//db.Insert(e1);

// Let's delete the one with id 28
// db.Delete(new Employee() { id = 28 });

Console.WriteLine("Let's just read a single one, by ID. We'll do id 5");
Employee e2 = db.Get<Employee>(5);
Console.WriteLine(e2);

// Now let's change the spelling from Emily to Emilie.

//e2.firstname = "Emilie";
//db.Update<Employee>(e2);

Console.WriteLine();
Console.WriteLine("Let's get all employeees who work in the IT department");

List<Employee> emps2 = db.Query<Employee>("select * from employee where department = 'IT'").ToList();
foreach (Employee emp in emps2)
{
	Console.WriteLine(emp);
}
