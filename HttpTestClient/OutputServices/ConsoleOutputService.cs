using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ender.HttpTestClient
{
    public class ConsoleOutputService : FormattingOutputServiceBase
    {
        public ConsoleOutputService(string messageTemplate = null)
        {
            this.template = string.IsNullOrEmpty(messageTemplate)
                ? "{id}-{statusCode}-{timestamp}"
                : messageTemplate;
        }

        public override Task WriteAsync(int id, int statusCode, DateTime timestamp, string body)
        {
            if (statusCode.ToString().StartsWith('5'))
                Console.ForegroundColor = ConsoleColor.Red;
            if (statusCode.ToString().StartsWith('3') || statusCode.ToString().StartsWith('4'))
                Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(GetStringFromTemplate(id, statusCode, timestamp));
            Console.ResetColor();

            return Task.CompletedTask;
        }
    }
}
