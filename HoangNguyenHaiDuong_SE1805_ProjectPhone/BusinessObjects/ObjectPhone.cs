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

		public List<ObjectDetail> SearchByNameDetailObj(string name)
		{
			return objectDao.SearchByNameDetail(name);
		}

		public void UpdateObj(DataAccess.Models.Object obj) => objectDao.Update(obj);

		public void UpdateObjDetail(ObjectDetail obj) => objectDao.UpdateDetail(obj);

		public int GetTotalInputInfoCount(int objectId) => objectDao.GetTotalInputInfo(objectId);

		public int GetTotalOutputInfoCount(int objectId) => objectDao.GetTotalOutputInfo(objectId);

		public int GetTotalInventory(int objectId) => objectDao.GetInventory(objectId);

		public void UpdateObject(DataAccess.Models.Object obj) => objectDao.UpdateObject(obj);

		public List<ObjectDetail> GetAllObjDetail() => objectDao.GetAllObjDetail();

		public List<ObjectDetail> GetAllObjDetailByObjId(int objId) => objectDao.GetAllObjDetailById(objId);

		public List<ObjectDetail> GetOrderDetaiById(int id) => objectDao.GetCapacityBy(id);

		public DataAccess.Models.Object GetObjById (int id) => objectDao.GetObjectById(id);
	}
}
