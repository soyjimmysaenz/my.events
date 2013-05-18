using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventosImportantes.Web.API.Handlers
{
    public class CorsHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var corsEnabled = request.Headers.Any(h => h.Key == "Origin");
            bool preflight = request.Method == HttpMethod.Options;

            if (corsEnabled)
            {
                if (preflight)
                {
                    return Task.Factory.StartNew(() =>
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.OK);

                        response.Headers.Add("Access-Control-Allow-Origin", request.Headers.GetValues("Origin"));
                        response.Headers.Add("Access-Control-Allow-Headers", request.Headers.GetValues("Access-Control-Request-Headers"));
                        response.Headers.Add("Access-Control-Allow-Methods", "POST, PUT, DELETE");

                        return response;
                    });
                }
                else
                {
                    return base.SendAsync(request, cancellationToken)
                                .ContinueWith(t =>
                                {
                                    var response = t.Result;
                                    response.Headers.Add("Access-Control-Allow-Origin", request.Headers.GetValues("Origin"));

                                    return response;
                                });
                }
            }
            else
                return base.SendAsync(request, cancellationToken);
        }
    }
}