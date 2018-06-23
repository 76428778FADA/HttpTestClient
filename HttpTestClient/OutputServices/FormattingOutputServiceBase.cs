using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ender.HttpTestClient
{
    public abstract class FormattingOutputServiceBase : IOutputService
    {
        protected string template;

        public abstract Task WriteAsync(int id, int statusCode, DateTime timestamp, string body);

        protected string GetStringFromTemplate(int id, int statusCode, DateTime timestamp)
        {
            return template
                .Replace("{statusCode}", statusCode.ToString())
                .Replace("{id}", id.ToString())
                .Replace("{timestamp}", timestamp.ToString());
        }
    }
}
