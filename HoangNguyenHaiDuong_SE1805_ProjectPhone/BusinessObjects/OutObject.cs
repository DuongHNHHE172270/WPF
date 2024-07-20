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

		public void AddOutput(OutputInfo output, string capa)
		{
			if (outputDao.CanExport(output.IdObject, output.Count ?? 0, capa))
			{
				outputDao.AddOutput(output);
			}
			else
			{
				throw new Exception("Số lượng vật tư không đủ để xuất kho.");
			}
		}

		public List<OutputInfoViewModel> GetAllOutputs() => outputDao.GetAll();

		public List<OutputInfoViewModel> GetAllOutputAd() => outputDao.GetAllOut();

		public List<OutputInfoViewModel> GetAllOutputsCus(int cusId) => outputDao.GetAllById(cusId);
		public OutputInfo GetById(int id) => outputDao.GetOutputById(id);

		public void UpdateOutInfo(OutputInfo output) => outputDao.Update(output);

		public void AddBill(BillHistory billHistory) => outputDao.AddBill(billHistory);
		
	}
}
