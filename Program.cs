using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Data.Sqlite;

namespace signalR
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //   ConnectDB();
      //https://www.youtube.com/watch?v=fmvcAzHpsk8
      // https://www.youtube.com/watch?v=dlJpGzop3Es&t=183s
      //   var connectionStringBuilder = new SqliteConnectionStringBuilder();
      //   connectionStringBuilder = "./myDb.db";
      //   using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
      //   {
      //     connection.Open();

      //     // create product table
      //     var createCmd = connection.CreateCommand();
      //     createCmd.CommandText = "CREATE TABLE product(description VARCHAR(200), quatity INT, is_published BOOLEAN);";
      //     createCmd.ExecuteNonQuery();


      //     using (var transaction = connection.BeginTransaction())
      //     {
      //       var insertCmd = connection.CreateCommand();
      //       insertCmd.CommandText = "INSERT INTO product('iPhone X');";
      //       insertCmd.ExecuteNonQuery();
      //     }


      //     var readCmd = connection.CreateCommand();
      //     readCmd.CommandText = "SELECT * FROM";
      //     using (var reader = readCmd.ExecuteReader())
      //     {
      //       while (reader.Read())
      //       {
      //         var result = reader.GetString(0);
      //         Console.WriteLine(result);
      //       }
      //     }
      //   }


      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });



  }
}
