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
			cbObject.SelectionChanged += CbObject_SelectionChanged;
		}

		private void CbObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(cbObject.SelectedValue != null)
			{
				int objId = (int)cbObject.SelectedValue;
				LoadCapacity(objId);
			}
		}

		private void WindowAddOuputPopup_Loaded(object sender, RoutedEventArgs e)
		{
			LoadObject();
		}

		void LoadObject()
		{
			var object1 = objectPhone.GetAllActiveObject();
			cbObject.ItemsSource= object1;
			cbObject.DisplayMemberPath = "DisplayName";
			cbObject.SelectedValuePath = "Id";
		}

		void LoadCapacity(int id)
		{
			cbCapa.ItemsSource = objectPhone.GetOrderDetaiById(id);

			cbCapa.DisplayMemberPath = "Capacity";
			cbCapa.SelectedValuePath = "Id";
		}
	
		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int capId = (int)cbCapa.SelectedValue;
				if (cbObject.SelectedValue == null ||
					string.IsNullOrEmpty(txtCount.Text))
				{
					MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
					return;
				}

				var selectedCapacityItem = (ObjectDetail)cbCapa.SelectedItem;
				string capacity = selectedCapacityItem.Capacity;

				var output = new OutputInfo
				{
					IdObject = (int)cbObject.SelectedValue,
					Count = int.Parse(txtCount.Text),
					IdCustomer = loginObject.GetCustomer().Id,
					IdUser = null,
					Capacity = capacity,
					IdOutputNavigation = new Output
					{
						DateOutput = DateTime.Now
					},
				};

				outObject.AddOutput(output, capacity);
				MessageBox.Show("Yêu cầu nhận vật tư thành công! Hãy chờ được xử lý", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
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
