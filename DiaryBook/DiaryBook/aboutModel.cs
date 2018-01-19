using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DiaryBook
{
    class aboutModel : INotifyPropertyChanged
    {
        String _name = "";
        String _contentauthor = "";
        String _contenttime = "";
        String _version = "";
        public aboutModel()
        {
            XmlDocument aXml = new XmlDocument();
            aXml.Load("D:\\VSworkspace\\DiaryBook\\配置信息.xml");
            XmlNode xn = aXml.SelectSingleNode("configration");
            _name = xn.SelectSingleNode("Name").InnerText;
            _contentauthor = xn.SelectSingleNode("Content").SelectSingleNode("Author").InnerText;
            _contenttime = xn.SelectSingleNode("Content").SelectSingleNode("Time").InnerText;
            _version = xn.SelectSingleNode("Version").InnerText;
        }
        public String name
        {
            get { return "程序名："+_name; }
        }
        public String contentauthor
        {
            get { return "作者：" + _contentauthor; }
        }
        public String contenttime
        {
            get { return "创作时间：" + _contenttime; }
        }
        public String version
        {
            get { return "版本号：" + _version; }
        }
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
