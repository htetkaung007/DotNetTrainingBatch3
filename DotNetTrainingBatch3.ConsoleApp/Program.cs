
//Cltrl +k +c --> Enable comment
//Ctrl + K + UInt128 --> Disable 
//Break point --> F9
//Stop --> shift + F5

//connect data base
using DotNetTrainingBatch3.ConsoleApp.AdoDotNetExamples;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello World of C#");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(id:3 ) ;
//adoDotNetExample.Edit(id:12) ;
//oDotNetExample.Create(title: "The girl", author: "By NNA", content: "HaHa");
adoDotNetExample.Update(id: 5, title: "hay", author: "me", content: "hello");
Console.ReadLine();