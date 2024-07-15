using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
	public class SuplierDao
	{
		public List<Suplier> getAll()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Supliers.ToList();
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}
		public List<Suplier> GetAllActiveSuppliers()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Supliers.Where(s => s.Status ==  "1").ToList();
			}
			catch (Exception e)
			{
				throw new Exception($"Error retrieving active suppliers: {e.Message}");
			}
		}

		public void DeteteSuplier(Suplier suplier)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();

				var isUsed = context.Objects.Any(o => o.IdSuplier == suplier.Id);
				if (isUsed)
				{
					throw new Exception("Không thể xóa nhà cung cấp đã được sử dụng trong quá trình nhập, xuất vật tư.");
				}

				context.Supliers.Remove(suplier);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception($"Error deleting supplier: {ex.Message}");
			}
		}

		public void Add(Suplier suplier) {
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Supliers.Add(suplier);
				context.SaveChanges();
			}
			catch (Exception e)
			{

				throw new Exception(e.Message);
			}
		}

		public bool ExistsByName(string name)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var suplier = context.Supliers.FirstOrDefault(s => s.DisplayName.ToLower() == name.ToLower());
				return suplier != null; 
			}
			catch (Exception e)
			{
				throw new Exception($"Error checking existence of supplier by name: {e.Message}");
			}
		}

		public bool EsxitEmail(string email)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var suplier = context.Supliers.FirstOrDefault(x => x.Email == email);
				return suplier != null;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		public bool EsxitPhone(string phone)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var suplier = context.Supliers.FirstOrDefault(x => x.Phone == phone);
				return suplier != null;
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
		public void Update(Suplier suplier)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Entry(suplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
			}
			catch (Exception e)
			{
				throw new Exception($"Error checking existence of supplier by name: {e.Message}");
			}
		}

		public bool ExistsByNameInclue(string name, int currentSuplierId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Supliers.Any(s => s.DisplayName.ToLower() == name.ToLower() && s.Id != currentSuplierId);
			}
			catch (Exception e)
			{
				throw new Exception($"Error checking existence of supplier by name: {e.Message}");
			}
		}

		public bool ExistsByPhoneInclue(string phone, int currentSuplierId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Supliers.Any(s => s.Phone == phone && s.Id != currentSuplierId);
			}
			catch (Exception e)
			{
				throw new Exception($"Error checking existence of supplier by name: {e.Message}");
			}
		}

		public bool ExistsByEmailInclue(string email, int currentSuplierId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.Supliers.Any(s => s.Email == email && s.Id != currentSuplierId);
			}
			catch (Exception e)
			{
				throw new Exception($"Error checking existence of supplier by name: {e.Message}");
			}
		}
	}
}
