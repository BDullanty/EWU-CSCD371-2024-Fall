﻿using System;

namespace Logger;

public class LogFactory
    
{

    public string FilePath { get; set; }

    public void ConfigureFileLogger(string path)
    {
       this.FilePath = path;
    }

    public BaseLogger CreateLogger(string className)
    {
        switch (className.ToLower())
        {
            case "":
                throw new ArgumentException("Empty class name passed into Create Logger");
                break;
            case "testlogger":
                return new TestLogger() { ClassName = "TestLogger"};
                break;

            case "filelogger":
                FileLogger logger =new FileLogger(){ClassName = "FileLogger"};
                return new FileLogger();
                break;
            default:
                throw new ArgumentException("No class with name " + className + " found");
        }
    }
}
