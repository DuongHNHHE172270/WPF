using BusinessObjects;
using DuongWPF.NewFolder;
using DuongWPF.Suplier;
using System;
using System.Windows;

namespace DuongWPF.ObjectP
{
	/// <summary>
	/// Interaction logic for WindowUpdateObPhone.xaml
	/// </summary>
	public partial class WindowUpdateObPhone : Window
	{
		private readonly ObjectPhone objectPhone;
		private DataAccess.Models.Object selectedObject;

		public WindowUpdateObPhone(DataAccess.Models.Object obj)
		{
			InitializeComponent();
			objectPhone = new ObjectPhone();
			selectedObject = obj;
			DisplayObjectInfo();
		}

		private void DisplayObjectInfo()
		{
			if (selectedObject != null)
			{
				txtId.Text = selectedObject.Id.ToString();
				txtName.Text = selectedObject.DisplayName;
				cbSuplier.DisplayMemberPath = selectedObject.IdSuplierNavigation.DisplayName;
				if (rbActive.IsChecked == true)
				{
					selectedObject.Status = "1";
				}
				else
				{
					selectedObject.Status = "0";
				}
			}
		}

		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				selectedObject.Status = rbActive.IsChecked == true ? "1" : "0";
				objectPhone.UpdateObj(selectedObject);
				MessageBox.Show("Cập nhật trạng thái vật tư thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
				this.Close();


				if (Owner is WindowObjectPhone suplier)
				{
					suplier.Load();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Lỗi khi cập nhật trạng thái vật tư: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
