using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;

namespace DiaryBook
{
    class MainModel : INotifyPropertyChanged
    {
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DiaryBook;Integrated Security=True;";
        private Table<Diary> tableDiary;
        private BindingList<int> listId = new BindingList<int>();
        private BindingList<string> listTime = new BindingList<string>();
        private BindingList<string> listTitle = new BindingList<string>();
        private BindingList<string> listContent = new BindingList<string>();
        private BindingList<string> listWeather = new BindingList<string>();
        private BindingList<string> listCurrentTime = new BindingList<string>();
        private int nowid = -1;
        private string nowcontent ="";
        private string nowtime = "";
        private string nowweather = "";
        private int nowindex = -1;
        public MainModel()
        {
            DataContext = new DiaryDataContext(ConnectionString);
            tableDiary = DataContext.Diary;
            listTime.Add("所有");
            foreach (Diary diary in tableDiary)
            {
                listId.Add(diary.Id);
                listTime.Add(diary.time);
                listTitle.Add(diary.title);
                listContent.Add(diary.content);
                listWeather.Add(diary.weather);
                listCurrentTime.Add(diary.time);
            }
            listTime= new BindingList<string>(listTime.Distinct().ToList());
        }
        public void ChangeComBox(string newtime)
        {
            content = "";
            listId.Clear();
            listTitle.Clear();
            listContent.Clear();
            listWeather.Clear();
            listCurrentTime.Clear();
            var atableDiarys = from r in DataContext.Diary where r.time == newtime select r;
            if (newtime.Equals("所有") || newtime.Equals(""))
            {
                atableDiarys = from r in DataContext.Diary  select r;
            }
            else
            {
                atableDiarys = from r in DataContext.Diary where r.time == newtime select r;
            }           
            foreach (Diary diary in atableDiarys)
            {
                listId.Add(diary.Id);
                listTitle.Add(diary.title);
                listContent.Add(diary.content);
                listWeather.Add(diary.weather);
                listCurrentTime.Add(diary.time);
            }
            OnPropertyChanged("title");
            OnPropertyChanged("time");
            OnPropertyChanged("content");
            OnPropertyChanged("time");

        }
        public void ShowContent(int index)
        {
            nowindex = index;
            if (listContent.Count > index && index>=0)
            {
                nowid = listId[index];
                nowcontent = listContent[index];
                nowtime = listCurrentTime[index];
                nowweather = listWeather[index];
                OnPropertyChanged("content");
                OnPropertyChanged("time");
                OnPropertyChanged("weather");
            }
            else
            {
                nowid = -1;
                nowcontent = "";
                nowtime = "";
                nowweather = "";
            }
        }
        public void Updata()
        {
            Diary aDiary = (from r in DataContext.Diary where r.Id == nowid select r).FirstOrDefault();
            if (aDiary != null)
            {
                aDiary.content = nowcontent;
            }
            DataContext.SubmitChanges();
            listContent[nowindex] = nowcontent;
            OnPropertyChanged("content");
        }
        public void Delete()
        {
            Diary aDiary = (from r in DataContext.Diary where r.Id == nowid select r).FirstOrDefault();
            if (aDiary != null)
            {
                DataContext.Diary.DeleteOnSubmit(aDiary);
            }
            DataContext.SubmitChanges();
            tableDiary = DataContext.Diary;
            listId.RemoveAt(nowindex);
            listContent.RemoveAt(nowindex);
            listCurrentTime.RemoveAt(nowindex);
            listWeather.RemoveAt(nowindex);
            listTitle.RemoveAt(nowindex);
            nowid = -1;
            nowcontent = "";
            nowtime = "";
            nowweather = "";
            nowindex = -1;
            OnPropertyChanged("title");
            OnPropertyChanged("content");
            OnPropertyChanged("time");
            OnPropertyChanged("weather");
        }

        public void Submit()
        {
            DataContext.SubmitChanges();
        }


        public Table<Diary> Diarys
        {
            get { return tableDiary; }
        }
        public BindingList<string> alltime
        {
            get { return listTime; }
        }
        public string content
        {
            get { return nowcontent; }
            set
            {
                if (nowcontent == value) return; nowcontent = value; OnPropertyChanged(nameof(content));
            }
        }
        public string time
        {
            get { return nowtime; }
            set
            {
                if (nowtime == value) return; nowtime = value; OnPropertyChanged(nameof(time));
            }
        }
        public string weather
        {
            get { return nowweather; }
            set
            {
                if (nowweather == value) return; nowweather = value; OnPropertyChanged(nameof(weather));
            }
        }
        public BindingList<string> title
        {
            get { return listTitle; }
            set
            {
                if (listTitle == value) return; listTitle = value; OnPropertyChanged(nameof(title));
            }
        }

        public DiaryDataContext DataContext { get; set; }
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
