using System;
using System.IO;

    class files_data{
    String rootp;
    string mazor;
    string minor;
    public files_data(string rootp,string mazor,string minor){
        this.rootp=rootp;
        this.mazor=mazor;
        this.minor=minor;
    }

    public void delte_files(){
        // string[] dirs=Directory.GetDirectories(rootp);

    var files = Directory.GetFiles(rootp,$"*{mazor}.{minor}*",SearchOption.AllDirectories); //alldirectories/top directories

    foreach(string file in files){
        //var info=new FileInfo(file);  
    
        Console.WriteLine($"{ Path.GetFileNameWithoutExtension(file) }");
        File.Delete(file);
        File.Copy(file,$@"C:\Testdata\Deleted Files\{Path.GetFileName(file)}");
    }
    Console.WriteLine($"Sucessfully Deleted All files With mazor {mazor} and minor {minor}.");

}

}


