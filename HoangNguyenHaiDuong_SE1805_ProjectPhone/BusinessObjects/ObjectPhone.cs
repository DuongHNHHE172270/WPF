using DataAccess.DAL;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace BusinessObjects
{
	public class ObjectPhone
	{
		private readonly ObjectDao objectDao;

		public ObjectPhone()
		{
			objectDao = new ObjectDao();
		}

		public List<DataAccess.Models.Object> GetAllObject() => objectDao.GetAll();

		public List<DataAccess.Models.Object> GetAllActiveObject() => objectDao.GetAllActiveObjects();

		public void AddObject(DataAccess.Models.Object obj) => objectDao.Add(obj);
		public void DeleteObject(DataAccess.Models.Object obj)
		{
			objectDao.Delete(obj);
		}

		public List<DataAccess.Models.Object> SearchByName(string name)
		{
			return objectDao.SearchByName(name);
		}

		public void UpdateObj(DataAccess.Models.Object obj) => objectDao.Update(obj);

		public int GetTotalInputInfoCount(string objectId) => objectDao.GetTotalInputInfo(objectId);

		public int GetTotalOutputInfoCount(string objectId) => objectDao.GetTotalOutputInfo(objectId);

		public int GetTotalInventory(string objectId) => objectDao.GetInventory(objectId);

	}
}
