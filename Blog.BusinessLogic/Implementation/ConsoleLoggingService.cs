using System;

namespace Blog.BusinessLogic.Implementation
{
    public class ConsoleLoggingService : ILoggingService
    {
        public void Log(string message, params object[] parameters)
        {
            Console.WriteLine(message, parameters);
        }
    }
}