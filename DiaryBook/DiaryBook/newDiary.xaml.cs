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
    /// newDiary.xaml 的交互逻辑
    /// </summary>
    public partial class newDiary : Window
    {
        private newDiaryModel _Model;
        public newDiary()
        {
            InitializeComponent();
            _Model = new newDiaryModel();
            this.DataContext = _Model;
        }
        public void insert(object sender, RoutedEventArgs e)
        {
            try
            {
                string newtime = (timebox).Text;
                string newtitle = (titlebox).Text;
                string newweather = (weatherbox).Text;
                string newcontent = (contentbox).Text;
                if(newtime.Equals("") || newtitle.Equals("") || newweather.Equals("") || newcontent.Equals(""))
                {
                    nullModel nullmodel = new nullModel();
                    nullmodel.Show();
                }
                else
                {
                    Boolean result=_Model.Insert(newtitle, newcontent, newtime, newweather);
                    if (result)
                    {                                             
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        successModel successmodel = new successModel();
                        successmodel.Show();
                        this.Close();
                    }
                    else
                    {
                        failModel failmodel = new failModel();
                        failmodel.Show();
                    }
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
