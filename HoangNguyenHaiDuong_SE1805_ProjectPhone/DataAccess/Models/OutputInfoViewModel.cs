using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class OutputInfoViewModel
	{
		public string IdOutputInfo { get; set; }
		public string ObjectName { get; set; }
		public int? Count { get; set; }
		public string CusName { get; set; }
		public string UName { get; set; }
		public DateTime? DateOutput { get; set; }
	}
}

