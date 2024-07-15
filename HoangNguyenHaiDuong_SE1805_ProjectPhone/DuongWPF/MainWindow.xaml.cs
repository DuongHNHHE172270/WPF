using BusinessObjects;
using DuongWPF.Customer;
using DuongWPF.InputInfo;
using DuongWPF.Login;
using DuongWPF.NewFolder;
using DuongWPF.OutputObject;
using DuongWPF.Suplier;
using DuongWPF.UserManager;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DuongWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly ObjectPhone objectPhone1;
		public MainWindow()
		{
			InitializeComponent();
			objectPhone1 = new ObjectPhone();
			UpdateTotalCounts();
			cbObject.SelectionChanged += CbObject_SelectionChanged;
		}
		private void CbObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateTotalCounts();
		}

		private void UpdateTotalCounts()
		{
			string id = cbObject.SelectedValue as string;
			txtLuongNhap.Text = objectPhone1.GetTotalInputInfoCount(id).ToString();
			txtLuongXuat.Text = objectPhone1.GetTotalOutputInfoCount(id).ToString();
			txtTonKho.Text = objectPhone1.GetTotalInventory(id).ToString();
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
		void LoadObject()
		{
			var obj = objectPhone1.GetAllObject();
			cbObject.ItemsSource = obj;
			cbObject.DisplayMemberPath = "DisplayName";
			cbObject.SelectedValuePath = "Id";
			cbObject.SelectedIndex = -1;
		}

		private void Load_Click(object sender, RoutedEventArgs e)
		{
			cbObject.SelectedIndex = -1;
		}

		private void Logout_Click(object sender, RoutedEventArgs e)
		{
			WindowLogin windowLogin = new WindowLogin();
			windowLogin.Show();
			this.Close();
        }
    }
}