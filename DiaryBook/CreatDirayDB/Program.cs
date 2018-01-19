using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatDirayDB
{
    class Program
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=DiaryBook;Integrated Security=true;";
        static void Main(string[] args)
        {
            try
            {
                // 连接数据库引擎
                using (DiaryDataContext aDataContext = new DiaryDataContext(ConnectionString))
                {
                    if (!aDataContext.DatabaseExists())
                    {
                        aDataContext.CreateDatabase();
                        Console.WriteLine("数据库已经创建！");
                        Console.WriteLine("插入新记录……");
                        Diary aNewContact = new Diary { title = "郊游", content = "今天零下30度，我和肖遥去南口校区郊游，真开心！", time = "2018-1-17", weather = "雪" };
                        aDataContext.Diary.InsertOnSubmit(aNewContact);
                    }
                    else
                    {
                        Console.WriteLine("数据库已经存在！");
                    }

                    // 读取数据表内容
                    var aDiarys = from r in aDataContext.Diary select r;
                    foreach (Diary aDiary in aDiarys)
                    {
                        Console.WriteLine($"{aDiary.Id} : {aDiary.title}: {aDiary.content}: {aDiary.time}: {aDiary.weather}");
                    }                 
                    aDataContext.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("按回车键退出……");
            Console.ReadLine();
        }
    }
}
