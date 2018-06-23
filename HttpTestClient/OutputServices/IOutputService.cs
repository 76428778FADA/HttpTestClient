using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ender.HttpTestClient
{
    public interface IOutputService
    {
        Task WriteAsync(int id, int statusCode, DateTime timestamp, string body);
    }
}
