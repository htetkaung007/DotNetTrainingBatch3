using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetTrainingBatch3.ConsoleApp.Models;
using System.Reflection.Metadata;

namespace DotNetTrainingBatch3.ConsoleApp.DapperExamples
{   public class DapperExample
    {
        //We need to built Object - dto (data transfar object) so we create a folder "Models"

        //Create a connection only one for all
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-BMOLS6N",//sever name
                InitialCatalog = "TestDb",//Data Base Name
                UserID = "sa",
                Password = "sasa@123",
            };

        public void Read()
        {
            #region Read
            //Detail of connect DataBase
            
            

            
            //We don't need open connectinon and close connection
            //SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            //connection.Open();//open connection
            

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tb_Blog]";//@ is support for multi line 
            //insead of open and close we use --> using IDbConnection
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            
           List<BlogModel> lst = db.Query<BlogModel>(query).ToList();//we need money so we use ToList ?is that right?
            #region details
            //Query --> come from Dapper
            // like  ado.net fill -->clone data
            // work mapping --> C# object and data base (so we need to add mapping object in Models folder BlogModels file)
            //<BlogModels> is object name
            #endregion

            #region We don't need this
            //SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);//cmd value is add to adapter
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);//clone data

            //Console.WriteLine("Closing connection...");
            //connection.Close();//connectin close
            //Console.WriteLine("Closed connection");

            //Console.WriteLine("Test data " + dt);//how to check reach backend data?
            #endregion


            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.BlogAuthor);
            }
            #endregion
        }
        public void Edit(int id)
        {
            #region Edit 
            //connection go to the top so we can only once
            string query = @"SELECT [BlogId]
             ,[BlogTitle]
              ,[BlogAuthor]
             ,[BlogContent]
             FROM [dbo].[Tb_Blog] Where BlogId = @BlogId";//@ is support for multi line 

            // if we use C# id there has a little error sql injection (if uese like this add $ in front of @ and use id insert of BlogId
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            var item = db.Query<BlogModel>(query, new {BlogId = id}).FirstOrDefault();//we change ToList into FirstOrDefault
            // find with where so we need to define value for id 
            #region Details of FirstOrDefault
            //For First --> this fn run two code (like setect___) and take first line and run
            //For OrDefault -->object default is "null" and string is default is "null" 
            //So there is not value retun Null
            #endregion
            
            if (item is null)
            {
                Console.WriteLine("No data Found ");
                return ;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine(item.BlogAuthor);

            #endregion
        }

        public void Create(string title, string author, string content)
        {
            #region Create
            



            
            string query = @"INSERT INTO[dbo].[Tb_Blog]
           ([BlogTitle]
           , [BlogAuthor]
           , [BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";//insert query

            // if we use C# id there has a little error sql injection (if uese like this add $ in front of @ and use id insert of BlogId

            BlogModel blog = new BlogModel()
            { BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,

            };//BlogModel has BlogId but this is not work for this dapper are map with query 
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);//Excute mean  run 



            string massage = result > 0 ? "Savig sucefully" : "Saving failed";
            #endregion

        }
        public void Update(int id, string title, string author, string content)
        {
            #region Update
            


            


            string query = @"UPDATE [dbo].[Tb_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";//insert query

            // if we use C# id there has a little error sql injection (if uese like this add $ in front of @ and use id insert of BlogId

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
                

            };//BlogModel has BlogId but this is not work for this dapper are map with query 
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);//Excute mean  run 




            string massage = result > 0 ? "Savig sucefully" : "Saving failed";

            #endregion

        }
        public void Delete(int id)
        {
            #region delete
            

           
            string query = @"DELETE FROM [dbo].[Tb_Blog]
      WHERE BlogId = @BlogId";
            BlogModel blog = new BlogModel()
            {
                BlogId = id,
               


            };//BlogModel has BlogId but this is not work for this dapper are map with query 
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);//Excute mean  run 


            
            
            string massage = result > 0 ? "Delete sucefully" : "Delete failed";
            #endregion
        }
    }
}
