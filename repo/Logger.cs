namespace NetMonitor.repo;

using System;
using System.IO;

public class Logger
{
    private readonly string logFilePath;

    public Logger(string filePath)
    {
        logFilePath = filePath;
    }

    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, append: true))
        {
            writer.WriteLine(message);
        }
    }
}