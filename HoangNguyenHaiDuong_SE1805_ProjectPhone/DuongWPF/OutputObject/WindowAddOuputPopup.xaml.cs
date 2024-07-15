using BusinessObjects;
using DataAccess.Models;
using DuongWPF.InputInfo;
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
	/// Interaction logic for WindowAddOuputPopup.xaml
	/// </summary>
	public partial class WindowAddOuputPopup : Window
	{
		private readonly OutObject outObject;
		private readonly LoginObject loginObject;
		private readonly CustomerObject customerObject;
		private readonly ObjectPhone objectPhone;
		public WindowAddOuputPopup()
		{
			InitializeComponent();
			outObject = new OutObject();
			loginObject = new LoginObject();
			customerObject = new CustomerObject();
			objectPhone = new ObjectPhone();
			Loaded += WindowAddOuputPopup_Loaded;
		}

		private void WindowAddOuputPopup_Loaded(object sender, RoutedEventArgs e)
		{
			LoadCustomers();
			LoadObject();
		}

		void LoadObject()
		{
			var object1 = objectPhone.GetAllActiveObject();
			cbObject.ItemsSource= object1;
			cbObject.DisplayMemberPath = "DisplayName";
			cbObject.SelectedValuePath = "Id";
		}
		 void LoadCustomers()
		{
			var customers = customerObject.GetCustomers();
			cbCustomer.ItemsSource = customers;
			cbCustomer.DisplayMemberPath = "DisplayName";
			cbCustomer.SelectedValuePath ="Id";
		}
	
		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var idCustomer = cbCustomer.SelectedValue.ToString();
				if (string.IsNullOrEmpty(txtIdInput.Text) ||
					cbObject.SelectedValue == null ||
					string.IsNullOrEmpty(txtCount.Text) ||
					cbCustomer.SelectedValue == null)
				{
					MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
					return;
				}

				if (outObject.IsOutputIdExists(txtIdInput.Text))
				{
					MessageBox.Show("ID Phiếu đã tồn tại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
					return;
				}
				var output = new OutputInfo
				{
					IdOutputInfo = txtIdInput.Text,
					IdObject = cbObject.SelectedValue.ToString(),
					Count = int.Parse(txtCount.Text),
					IdCustomer = int.Parse(idCustomer),
					IdUser = LoginObject.accountUser.Id,
					IdNavigation = new Output
					{
						Id = txtIdInput.Text,
						DateOutput = DateTime.Now
					},
				};

				outObject.AddOutput(output);
				MessageBox.Show("Thêm phiếu xuất thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
				this.Close();


				if (Owner is WindowOutput parentWindow)
				{
					parentWindow.LoadOutputInfos();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
