using DataAccess.Models;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Windows;
using DuongWPF.Suplier;
using DuongWPF.NewFolder;

namespace DuongWPF.ObjectP
{
	public partial class WindowAddPhonePopupxaml : Window
	{
		private readonly ObjectPhone objectPhone;

		public WindowAddPhonePopupxaml()
		{
			InitializeComponent();
			objectPhone = new ObjectPhone();
			LoadSupliers();
		}

		private void LoadSupliers()
		{
			var supliers = new SuplierObject().GetAllActiveSupliers();
			cbSuplier.ItemsSource = supliers;
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				string id = txtId.Text.Trim();
				string name = txtName.Text.Trim();
				int? idSuplier = (int?)cbSuplier.SelectedValue; 

				if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || idSuplier == null)
				{
					MessageBox.Show("Vui lòng nhập đầy đủ thông tin để thêm vật tư.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				var existingObject = objectPhone.GetAllObject().FirstOrDefault(o => o.Id == id);
				if (existingObject != null)
				{
					MessageBox.Show("Id vật tư đã tồn tại. Vui lòng chọn Id khác.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				var existingObjectWithNameAndSupplier = objectPhone.GetAllObject().FirstOrDefault(o => o.DisplayName.ToLower() == name.ToLower() && o.IdSuplier == idSuplier);
				if (existingObjectWithNameAndSupplier != null)
				{
					MessageBox.Show("Vật tư với tên và nhà cung cấp đã tồn tại. Vui lòng kiểm tra lại.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				string status = rbActive.IsChecked == true ? "1" : "0";

				DataAccess.Models.Object newObject = new DataAccess.Models.Object
				{
					Id = id,
					DisplayName = name,
					IdSuplier = idSuplier.Value,
					Status = status
				};

				objectPhone.AddObject(newObject);

				MessageBox.Show("Thêm vật tư thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
				Close();

				if (Owner is WindowObjectPhone parentWindow)
				{
					parentWindow.Load();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi thêm vật tư: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
