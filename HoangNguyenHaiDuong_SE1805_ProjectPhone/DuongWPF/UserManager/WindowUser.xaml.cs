using ClosedXML.Excel;
using DataAccess.DAL;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DuongWPF.UserManager
{
	/// <summary>
	/// Interaction logic for WindowUser.xaml
	/// </summary>
	public partial class WindowUser : Window
	{
		private readonly UserDao userDao;

		public WindowUser()
		{
			InitializeComponent();
			userDao = new UserDao();
			LoadUsers();
		}

		private void LoadUsers()
		{
			try
			{
				var userList = userDao.GetAllUsers();
				dgInputInfo.ItemsSource = userList;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
			}
		}

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchTerm = SearchTextBox.Text.Trim();

			try
			{
				var userList = userDao.GetAllUsers().Where(u => u.DisplayName.ToLower().Contains(searchTerm.ToLower())).ToList();
				dgInputInfo.ItemsSource = userList;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
			}
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			LoadUsers();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (dgInputInfo.SelectedItem != null)
			{
				User selectedUser = dgInputInfo.SelectedItem as User;

				try
				{
					bool success = userDao.UpdateUserStatus(selectedUser.Id);
					if (success)
					{
						MessageBox.Show("Cập nhật thành công.");
						LoadUsers();
					}
					else
					{
						MessageBox.Show("Cập nhật thất bại.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn người dùng để cập nhật.");
			}
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowAdmin windowAdmin = new WindowAdmin();
			windowAdmin.Show();
			this.Close();
		}

		private void btnFile_Click(object sender, RoutedEventArgs e)
		{
			ExportDataGridToExcel();
		}

		private void ExportDataGridToExcel()
		{
			try
			{
				var saveFileDialog = new Microsoft.Win32.SaveFileDialog
				{
					Filter = "Excel files (*.xlsx)|*.xlsx",
					FilterIndex = 2,
					RestoreDirectory = true
				};

				if (saveFileDialog.ShowDialog() == true)
				{
					using (var workbook = new XLWorkbook())
					{
						var worksheet = workbook.Worksheets.Add("User Info");

						// Add custom header row
						worksheet.Cell(1, 1).Value = "Danh sách nhân viên";
						worksheet.Range("A1:E1").Merge().Style.Font.SetBold().Font.FontSize = 16;

						// Adding headers from DataGrid
						for (int i = 0; i < dgInputInfo.Columns.Count; i++)
						{
							worksheet.Cell(2, i + 1).Value = dgInputInfo.Columns[i].Header.ToString();
						}

						// Adding the rows
						var itemsSource = dgInputInfo.ItemsSource as IEnumerable<User>;
						if (itemsSource != null)
						{
							int row = 3; // Start after the header row
							foreach (var item in itemsSource)
							{
								worksheet.Cell(row, 1).Value = item.Id;
								worksheet.Cell(row, 2).Value = item.DisplayName;
								worksheet.Cell(row, 3).Value = item.UserName;
								worksheet.Cell(row, 4).Value = item.IdRoleNavigation?.DisplayName;
								worksheet.Cell(row, 5).Value = item.Status;

								row++;
							}
						}

						workbook.SaveAs(saveFileDialog.FileName);
					}
					MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Có lỗi xảy ra khi xuất file Excel: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
	}
}
