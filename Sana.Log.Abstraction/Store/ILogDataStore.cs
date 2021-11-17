using Sana.Log.Abstraction.Model;
using System.Threading.Tasks;

namespace Sana.Log.Abstraction.Store
{
    public interface ILogDataStore
    {
        Task StoreError(SanaErrorLogModel logObject);
        Task StoreInformation(SanaInformationLogModel logObject);
    }
}
