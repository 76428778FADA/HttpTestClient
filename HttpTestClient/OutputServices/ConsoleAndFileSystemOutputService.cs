using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ender.HttpTestClient
{
    public class ConsoleAndFileSystemOutputService : IOutputService
    {
        private IOutputService console;
        private IOutputService fileSystem;

        public ConsoleAndFileSystemOutputService(string path, string fileNameTemplate = null)
        {
            console = new ConsoleOutputService(fileNameTemplate);
            fileSystem = new FileSystemOutputService(path, fileNameTemplate);
        }

        public async Task WriteAsync(int id, int statusCode, DateTime timestamp, string body)
        {
            await console.WriteAsync(id, statusCode, timestamp, body);
            await fileSystem.WriteAsync(id, statusCode, timestamp, body);
        }
    }
}
