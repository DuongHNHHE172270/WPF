using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.DAL
{
	public class ObjectDao
	{
		public List<DataAccess.Models.Object> GetAll()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Objects.Include(o => o.IdSuplierNavigation)
									  .Include(o => o.ObjectDetails)
					.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error retrieving objects: {ex.Message}");
			}
		}

		public List<DataAccess.Models.Object> GetAllActiveObjects()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Objects
							  .Include(o => o.IdSuplierNavigation)
							  .Where(o => o.Status == "1")
							  .ToList();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error retrieving active objects: {ex.Message}");
			}
		}

		public void Add(DataAccess.Models.Object obj)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Objects.Add(obj);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error adding object: {ex.Message}");
			}
		}
		public List<DataAccess.Models.Object> SearchByName(string name)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Objects
							  .Include(o => o.IdSuplierNavigation)
							  .Where(o => EF.Functions.Like(o.DisplayName, $"%{name}%"))
							  .ToList();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error searching objects by name: {ex.Message}");
			}
		}

		public List<ObjectDetail> SearchByNameDetail(string name)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.ObjectDetails
							  .Include(o => o.IdObjectNavigation)
							  .Where(o => EF.Functions.Like(o.IdObjectNavigation.DisplayName, $"%{name}%"))
							  .ToList();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error searching object details by name: {ex.Message}");
			}
		}

		public void Delete(DataAccess.Models.Object obj)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();	
				var isUsed = context.InputInfos.Any(i => i.IdObject == obj.Id) || context.OutputInfos.Any(o => o.IdObject == obj.Id);
				if (isUsed)
				{
					throw new Exception("Không thể xóa vật tư đã được sử dụng trong quá trình nhập, xuất kho.");
				}

				context.Objects.Remove(obj);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error deleting object: {ex.Message}");
			}
		}
		public void Update(DataAccess.Models.Object obj)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
			}
			catch (Exception e)
			{
				throw new Exception($"Error updating object: {e.Message}");
			}
		}

		public void UpdateDetail(ObjectDetail obj)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
			}
			catch (Exception e)
			{
				throw new Exception($"Error updating object: {e.Message}");
			}
		}

		public int GetTotalInputInfo(int objectId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				int totalCount;

				if (objectId == -1)
				{
					totalCount = context.InputInfos.Sum(ii => ii.Count);
				}
				else
				{
					totalCount = context.InputInfos
										.Where(ii => ii.IdObject == objectId)
										.Sum(ii => ii.Count);
				}

				return totalCount;
			}
			catch (Exception e)
			{
				throw new Exception($"Error retrieving total input info count: {e.Message}");
			}
		}


		public int GetTotalOutputInfo(int objectId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				int totalCount;

				if (objectId == -1)
				{
					totalCount = context.OutputInfos.Where(ii => ii.Status == "accept").Sum(ii => ii.Count ?? 0);
				}
				else
				{
					totalCount = context.OutputInfos
										.Where(ii => ii.IdObject == objectId && ii.Status == "accept")
										.Sum(ii => ii.Count ?? 0);
				}

				return totalCount;
			}
			catch (Exception e)
			{
				throw new Exception($"Error retrieving total input info count: {e.Message}");
			}
		}

		public int GetInventory(int objectId)
		{
			try
			{
			

				return GetTotalInputInfo(objectId) - GetTotalOutputInfo(objectId);
			}
			catch (Exception e)
			{
				throw new Exception($"Error retrieving total input info count: {e.Message}");
			}
		}

		public void UpdateObject(DataAccess.Models.Object obj)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Objects.Update(obj);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error updating object: {ex.Message}");
			}
		}
		
		public List<ObjectDetail> GetAllObjDetail ()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.ObjectDetails.Include(o => o.IdObjectNavigation).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error updating object: {ex.Message}");
			}
		}

		public List<ObjectDetail> GetAllObjDetailById(int id)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				if (id == -1)
				{
					
					return context.ObjectDetails.Include(o => o.IdObjectNavigation).ToList();
				}
				else
				{
					return context.ObjectDetails.Include(o => o.IdObjectNavigation).Where(o => o.IdObject == id).ToList();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Error updating object: {ex.Message}");
			}


		}

		public List<ObjectDetail> GetCapacityBy(int objId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.ObjectDetails.Where(o => o.IdObject == objId).ToList();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error updating object: {ex.Message}");
			}
		}

		public DataAccess.Models.Object GetObjectById(int id)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Objects.FirstOrDefault(o => o.Id == id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
