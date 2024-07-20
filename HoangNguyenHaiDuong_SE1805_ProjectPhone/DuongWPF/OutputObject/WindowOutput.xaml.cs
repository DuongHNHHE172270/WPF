using BusinessObjects;
using ClosedXML.Excel;
using DataAccess.Models;
using DocumentFormat.OpenXml.Wordprocessing;
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

namespace DuongWPF.OutputObject
{
	/// <summary>
	/// Interaction logic for WindowOutput.xaml
	/// </summary>
	public partial class WindowOutput : Window
	{
		private readonly OutObject outObject;
		private readonly CustomerObject customerObject;
		private readonly LoginObject loginObject;
		private readonly ObjectPhone objectPhone;
		public WindowOutput()
		{
			InitializeComponent();
			outObject = new OutObject();
			customerObject = new CustomerObject();
			loginObject = new LoginObject();
			objectPhone = new ObjectPhone();
			LoadOutputInfos();
		}

		public void LoadOutputInfos()
		{
			try
			{
				var outputList = outObject.GetAllOutputs();
				dgOuputInfo.ItemsSource = outputList;
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
				var outputList = outObject.GetAllOutputs().Where(o => o.ObjectName.ToLower().Contains(searchTerm.ToLower())).ToList();
				dgOuputInfo.ItemsSource = outputList;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
			}
		}


		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			LoadOutputInfos();
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			WindowAddOuputPopup windowAddOuputPopup = new WindowAddOuputPopup();
			windowAddOuputPopup.Owner = this;
			windowAddOuputPopup.ShowDialog();
		}

		private void btnReturn_Click(object sender, RoutedEventArgs e)
		{
			WindowAdmin windowAdmin = new WindowAdmin();
			windowAdmin.Show();
			this.Close();
		}

		private int outId;
		private void Accept_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (dgOuputInfo.SelectedItem is OutputInfoViewModel outputInfoViewModel)
				{
					outId = outputInfoViewModel.IdOutputInfo;
					var outputInfo1 = outObject.GetById(outId);

					if (outputInfo1 != null)
					{
						outputInfo1.Status = "accept";
						outputInfo1.IdUser = loginObject.GetUser().Id;


						outObject.UpdateOutInfo(outputInfo1);
					

						DataAccess.Models.Customer customer = customerObject.GetCusById(outputInfo1.IdCustomer);
						DataAccess.Models.Object obj = objectPhone.GetObjById(outputInfo1.IdObject);

						var exitsObjectDetail = objectPhone.GetAllObjDetail()
													.FirstOrDefault(o => o.Capacity.ToLower() == outputInfo1.Capacity.ToLower() && o.IdObject == outputInfo1.IdObject);

						if (exitsObjectDetail != null)
						{
							exitsObjectDetail.Count -= (int)outputInfo1.Count;

							objectPhone.UpdateObjDetail(exitsObjectDetail);
						}
						BillHistory bill = new BillHistory()
						{
							IdOutputInfo = outputInfo1.Id,
							IdCustomer = customer.Id,
							NameCustomer = customer.DisplayName,
							Email = customer.Email,
							Phone = customer.Phone,
							ObjectName = obj.DisplayName,
							Capacity = outputInfo1.Capacity,
							Quantity = (int)outputInfo1.Count,
							DateBill = DateTime.Now,
						};

						outObject.AddBill(bill);
						MessageBox.Show("Thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
						LoadOutputInfos();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (dgOuputInfo.SelectedItem is OutputInfoViewModel outputInfoViewModel)
				{
					outId = outputInfoViewModel.IdOutputInfo;
					var outputInfo1 = outObject.GetById(outId);

					if (outputInfo1 != null)
					{
						outputInfo1.Status = "cancel";
						outputInfo1.IdUser = loginObject.GetUser().Id;
						outObject.UpdateOutInfo(outputInfo1);
					}
					MessageBox.Show("Thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
					LoadOutputInfos();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}


		}

		private void allP_Click(object sender, RoutedEventArgs e)
		{
			WindowAllOuputInfo windowAllOuputInfo = new WindowAllOuputInfo();
			windowAllOuputInfo.Show();
			this.Close();
		}
	}
}
