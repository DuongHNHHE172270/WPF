using BusinessObjects;
using DataAccess.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using DuongWPF.Customer;
using DuongWPF.InputInfo;
using DuongWPF.Login;
using DuongWPF.NewFolder;
using DuongWPF.OutputObject;
using DuongWPF.Suplier;
using DuongWPF.UserManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DuongWPF
{
	/// <summary>
	/// Interaction logic for WindowAdmin.xaml
	/// </summary>
	public partial class WindowAdmin : Window
	{
		private readonly ObjectPhone objectPhone1;
		public WindowAdmin()
		{
			InitializeComponent();
			objectPhone1 = new ObjectPhone();
			Loaded += WindowAdmin_Loaded;
		}

		private void WindowAdmin_Loaded(object sender, RoutedEventArgs e)
		{
			LoadObject();
			UpdateTotalCounts();
			LoadDetail(-1);
			cbObject.SelectionChanged += CbObject_SelectionChanged;
		}

		private void CbObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateTotalCounts();
		}

		private void UpdateTotalCounts()
		{
			if (cbObject.SelectedValue != null && int.TryParse(cbObject.SelectedValue.ToString(), out int id))
			{
				txtLuongNhap.Text = objectPhone1.GetTotalInputInfoCount(id).ToString();
				txtLuongXuat.Text = objectPhone1.GetTotalOutputInfoCount(id).ToString();
				txtTonKho.Text = objectPhone1.GetTotalInventory(id).ToString();
				LoadDetail(id);
			}
			else
			{
				txtLuongNhap.Text = objectPhone1.GetTotalInputInfoCount(-1).ToString();
				txtLuongXuat.Text = objectPhone1.GetTotalOutputInfoCount(-1).ToString();
				txtTonKho.Text = objectPhone1.GetTotalInventory(-1).ToString();
				LoadDetail(-1);
			}
		}


		private void Input_Click(object sender, RoutedEventArgs e)
		{
			WindowInput windowInput = new WindowInput();
			windowInput.Show();
			this.Close();
		}

		private void Output_Click(object sender, RoutedEventArgs e)
		{
			WindowOutput windowOutput = new WindowOutput();
			windowOutput.Show();
			this.Close();
		}

		private void Object_Click(object sender, RoutedEventArgs e)
		{
			WindowObjectPhone objectPhone = new WindowObjectPhone();
			objectPhone.Show();
			this.Close();
		}

		private void Supier_Click(object sender, RoutedEventArgs e)
		{
			WindowSuplier windowSuplier = new WindowSuplier();
			windowSuplier.Show();
			this.Close();
		}

		private void Customer_Click(object sender, RoutedEventArgs e)
		{
			WindowCustomer windowCustomer = new WindowCustomer();
			windowCustomer.Show();
			this.Close();
		}

		private void User_Click(object sender, RoutedEventArgs e)
		{
			WindowUser windowUser = new WindowUser();
			windowUser.Show();
			this.Close();
		}

		void LoadObject()
		{
			var obj = objectPhone1.GetAllObject();
			cbObject.ItemsSource = obj;
			cbObject.DisplayMemberPath = "DisplayName";
			cbObject.SelectedValuePath = "Id";
			cbObject.SelectedIndex = -1; 
		}
		private void LoadDetail(int id)
		{
			dgDetail.ItemsSource = objectPhone1.GetAllObjDetailByObjId(id);
		}
		private void Load_Click(object sender, RoutedEventArgs e)
		{
			cbObject.SelectedIndex = -1;
			LoadDetail(-1);
		}

		private void Logout_Click(object sender, RoutedEventArgs e)
		{
			WindowLogin windowLogin = new WindowLogin();
			windowLogin.Show();
			this.Close();
        }
    }
}
