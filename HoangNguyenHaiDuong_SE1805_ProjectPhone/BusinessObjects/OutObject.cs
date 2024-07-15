using DataAccess.DAL;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public  class OutObject
	{
		private readonly OutputDao outputDao;

		public OutObject()
		{
			outputDao = new OutputDao();
		}

		public List<OutputInfoViewModel> GetAllOutputs()
		{
			return outputDao.GetAll();
		}

		public void AddOutput(OutputInfo output)
		{
			if (outputDao.CanExport(output.IdObject, output.Count ?? 0))
			{
				outputDao.AddOutput(output);
			}
			else
			{
				throw new Exception("Số lượng vật tư không đủ để xuất kho.");
			}
		}
		public bool IsOutputIdExists(string idOutputInfo) => outputDao.IsOutputIdExists(idOutputInfo);
	}
}
