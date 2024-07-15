using BusinessObjects;
using ClosedXML.Excel;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DuongWPF.Suplier
{
	/// <summary>
	/// Interaction logic for WindowSuplier.xaml
	/// </summary>
	public partial class WindowSuplier : Window
	{
		private readonly SuplierObject suplierObject;
		public WindowSuplier()
		{
			InitializeComponent();
			suplierObject = new SuplierObject();
			Loaded += WindowSuplier_Loaded;
		}

		public void Load()
		{
			dgSupplier.ItemsSource = suplierObject.GetAllSupliers();
		}

		void resetForm() {
			SearchTextBox.Text = null;
				}

		private void WindowSuplier_Loaded(object sender, RoutedEventArgs e)
		{
			Load();
		}

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			dgSupplier.ItemsSource = suplierObject.Search(SearchTextBox.Text);
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			resetForm();
			Load();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			WindowSuplierPopup windowSuplierPopup = new WindowSuplierPopup();
			windowSuplierPopup.Owner = this;
			windowSuplierPopup.ShowDialog();
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowAdmin windowAdmin = new WindowAdmin();
			windowAdmin.Show();
			this.Close();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (dgSupplier.SelectedItem is DataAccess.Models.Suplier suplier) { 
				WindowUpdatePopup windowUpdatePopup = new WindowUpdatePopup(suplier);
				windowUpdatePopup.Owner = this;
				windowUpdatePopup.ShowDialog();
			}
		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (dgSupplier.SelectedItem is DataAccess.Models.Suplier selectedSuplier)
			{
				try
				{
					suplierObject.detete(selectedSuplier);
					Load();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi xóa nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
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
						var worksheet = workbook.Worksheets.Add("Suplier Info");

						// Add custom header row
						worksheet.Cell(1, 1).Value = "Danh sách nhà cung cấp";
						worksheet.Range("A1:H1").Merge().Style.Font.SetBold().Font.FontSize = 16;

						// Adding headers from DataGrid
						for (int i = 0; i < dgSupplier.Columns.Count; i++)
						{
							worksheet.Cell(2, i + 1).Value = dgSupplier.Columns[i].Header.ToString();
						}

						// Adding the rows
						var itemsSource = dgSupplier.ItemsSource as IEnumerable<DataAccess.Models.Suplier>;
						if (itemsSource != null)
						{
							int row = 3; // Start after the header row
							foreach (var item in itemsSource)
							{
								worksheet.Cell(row, 1).Value = item.Id;
								worksheet.Cell(row, 2).Value = item.DisplayName;
								worksheet.Cell(row, 3).Value = item.Address;
								worksheet.Cell(row, 4).Value = item.Phone;
								worksheet.Cell(row, 5).Value = item.Email;
								worksheet.Cell(row, 6).Value = item.MoreInfo;
								worksheet.Cell(row, 7).Value = item.Status;

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
