using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DAL
{
	public class InputDao
	{
		public List<InputInfoViewModel> GetAll()
		{
			using (var context = new QuanLyKhoDienThoaiContext())
			{
				return context.InputInfos
							  .Include(i => i.IdObjectNavigation)
							  .ThenInclude(o => o.IdSuplierNavigation)
							  .Include(i => i.IdObjectNavigation.ObjectDetails) 
							  .Select(i => new InputInfoViewModel
							  {
								  Id = i.Id,
								  ObjectName = i.IdObjectNavigation.DisplayName,
								  Capacity = i.Capacity,
								  Count = i.Count,
								  InputPrice = i.InputPrice,
								  UserName = context.Users.FirstOrDefault(u => u.Id == i.IdUser).DisplayName,
								  SuplierName = i.IdObjectNavigation.IdSuplierNavigation.DisplayName,
								  DateInput = context.Inputs.FirstOrDefault(inp => inp.Id == i.IdInput).DateInput
							  }).ToList();
			}
		}


		public void AddInput(InputInfo inputInfo)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.InputInfos.Add(inputInfo);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
