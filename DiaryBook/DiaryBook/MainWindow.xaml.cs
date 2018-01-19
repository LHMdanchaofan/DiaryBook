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

namespace DiaryBook
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new MainModel();
            this.DataContext = _Model;
        }
        private MainModel _Model;

        private void OnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Submit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void newDiary(object sender, RoutedEventArgs e)
        {
            try
            {
                newDiary newdiary = new newDiary();
                newdiary.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updataDiary(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Updata();
                successModel successModel = new successModel();
                successModel.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void delateDiary(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Delete();
                successModel successModel = new successModel();
                successModel.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ComboBoxChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                //_Model.Submit();
                _Model.ChangeComBox(((ComboBox)sender).SelectedItem.ToString());                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void about(object sender, RoutedEventArgs e)
        {
            try
            {
                AboutwWindow a = new AboutwWindow();
                a.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListBoxChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.ShowContent(((ListBox)sender).SelectedIndex);
                // string str=(((ListBox)sender).SelectedItem.ToString());
                 //string str1 = ((ListBox)sender).SelectedIndex.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
