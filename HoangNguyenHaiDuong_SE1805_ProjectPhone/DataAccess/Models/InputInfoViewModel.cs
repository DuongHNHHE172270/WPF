using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class InputInfoViewModel
	{
		public string Id { get; set; }
		public string ObjectName { get; set; }
		public string InputId { get; set; }
		public int? Count { get; set; }
		public double? InputPrice { get; set; }
		public double? OutputPrice { get; set; }
		public string UserName { get; set; }
		public DateTime? DateInput { get; set; }
		public string SuplierName { get; set; }
	}
}
