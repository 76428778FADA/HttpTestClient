using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ender.HttpTestClient
{
    public interface IHttpTestClient : IDisposable
    {
        Task RunAsync();
        void Stop();
    }
}
