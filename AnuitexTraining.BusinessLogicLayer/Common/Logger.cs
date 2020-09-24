using System;
using System.IO;
using AnuitexTraining.BusinessLogicLayer.Common.Interfaces;

namespace AnuitexTraining.BusinessLogicLayer.Common
{
    public class Logger : ILogger
    {
        public void LogFile(string error)
        {
            using var stream = new StreamWriter($"log {DateTime.Now:dd.MM.yyyy HH-mm-ss}.txt", true);
            stream.Write(error);
        }
    }
}