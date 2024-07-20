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
				string name = txtName.Text.Trim();
				int? idSuplier = (int?)cbSuplier.SelectedValue;
				string capacity = txtNameDetail.Text.Trim();

				if (string.IsNullOrEmpty(name) || idSuplier == null || string.IsNullOrWhiteSpace(capacity))
				{
					MessageBox.Show("Vui lòng nhập đầy đủ thông tin để thêm vật tư.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				var existingObject = objectPhone.GetAllObject().FirstOrDefault(o => o.DisplayName.ToLower() == name.ToLower() && o.IdSuplier == idSuplier);

				if (existingObject != null)
				{
					var existingDetail = existingObject.ObjectDetails.FirstOrDefault(od => od.Capacity.ToLower() == capacity.ToLower());

					if (existingDetail != null)
					{
						MessageBox.Show("Vật tư với tên và dung lượng này đã tồn tại.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
						return;
					}

					ObjectDetail newObjectDetail = new ObjectDetail
					{
						IdObject = existingObject.Id,
						Capacity = capacity,
						Count = 0
					};

					existingObject.ObjectDetails.Add(newObjectDetail);
					objectPhone.UpdateObject(existingObject);
				}
				else
				{
					// Tạo vật tư mới nếu vật tư chưa tồn tại
					DataAccess.Models.Object newObject = new DataAccess.Models.Object
					{
						DisplayName = name,
						IdSuplier = idSuplier.Value,
						Status = "1",
						ObjectDetails = new List<ObjectDetail>
						{
							new ObjectDetail
							{
								Capacity = capacity,
								Count = 0
							}
						},
					};

					objectPhone.AddObject(newObject);
				}

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
