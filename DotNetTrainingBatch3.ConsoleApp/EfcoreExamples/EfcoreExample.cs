using DotNetTrainingBatch3.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//ORM so we write --> mapping with DataBase and C# code
namespace DotNetTrainingBatch3.ConsoleApp.EfcoreExamples
{
    internal class EfcoreExample
    {
        #region onlyRead
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.ToList();


            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.BlogAuthor);
            }
        }
        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
           BlogModel item =  db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();//if exits out put one string else return null 
            if (item is null)
            {
                Console.WriteLine("No Data found");
                return;
            }

           
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.BlogAuthor);
            
        }
        #endregion
        public void Create(string title, string content,string author)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();//run excute
            string massage = result > 0 ? "saving Successful " : "saving Failed";
            Console.WriteLine(massage);
        }

        public void Update(int id ,string title, string content, string author)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();//if exits out put one string else return null 
            if (item is null)
            {
                Console.WriteLine("No Data found");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            item.BlogId = id;
            
           
            int result = db.SaveChanges();//run excute
            string massage = result > 0 ? "Updating Successful " : "Updating Failed";
            Console.WriteLine(massage);
        }
        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();//if exits out put one string else return null 
            if (item is null)
            {
                Console.WriteLine("No Data found");
                return;
            }
            //if exist --> remove
           db.Blogs.Remove(item);


            int result = db.SaveChanges();//run excute
            string massage = result > 0 ? "Deleting Successful " : "Deleting Failed";
            Console.WriteLine(massage);
        }
    }
}
