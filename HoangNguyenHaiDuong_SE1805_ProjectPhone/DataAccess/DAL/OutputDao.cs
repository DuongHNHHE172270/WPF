using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.DAL
{
	public class OutputDao
	{
		public List<OutputInfoViewModel> GetAll()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var outputList = context.OutputInfos
										.Include(o => o.IdNavigation)
										.Include(o => o.IdObjectNavigation)
										.Include(o => o.IdUserNavigation)
										.Include(o => o.IdCustomerNavigation)
										.Select(o => new OutputInfoViewModel
										{
											IdOutputInfo = o.IdOutputInfo,
											ObjectName = o.IdObjectNavigation.DisplayName,
											Count = o.Count,
											CusName = o.IdCustomerNavigation.DisplayName,
											UName = o.IdUserNavigation.DisplayName,
											DateOutput = o.IdNavigation.DateOutput,
										})
										.ToList();
				return outputList;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool CanExport(string idObject, int count)
		{
			using var context = new QuanLyKhoDienThoaiContext();
			var totalInput = context.InputInfos
									.Where(i => i.IdObject == idObject)
									.Sum(i => i.Count ?? 0);

			var totalOutput = context.OutputInfos
									.Where(o => o.IdObject == idObject)
									.Sum(o => o.Count ?? 0);

			return (totalInput - totalOutput) >= count;
		}
		public void AddOutput(OutputInfo output)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.OutputInfos.Add(output);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool IsOutputIdExists(string idOutputInfo)
		{
			using var context = new QuanLyKhoDienThoaiContext();
			return context.OutputInfos.Any(o => o.IdOutputInfo == idOutputInfo);
		}
	}
}
