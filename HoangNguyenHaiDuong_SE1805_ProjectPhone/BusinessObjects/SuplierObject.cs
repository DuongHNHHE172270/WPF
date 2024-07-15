using DataAccess.DAL;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
	public class SuplierObject
	{
		private readonly SuplierDao suplierDao;

		public SuplierObject()
		{
			suplierDao = new SuplierDao();
		}

		public List<Suplier> GetAllSupliers() => suplierDao.getAll();
		public List<Suplier> GetAllActiveSupliers() => suplierDao.GetAllActiveSuppliers();

		public List<Suplier> Search(String character)
		{
			return GetAllSupliers().Where(p => p.DisplayName.ToLower().Contains(character.ToLower())).ToList();
		}

		public void detete(Suplier  suplier) => suplierDao.DeteteSuplier(suplier);

		public void AddSuplier(Suplier suplier) => suplierDao.Add(suplier);

		public bool ExitsNameSuplier(String name) => suplierDao.ExistsByName(name);

		public bool ExitsEamailSuplier(String email) => suplierDao.EsxitEmail(email);

		public bool ExitsPhoneSuplier(String phone) => suplierDao.EsxitPhone(phone);

		public bool ExistsByNameExcludingCurrent(string name, int currentSuplierId) => suplierDao.ExistsByNameInclue(name, currentSuplierId);
		public bool ExistsByPhoneExcludingCurrent(string phone, int currentSuplierId) => suplierDao.ExistsByPhoneInclue(phone, currentSuplierId);

		public bool ExistsByEmailExcludingCurrent(string email, int currentSuplierId) => suplierDao.ExistsByEmailInclue(email, currentSuplierId);

		public void UpdateSuplier(Suplier suplier) => suplierDao.Update(suplier);
	}
}
