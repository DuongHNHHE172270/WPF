using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using BusinessObjects;
using DataAccess.DAL;
using DataAccess.Models;
using DuongWPF.Customer;

namespace DuongWPF.InputInfo
{
	public partial class WindowAddInputPopup : Window
	{
		private readonly InputObject _inputObject;
		private readonly ObjectPhone objectPhone;
		public WindowAddInputPopup()
		{
			InitializeComponent();
			_inputObject = new InputObject();
			objectPhone = new ObjectPhone();
			Loaded += WindowAddInputPopup_Loaded;
		}

		private void WindowAddInputPopup_Loaded(object sender, RoutedEventArgs e)
		{
			LoadObject();
		}
		void ResetForm() {
			txtIdInput.Text = null;
			txtCount.Text = null;
			txtOutputPrice.Text = null;
			txtInputPrice.Text = null;
			cbObject.SelectedIndex = -1;
		}

		void LoadObject()
		{
			var object1 = objectPhone.GetAllObject();
			cbObject.ItemsSource = object1;
			cbObject.DisplayMemberPath = "DisplayName";
			cbObject.SelectedValuePath = "Id";
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var idInput = txtIdInput.Text;
				var countText = txtCount.Text;
				var inputPriceText = txtInputPrice.Text;
				var outputPriceText = txtOutputPrice.Text;

				if (string.IsNullOrWhiteSpace(idInput) 
					||string.IsNullOrWhiteSpace(countText) ||
					string.IsNullOrWhiteSpace(inputPriceText) || string.IsNullOrWhiteSpace(outputPriceText))
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
					IdObject = cbObject.SelectedValue.ToString(),  
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
