using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
	public class UserDao
	{
		public List<User> GetAllUsers()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext(); 
				return context.Users
							  .Include(u => u.IdRoleNavigation)
							  .ToList();
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi khi tải dữ liệu người dùng: " + ex.Message);
			}
		}

		public bool UpdateUserStatus(int userId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext(); 
				var user = context.Users.Find(userId);
				if (user != null)
				{
					user.Status = user.Status == "1" ? "0" : "1";
					context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw new Exception("Lỗi khi cập nhật trạng thái người dùng: " + ex.Message);
			}
		}
	}
}
