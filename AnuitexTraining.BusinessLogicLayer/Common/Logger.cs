using AnuitexTraining.BusinessLogicLayer.Common.Interfaces;
using System;
using System.IO;

namespace AnuitexTraining.BusinessLogicLayer.Common
{
    public class Logger : ILogger
    {
        public void LogFile(string path, string error)
        {
            using (StreamWriter stream = new StreamWriter($"log {DateTime.Now:G}.txt", true))
            {
                stream.Write(error);
            }
        }
    }
}
