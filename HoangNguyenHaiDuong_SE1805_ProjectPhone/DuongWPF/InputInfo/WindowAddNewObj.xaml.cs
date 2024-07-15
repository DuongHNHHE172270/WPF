using BusinessObjects;
using DataAccess.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
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

namespace DuongWPF.InputInfo
{
	/// <summary>
	/// Interaction logic for WindowAddNewObj.xaml
	/// </summary>
	public partial class WindowAddNewObj : Window
	{
		private readonly InputObject _inputObject;
		private readonly ObjectPhone objectPhone;
		public WindowAddNewObj()
		{
			InitializeComponent();
			_inputObject = new InputObject();
			objectPhone = new ObjectPhone();
			LoadSupliers();
		}

		private void LoadSupliers()
		{
			try
			{
				using var context = new QuanLyKhoDienThoaiContext();
				cbSuplier.ItemsSource = context.Supliers.ToList();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi tải nhà cung cấp: " + ex.Message);
			}
		}

		void ResetForm()
		{
			txtIdInput.Text = null;
			txtIdObject.Text = null;
			txtCount.Text = null;
			txtObjectName.Text = null;
			txtOutputPrice.Text = null;
			txtInputPrice.Text = null;
			cbSuplier.SelectedIndex = -1;
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var idInput = txtIdInput.Text;
				var idObject = txtIdObject.Text.Trim();
				var objectName = txtObjectName.Text;
				var countText = txtCount.Text;
				var inputPriceText = txtInputPrice.Text;
				var outputPriceText = txtOutputPrice.Text;
				var suplierId = (int?)cbSuplier.SelectedValue;

				if (string.IsNullOrWhiteSpace(idInput) || string.IsNullOrWhiteSpace(idObject) ||
					string.IsNullOrWhiteSpace(objectName) || string.IsNullOrWhiteSpace(countText) ||
					string.IsNullOrWhiteSpace(inputPriceText) || string.IsNullOrWhiteSpace(outputPriceText) ||
					suplierId == null)
				{
					MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
					ResetForm();
					return;
				}

				if (_inputObject.IsIdInputExists(idInput))
				{
					MessageBox.Show("ID Phiếu đã tồn tại!");
					ResetForm();
					return;
				}
				var existingObject = objectPhone.GetAllObject().FirstOrDefault(o => o.Id == idObject);
				if (existingObject != null)
				{
					MessageBox.Show("Id vật tư đã tồn tại. Vui lòng chọn Id khác.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				var existingObjectWithNameAndSupplier = objectPhone.GetAllObject().FirstOrDefault(o => o.DisplayName.ToLower() == objectName.ToLower() && o.IdSuplier == suplierId);
				if (existingObjectWithNameAndSupplier != null)
				{
					MessageBox.Show("Vật tư với tên và nhà cung cấp đã tồn tại. Vui lòng kiểm tra lại.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (!int.TryParse(countText, out int count) || count <= 0)
				{
					MessageBox.Show("Số lượng phải là số lớn hơn 0!");
					ResetForm();
					return;
				}

				if (!double.TryParse(inputPriceText, out double inputPrice) || inputPrice <= 0)
				{
					MessageBox.Show("Giá nhập phải là số lớn hơn 0!");
					ResetForm();
					return;
				}

				if (!double.TryParse(outputPriceText, out double outputPrice) || outputPrice <= 0)
				{
					MessageBox.Show("Giá xuất phải là số lớn hơn 0!");
					ResetForm();
					return;
				}
				var inputInfo = new DataAccess.Models.InputInfo
				{
					Id = txtIdInput.Text,
					IdObject = idObject,
					IdInput = idInput,
					Count = int.Parse(txtCount.Text),
					InputPrice = double.Parse(txtInputPrice.Text),
					OutputPrice = double.Parse(txtOutputPrice.Text),
					IdUser = LoginObject.accountUser.Id,
					IdInputNavigation = new Input
					{
						Id = txtIdInput.Text,
						DateInput = DateTime.Now
					},
					IdObjectNavigation = new DataAccess.Models.Object
					{
						Id = txtIdObject.Text,
						IdSuplier = (int)cbSuplier.SelectedValue,
						Status = "1",
						DisplayName = txtObjectName.Text,
					}
				};

				_inputObject.AddInput(inputInfo);

				MessageBox.Show("Đã thêm phiếu nhập thành công!");
				this.Close();

			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi thêm phiếu nhập: " + ex.Message);
			}
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}

