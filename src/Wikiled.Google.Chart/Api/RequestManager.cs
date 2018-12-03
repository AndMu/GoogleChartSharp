using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Wikiled.Google.Chart.Api
{
    public class RequestManager : IRequestManager
    {
        public async Task<byte[]> GetImage(IChart chart)
        {
            if (chart == null)
            {
                throw new ArgumentNullException(nameof(chart));
            }

            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(new Uri(chart.GetUrl())).ConfigureAwait(false);
                using (var memoryStream = new MemoryStream())
                {
                    await stream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}