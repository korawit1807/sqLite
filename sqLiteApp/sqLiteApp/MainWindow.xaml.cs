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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sqLiteApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            
            InitializeComponent();
            DataAccess.InitializeDatabase();
            
        }

        private void shBtn_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.addData(idTxt.Text, nameTxt.Text, lastNameTxt.Text, emailTxt.Text);
            string getdata = " ";
            foreach (string sh in DataAccess.getData())
            {
                getdata = getdata + sh + "\n";
            }
            MessageBox.Show(getdata);
        }
    }
}
