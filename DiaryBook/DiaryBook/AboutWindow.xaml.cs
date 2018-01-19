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

namespace DiaryBook
{
    /// <summary>
    /// about.xaml 的交互逻辑
    /// </summary>
    public partial class AboutwWindow : Window
    {
        public AboutwWindow()
        {
            InitializeComponent();
            _Model = new aboutModel();
            this.DataContext = _Model;
        }
        private aboutModel _Model;
        private void close(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
