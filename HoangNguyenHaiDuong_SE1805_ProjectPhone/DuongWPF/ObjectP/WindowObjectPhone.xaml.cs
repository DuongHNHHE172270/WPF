using BusinessObjects;
using ClosedXML.Excel;
using DuongWPF.ObjectP;
using DuongWPF.Suplier;
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

namespace DuongWPF.NewFolder
{
	/// <summary>
	/// Interaction logic for WindowObjectPhone.xaml
	/// </summary>
	public partial class WindowObjectPhone : Window
	{
		private readonly ObjectPhone objectPhone;
		public WindowObjectPhone()
		{
			InitializeComponent();
			objectPhone = new ObjectPhone();
			Loaded += WindowObjectPhone_Loaded;
		}

		private void WindowObjectPhone_Loaded(object sender, RoutedEventArgs e)
		{
			Load();
		}

		public void Load()
		{
			dgObject.ItemsSource = objectPhone.GetAllObject();
		}

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchText = SearchTextBox.Text.Trim();
			if (!string.IsNullOrEmpty(searchText))
			{
				try
				{
					dgObject.ItemsSource = objectPhone.SearchByName(searchText);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi tìm kiếm vật tư: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			Load();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			WindowAddPhonePopupxaml windowAddPhonePopupxaml = new WindowAddPhonePopupxaml();
			windowAddPhonePopupxaml.Owner = this;
			windowAddPhonePopupxaml.ShowDialog();
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowAdmin windowAdmin = new WindowAdmin();
			windowAdmin.Show();
			this.Close();
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (dgObject.SelectedItem is DataAccess.Models.Object obj)
			{
				WindowUpdateObPhone windowUpdatePopup = new WindowUpdateObPhone(obj);
				windowUpdatePopup.Owner = this;
				windowUpdatePopup.ShowDialog();
			}

		}

		private void btnDelete_Click(object sender, RoutedEventArgs e)
		{
			if (dgObject.SelectedItem is DataAccess.Models.Object selectedObject)
			{
				try
				{
					objectPhone.DeleteObject(selectedObject);

					MessageBox.Show("Xóa vật tư thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
					Load();
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Lỗi khi xóa vật tư: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn vật tư cần xóa.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
						var worksheet = workbook.Worksheets.Add("Object Phone Info");

						// Add custom header row
						worksheet.Cell(1, 1).Value = "Tất cả vật tư điện thoại";
						worksheet.Range("A1:F1").Merge().Style.Font.SetBold().Font.FontSize = 16;

						// Adding headers from DataGrid
						for (int i = 0; i < dgObject.Columns.Count; i++)
						{
							worksheet.Cell(2, i + 1).Value = dgObject.Columns[i].Header.ToString();
						}

						// Adding the rows
						var itemsSource = dgObject.ItemsSource as IEnumerable<dynamic>;
						if (itemsSource != null)
						{
							int row = 3; // Start after the header row
							foreach (var item in itemsSource)
							{
								for (int col = 0; col < dgObject.Columns.Count; col++)
								{
									var cellValue = item.GetType().GetProperty(dgObject.Columns[col].SortMemberPath)?.GetValue(item, null);
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
