using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ender.HttpTestClient
{
    public class HttpTestClient : IHttpTestClient
    {
        private bool isRun;
        private HttpTestClientSettings settings;
        private IOutputService outputService;

        public HttpTestClient(HttpTestClientSettings settings, IOutputService outputService)
        {
            this.settings = settings;
            this.outputService = outputService;
        }

        public async Task RunAsync()
        {
            isRun = true;
            for (var id = settings.StartId; id <= settings.EndId; id++)
            {
                if (!isRun)
                    return;
                HttpWebResponse response = null;
                var request = WebRequest.Create(GetStringFromTemplate(settings.UrlTemplate, id)) as HttpWebRequest;
                try
                {
                    response = await request.GetResponseAsync() as HttpWebResponse;
                }
                catch (WebException ex)
                {
                    response = ex.Response as HttpWebResponse;
                }
                var body = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
                await outputService.WriteAsync(id, (int)response.StatusCode, DateTime.Now, body);
            }
        }

        public void Stop()
        {
            isRun = false;
        }

        public void Dispose()
        {
            Stop();
        }

        private string GetStringFromTemplate(string template, int id)
        {
            var stringId = id.ToString();
            return template
                .Replace("{0}", stringId)
                .Replace("{id}", stringId);
        }
    }
}
