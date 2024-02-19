
//Cltrl +k +c --> Enable comment
//Ctrl + K + UInt128 --> Disable 
//Break point --> F9
//Stop --> shift + F5

//connect data base
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EfcoreExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello World of C#");

#region ado.net CRUD
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Read();
//adoDotNetExample.Edit(id:3 ) ;
//adoDotNetExample.Edit(id:12) ;
//adoDotNetExample.Create(title: "The girl", author: "By NNA", content: "HaHa");
//adoDotNetExample.Update(id: 5, title: "hay", author: "me", content: "hello");
//adoDotNetExample.Delete(id: 5);
#endregion 

#region DapperExample
//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(6);
//dapperExample.Edit(55);
//dapperExample.Create(title: "The girl", author: "By NNA", content: "HaHa");
//dapperExample.Update(title: "The Boy", author: "By NNA", content: "HaHa", id: 12);
//dapperExample.Delete(id: 12);
#endregion

#region EfcoreExamples
EfcoreExample efcoreExample = new EfcoreExample();
//efcoreExample.Read();
//efcoreExample.Edit(2);
//efcoreExample.Edit(15);
//efcoreExample.Create(title: "The Boys", author: "By NNA", content: "HaHa");
//efcoreExample.Update(title: "The Boys", author: "By NNA", content: "HaHa", id:13);
efcoreExample.Delete(id: 4);
#endregion


Console.ReadLine();
