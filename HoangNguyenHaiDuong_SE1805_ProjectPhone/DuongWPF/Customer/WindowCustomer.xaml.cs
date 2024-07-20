using BusinessObjects;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuongWPF.Customer
{
	/// <summary>
	/// Interaction logic for WindowCustomer.xaml
	/// </summary>
	public partial class WindowCustomer : Window
	{
		private readonly CustomerObject customerObject;
		public WindowCustomer()
		{
			InitializeComponent();
			customerObject = new CustomerObject();
			Loaded += WindowCustomer_Loaded;
		}

		private void WindowCustomer_Loaded(object sender, RoutedEventArgs e)
		{
			Load();
		}

		public void Load()
		{
			dgCustomer.ItemsSource = customerObject.GetCustomers();
		}

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			dgCustomer.ItemsSource = customerObject.Search(SearchTextBox.Text);
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			Load();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			WindowAddPopup windowAddPopup = new WindowAddPopup();
			windowAddPopup.Owner = this;
			windowAddPopup.ShowDialog();
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowAdmin windowAdmin = new WindowAdmin();
			windowAdmin.Show();
			this.Close();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (dgCustomer.SelectedItem is DataAccess.Models.Customer customer)
			{
				try
				{

					customer.Status = customer.Status == "1" ? "0" : "1";

					customerObject.UpdateCustomer(customer);

					Load();

					MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn khách hàng để cập nhật trạng thái.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
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
						var worksheet = workbook.Worksheets.Add("Customer Info");

						// Add custom header row
						worksheet.Cell(1, 1).Value = "Thông tin khách hàng";
						worksheet.Range("A1:F1").Merge().Style.Font.SetBold().Font.FontSize = 16;

						// Adding headers from DataGrid
						for (int i = 0; i < dgCustomer.Columns.Count; i++)
						{
							worksheet.Cell(2, i + 1).Value = dgCustomer.Columns[i].Header.ToString();
						}

						// Adding the rows
						var itemsSource = dgCustomer.ItemsSource as IEnumerable<dynamic>;
						if (itemsSource != null)
						{
							int row = 3; // Start after the header row
							foreach (var item in itemsSource)
							{
								for (int col = 0; col < dgCustomer.Columns.Count; col++)
								{
									var cellValue = item.GetType().GetProperty(dgCustomer.Columns[col].SortMemberPath)?.GetValue(item, null);
									worksheet.Cell(row, col + 1).Value = cellValue ?? string.Empty;
								}
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
