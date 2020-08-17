using AnuitexTraining.BusinessLogicLayer.Common.Interfaces;
using System;
using System.IO;

namespace AnuitexTraining.BusinessLogicLayer.Common
{
    public class Logger : ILogger
    {
        public void LogFile(string error)
        {
            using (StreamWriter stream = new StreamWriter($"log {DateTime.Now:dd.MM.yyyy HH-mm-ss}.txt", true))
            {
                stream.Write(error);
            }
        }
    }
}
