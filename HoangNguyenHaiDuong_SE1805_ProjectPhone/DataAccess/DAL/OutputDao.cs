using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
										.Include(o => o.IdOutputNavigation)
										.Include(o => o.IdObjectNavigation)
										.Include(o => o.IdUserNavigation)
										.Include(o => o.IdCustomerNavigation)
										.Where(o => o.Status == "process")
										.Select(o => new OutputInfoViewModel
										{
											IdOutputInfo = o.Id,
											ObjectName = o.IdObjectNavigation.DisplayName,
											Capacity = o.Capacity,
											Count = o.Count,
											CusName = o.IdCustomerNavigation.DisplayName,
											UName = o.IdUserNavigation.DisplayName,
											DateOutput = o.IdOutputNavigation.DateOutput,
											Status = o.Status
										})
										.ToList();
				return outputList;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<OutputInfoViewModel> GetAllOut()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var outputList = context.OutputInfos
										.Include(o => o.IdOutputNavigation)
										.Include(o => o.IdObjectNavigation)
										.Include(o => o.IdUserNavigation)
										.Include(o => o.IdCustomerNavigation)									
										.Select(o => new OutputInfoViewModel
										{
											IdOutputInfo = o.Id,
											ObjectName = o.IdObjectNavigation.DisplayName,
											Capacity = o.Capacity,
											Count = o.Count,
											CusName = o.IdCustomerNavigation.DisplayName,
											UName = o.IdUserNavigation.DisplayName,
											Status = o.Status
										})
										.ToList();
				return outputList;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public List<OutputInfoViewModel> GetAllById(int cusId)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				var outputList = context.OutputInfos
										.Include(o => o.IdOutputNavigation)
										.Include(o => o.IdObjectNavigation)
										.Include(o => o.IdUserNavigation)
										.Include(o => o.IdCustomerNavigation)
										.Where(o => o.IdCustomer == cusId)
										.Select(o => new OutputInfoViewModel
										{
											IdOutputInfo = o.Id,
											ObjectName = o.IdObjectNavigation.DisplayName,
											Capacity = o.Capacity,
											Count = o.Count,
											UName = o.IdUserNavigation.DisplayName,
											Status = o.Status
										})
										.ToList();
				return outputList;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool CanExport(int idObject, int count, string capa)
		{
			using var context = new QuanLyKhoDienThoaiContext();

			var totalInput = context.InputInfos
				.Where(ii => ii.IdObject == idObject && ii.Capacity == capa)
				.Sum(ii => ii.Count);

			var totalOutput = context.OutputInfos
				.Where(oi => oi.IdObject == idObject && oi.Capacity == capa
							 && (oi.Status == "accept" || oi.Status == "process"))
				.Sum(oi => oi.Count ?? 0);

			return (totalInput - totalOutput) >= count;
		}

		public void AddOutput(OutputInfo output)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				output.Status = "process";
				context.OutputInfos.Add(output);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		
		public OutputInfo GetOutputById (int id)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				return context.OutputInfos.FirstOrDefault(o => o.Id == id);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void Update(OutputInfo outputInfo)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.Entry(outputInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				context.SaveChanges();
			}
			catch (Exception e)
			{
				throw new Exception($"Error checking existence of supplier by name: {e.Message}");
			}
		}
		public void AddBill(BillHistory bill)
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				context.BillHistories.Add(bill);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
