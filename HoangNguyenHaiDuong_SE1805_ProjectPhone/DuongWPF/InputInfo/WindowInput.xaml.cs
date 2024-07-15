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

namespace DuongWPF.InputInfo
{
    /// <summary>
    /// Interaction logic for WindowInput.xaml
    /// </summary>
    public partial class WindowInput : Window
    {
        private readonly InputObject inputObject;
        public WindowInput()
        {
            InitializeComponent();
            inputObject = new InputObject();
			Loaded += WindowInput_Loaded;
        }

		private void WindowInput_Loaded(object sender, RoutedEventArgs e)
		{
			Load();
		}

        public void Load()
        {
            dgInputInfo.ItemsSource = inputObject.GetAll();
        }

		private void btnSearch_Click(object sender, RoutedEventArgs e)
		{
			string searchTerm = SearchTextBox.Text.Trim();

			try
			{
				var inputList = inputObject.GetAll().Where(i => i.ObjectName.ToLower().Contains(searchTerm.ToLower())).ToList();
				dgInputInfo.ItemsSource = inputList;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
			}
		}

		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			Load();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			WindowAdd windowAdd = new WindowAdd();
			windowAdd.Owner = this;
			windowAdd.ShowDialog();
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
						var worksheet = workbook.Worksheets.Add("Input Info");

						// Add custom header row
						worksheet.Cell(1, 1).Value = "Tất cả phiếu nhập kho";
						worksheet.Range("A1:H1").Merge().Style.Font.SetBold().Font.FontSize = 16; // Example: Merge cells A1 to H1, set bold font and font size

						// Adding headers from DataGrid
						for (int i = 0; i < dgInputInfo.Columns.Count; i++)
						{
							worksheet.Cell(2, i + 1).Value = dgInputInfo.Columns[i].Header.ToString();
						}

						// Adding the rows
						var itemsSource = dgInputInfo.ItemsSource as IEnumerable<dynamic>;
						if (itemsSource != null)
						{
							int row = 3; // Start after the header row
							foreach (var item in itemsSource)
							{
								for (int col = 0; col < dgInputInfo.Columns.Count; col++)
								{
									var cellValue = item.GetType().GetProperty(dgInputInfo.Columns[col].SortMemberPath)?.GetValue(item, null);
									worksheet.Cell(row, col + 1).Value = cellValue?.ToString() ?? string.Empty;
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
