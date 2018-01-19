using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DiaryBook
{
    class newDiaryModel : INotifyPropertyChanged
    {
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DiaryBook;Integrated Security=True;";
        public newDiaryModel()
        {
            DataContext = new DiaryDataContext(ConnectionString);
        }
        public  Boolean Insert(string newtitle,string newcontent, string newtime, string newweather)
        {
            string aPattern = @"^[1-9]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])$";
            Regex aRegex = new Regex(aPattern);
            if (aRegex.IsMatch(newtime))
            {
                Diary aNewDiary = new Diary { title = newtitle, content = newcontent, time = newtime, weather = newweather };
                DataContext.Diary.InsertOnSubmit(aNewDiary);
                DataContext.SubmitChanges();
                return true;
                
            }
            else
            {
                return false;
            }  
        }

        public DiaryDataContext DataContext { get; }
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
