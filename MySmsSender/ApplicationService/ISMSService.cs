using DomainModel;
using System.Threading.Tasks;

namespace ApplicationService
{
    public interface ISMSService
    {
         Task<int> SendAsync(SMS sms);
    }
}
