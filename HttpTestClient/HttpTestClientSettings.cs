using System;
using System.Collections.Generic;
using System.Text;

namespace Ender.HttpTestClient
{
    public class HttpTestClientSettings
    {
        public int StartId { get; set; }
        public int EndId { get; set; }
        public string UrlTemplate { get; set; }
    }
}
