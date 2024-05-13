using System;
using System.IO;
using System.Globalization;
    class csv_data{
        String rootp;
        string mazor;
        string minor;
        string[] file_Name_Arr;
        public csv_data(string rootp,string mazor,string minor,string[] file_Name_Arr){
            this.rootp=rootp;
            this.mazor=mazor;
            this.minor=minor;
            this.file_Name_Arr=file_Name_Arr;
        }
        
        public void deletedata(){
            try{
                for(int i=0;i<file_Name_Arr.Length;i++){
                    string curFile=file_Name_Arr[i];
                
                string tempFile=Path.GetTempFileName();
                string pathtoFile=(rootp+'/'+curFile);
                using( StreamReader reader = new StreamReader(pathtoFile)){
                    
                    using( StreamWriter writer = new StreamWriter(tempFile)){

                        string headerLine = reader.ReadLine()!;
                        string[] columns=headerLine.Split(',');

                        int index1=Array.IndexOf(columns,"mazor");
                        int index2=Array.IndexOf(columns,"minor");

                        if(index1<-1 ){
                            Console.WriteLine("Mazor Column Not Found");
                            return;
                        }
                        else if(index2<-1){
                            Console.WriteLine("Minor Column Not found");
                            return;

                        }

                        writer.WriteLine(headerLine);

                        string line;
                        while((line=reader.ReadLine()! )!=null){
    
                            string[] value=line.Split(',');
                            
                            if(value.Length>index1 && value.Length>index2 &&  value[index1]==mazor && value[index2]==minor){
                                Console.WriteLine(line);
                            }

                            else{
                                writer.WriteLine(line);
                            }

                        }
                        
                       

                    }
                }
                
                File.Delete(pathtoFile);
                File.Move(tempFile,pathtoFile);           
                Console.WriteLine($"Rows deleted Sucessfully from {curFile}");        
                }
            }

            catch(Exception e){
                Console.WriteLine(e.Message);
            }

        }
}