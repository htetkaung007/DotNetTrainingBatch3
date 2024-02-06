using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            #region Read
            //Detail of connect DataBase
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-BMOLS6N";//sever name
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";//Data Base Name
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            Console.WriteLine("SqlConnectionSting -->" + sqlConnectionStringBuilder.ConnectionString);

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            //use this connectionSting and open dataBase

            Console.WriteLine("This is opening... ");
            connection.Open();//open connection
            Console.WriteLine("This is opened ");

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tb_Blog]";//@ is support for multi line 

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);//cmd value is add to adapter
            DataTable dt = new DataTable();
            adapter.Fill(dt);//clone data

            Console.WriteLine("Closing connection...");
            connection.Close();//connectin close
            Console.WriteLine("Closed connection");

            Console.WriteLine("Test data " + dt);//how to check reach backend data?

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Title..." + dr["BlogTitle"]);
                Console.WriteLine("Author..." + dr["BlogAuthor"]);
                Console.WriteLine("Content..." + dr["BlogContent"]);

            }
            #endregion
        }
        public void Edit(int id)
        {
            #region Edit 
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-BMOLS6N";//sever name
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";//Data Base Name
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";



            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();//open connection


            string query = @"SELECT [BlogId]
             ,[BlogTitle]
              ,[BlogAuthor]
             ,[BlogContent]
             FROM [dbo].[Tb_Blog] Where BlogId = @BlogId";//@ is support for multi line 

            // if we use C# id there has a little error sql injection (if uese like this add $ in front of @ and use id insert of BlogId

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);//id === BlogId define
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);//cmd value is add to adapter
            DataTable dt = new DataTable();
            adapter.Fill(dt);//clone data


            connection.Close();//connectin close

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found ..");
                return;
            }

            DataRow dr = dt.Rows[0];//first line 
            Console.WriteLine("Title..." + dr["BlogTitle"]);
            Console.WriteLine("Author..." + dr["BlogAuthor"]);
            Console.WriteLine("Content..." + dr["BlogContent"]);

            #endregion
        }

        public void Create(string title, string author, string content)
        {
            #region Create
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-BMOLS6N";//sever name
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";//Data Base Name
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";



            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();//open connection
            string query = @"INSERT INTO[dbo].[Tb_Blog]
           ([BlogTitle]
           , [BlogAuthor]
           , [BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";//insert query

            // if we use C# id there has a little error sql injection (if uese like this add $ in front of @ and use id insert of BlogId

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();// if get data run excute



            connection.Close();//connectin close
            string massage = result > 0 ? "Savig sucefully" : "Saving failed";
            #endregion

        }
        public void Update(int id, string title, string author, string content)
        {
            #region Update
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "DESKTOP-BMOLS6N";//sever name
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";//Data Base Name
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";



            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();//open connection


            string query = @"UPDATE [dbo].[Tb_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";//insert query

            // if we use C# id there has a little error sql injection (if uese like this add $ in front of @ and use id insert of BlogId

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();// if get data run excute



            connection.Close();
            string massage = result > 0 ? "Savig sucefully" : "Saving failed";

            #endregion

        }
    }
    }
