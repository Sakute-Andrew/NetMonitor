using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NetMonitor.repo;

public class Serializer : RepoService
{
    public void addData(string data, string pathValue)
    {
        File.AppendAllText(pathValue, data + Environment.NewLine);
    }

    public void removeData(string data, string pathValue)
    {
        
    }

    public string readData(string pathValue)
    {
        fileExists(pathValue);
        string data = File.ReadAllText(pathValue);
        return data;
    }

    public void fileExists(string fileName)
    {
        
        string datapath = @"Data";

        if (!Directory.Exists(datapath))
        {
            Directory.CreateDirectory(datapath);
        }
        if (!File.Exists(fileName))
        {
            using var fileStream = File.Create(fileName);
            fileStream.Close();
            Console.WriteLine("File " + fileName + " created.");
        }
    }
}

