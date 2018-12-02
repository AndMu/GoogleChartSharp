using System.Threading.Tasks;

namespace Wikiled.Google.Chart.Api
{
    public interface IRequestManager
    {
        Task<byte[]> GetImage(IChart chart);
    }
}