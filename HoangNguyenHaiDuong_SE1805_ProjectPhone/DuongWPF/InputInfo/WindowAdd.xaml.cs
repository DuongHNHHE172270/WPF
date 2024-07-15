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
    /// Interaction logic for WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        public WindowAdd()
        {
            InitializeComponent();
        }

		private void AddNewObject_Click(object sender, RoutedEventArgs e)
		{
            WindowAddNewObj windowAddNewObj = new WindowAddNewObj();
            windowAddNewObj.ShowDialog();
            
        }

		private void AddObject_Click(object sender, RoutedEventArgs e)
		{
            WindowAddInputPopup windowAddInputPopup = new WindowAddInputPopup();
            windowAddInputPopup.ShowDialog();
            
		}

		private void Return_Click(object sender, RoutedEventArgs e)
		{
           
            this.Close();

			if (Owner is WindowInput parentWindow)
			{
				parentWindow.Load();
			}
		}
	}
}
