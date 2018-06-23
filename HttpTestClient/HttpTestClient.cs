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

                var request = WebRequest.Create(GetStringFromTemplate(settings.UrlTemplate, id)) as HttpWebRequest;
                var response = await request.GetResponseAsync() as HttpWebResponse;
                var body = await new StreamReader(request.GetRequestStream()).ReadToEndAsync();
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
