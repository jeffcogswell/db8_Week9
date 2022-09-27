using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace DapperConsole
{
	[Table("employee")]
	public class Employee
	{
		// We use [Key] if there's an autoincrement primary key
		// Otherwise we use [ExplicitKey]
		[Key]
		public int id { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string phone { get; set; }
		public string email { get; set; }
		public string department { get; set; }
		public override string ToString()
		{
			return $"{id} {firstname} {lastname} {phone} {email} {department}";
		}
	}
}
