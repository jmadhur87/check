using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace ConloseApp{
        class Program{
                public static void Main(String[] args){

                var config = new ConfigurationBuilder()
                        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();

                var loggerFactory = LoggerFactory.Create(builder=>{
                builder.AddNLog(config);
                });
                
                var logger = loggerFactory.CreateLogger<Program>();

                logger.LogInformation("Aplication Started");

                Console.Write("Enter Root Directory Path for files : ");
                String rootpath=Convert.ToString(@Console.ReadLine())!;
                
                if(!Directory.Exists(rootpath)){
                        Console.WriteLine("Invalid Path");
                        logger.LogError("Directory not exists");
                   }
                logger.LogInformation("Directory Found");

                Console.Write("Enter mazor : ");
                String mazor=Convert.ToString(Console.ReadLine())!;
                bool b1=string.IsNullOrEmpty(mazor);
                if(b1==true){
                        logger.LogError("Mazor value can't be null");
                        Console.WriteLine("Mazor value can't be null");
                        return;
                }
                logger.LogInformation("Mazor Value ");
        
                Console.Write("Enter minor : ");
                String minor=Convert.ToString(Console.ReadLine())!;
                bool b2=string.IsNullOrEmpty(mazor);
                if(b2==true){
                        logger.LogError("Minor value can't be null");
                        Console.WriteLine("Minor value can't be null");
                        return;
                }
                files_data temp1= new files_data(rootpath,mazor,minor);
        //        temp1.delte_files();
/*-----------------------------------------------------------------------------------------------------------------------------*/
                Console.Write("Enter Root Directory Path for Csv files : ");
                String filepath=Convert.ToString(@Console.ReadLine())!;

                if(!Directory.Exists(filepath)){
                        Console.WriteLine("Invalid Path"); 
                        logger.LogError("Directory not exists");
                }
                Console.WriteLine("Give all File name by ',' seprated");
                String filesName=Convert.ToString(Console.ReadLine()!);
                string[] files_Name_Arr=filesName.Split(',');

                csv_data temp2 = new csv_data(filepath,mazor,minor,files_Name_Arr);
                temp2.deletedata();        

                }               
        }
}