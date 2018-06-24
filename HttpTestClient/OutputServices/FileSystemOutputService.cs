using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ender.HttpTestClient
{
    public class FileSystemOutputService : FormattingOutputServiceBase
    {
        private string rootPath;

        public FileSystemOutputService(string path, string fileNameTemplate = null)
        {
            this.rootPath = path;
            this.template = string.IsNullOrEmpty(fileNameTemplate)
                ? "{statusCode}-{id}-{timestamp}.html"
                : fileNameTemplate;
        }

        public override async Task WriteAsync(int id, int statusCode, DateTime timestamp, string body)
        {
            var currentPath = Path.Combine(rootPath, GetStringFromTemplate(id, statusCode, timestamp));
            await File.WriteAllTextAsync(currentPath, body);
        }
    }
}
