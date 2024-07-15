using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DAL
{
	public class InputDao
	{
		public List<InputInfoViewModel> GetAll()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var inputInfos = context.InputInfos
				.Select(ii => new InputInfoViewModel
				{
					Id = ii.Id,
					ObjectName = ii.IdObjectNavigation.DisplayName,
					InputId = ii.IdInput,
					Count = ii.Count,
					InputPrice = ii.InputPrice,
					OutputPrice = ii.OutputPrice,
					UserName = ii.IdUserNavigation.DisplayName,
					DateInput = ii.IdInputNavigation.DateInput,
					SuplierName = ii.IdObjectNavigation.IdSuplierNavigation.DisplayName
				})
				.ToList();
				return inputInfos;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
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

		public bool IsIdInputExists(string idInput)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.InputInfos.Any(ii => ii.IdInput == idInput);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool IsIdObjectExists(string idObject)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.InputInfos.Any(ii => ii.IdObject == idObject);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

	}
}
