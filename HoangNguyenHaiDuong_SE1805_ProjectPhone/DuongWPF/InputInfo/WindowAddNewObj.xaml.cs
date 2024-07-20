using BusinessObjects;
using DataAccess.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using DuongWPF.NewFolder;
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
		private readonly LoginObject loginObject;
		public WindowAddNewObj()
		{
			InitializeComponent();
			_inputObject = new InputObject();
			objectPhone = new ObjectPhone();
			loginObject = new LoginObject();
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
			txtCount.Text = null;
			txtObjectName.Text = null;
			txtInputPrice.Text = null;
			cbSuplier.SelectedIndex = -1;
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var name = txtObjectName.Text;
				var countText = int.Parse(txtCount.Text);
				var inputPriceText = double.Parse( txtInputPrice.Text);
				var suplierId = (int?)cbSuplier.SelectedValue;
				var capacity = txtCapacity.Text;

				if (string.IsNullOrWhiteSpace(name) || countText == 0 ||
					inputPriceText == 0 || suplierId == null)
				{
					MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
					ResetForm();
					return;
				}

				var exitsObject = objectPhone.GetAllObject().
								  FirstOrDefault(o => o.DisplayName.ToLower() == name.ToLower() && o.IdSuplierNavigation.Id == suplierId);

			
				if (exitsObject != null) {

					var existingDetail = exitsObject.ObjectDetails.FirstOrDefault(od => od.Capacity.ToLower() == capacity.ToLower());
					if (existingDetail != null) 
					{
						existingDetail.Count += countText;
						objectPhone.UpdateObject(exitsObject);
						AddNewInput(exitsObject.Id, countText, inputPriceText, capacity);
						
						Close();
					}
					else
					{
						ObjectDetail objectDetail = new ObjectDetail
						{
							IdObject = exitsObject.Id,
							Capacity = capacity,
							Count = countText,
						};
						exitsObject.ObjectDetails.Add(objectDetail);
						objectPhone.UpdateObject(exitsObject);

						AddNewInput(exitsObject.Id, countText, inputPriceText, capacity);
						
						Close();
					}					
				}
				else
				{
					DataAccess.Models.Object newObject = new DataAccess.Models.Object
					{
						DisplayName = name,
						IdSuplier = suplierId.Value,
						Status = "1",
						ObjectDetails = new List<ObjectDetail>
						{
							new ObjectDetail
							{
								Capacity = capacity,
								Count = countText,
							}
						},
					};

					objectPhone.AddObject(newObject);

					AddNewInput(newObject.Id, countText, inputPriceText, capacity);
				}

				MessageBox.Show("Thêm phiếu thành công!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
				Close();

				if (Owner is WindowInput parentWindow)
				{
					parentWindow.Load();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi khi thêm phiếu nhập: " + ex.Message);
			}
		}

		private void AddNewInput(int objectId, int count, double price, string capacity)
		{
			InputObject inputObject = new InputObject();
			var inputInfo1 = new DataAccess.Models.InputInfo
			{
				IdObject = objectId,
				Count = count,
				InputPrice = price,
				IdUser = loginObject.GetUser().Id,
				Capacity = capacity,
				IdInputNavigation = new Input
				{
					DateInput = DateTime.Now
				},
			};
			
			inputObject.AddInput(inputInfo1);
		}

		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}

