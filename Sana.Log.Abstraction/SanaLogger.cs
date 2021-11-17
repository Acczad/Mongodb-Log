using Sana.Log.Abstraction.Model;
using Sana.Log.Abstraction.Store;
using System.Threading.Tasks;

namespace Sana.Log.Abstraction
{
    public class SanaLogger : ISanaLogger
    {
        private readonly ILogDataStore _logDataStore;

        public SanaLogger(ILogDataStore logErrorDataStore)
        {
            _logDataStore = logErrorDataStore;
        }

        public Task Information(SanaInformationLogModel logModel)
        {
            return _logDataStore.StoreInformation(logModel);
        }
        public Task Error(SanaErrorLogModel logModel)
        {
            return _logDataStore.StoreError(logModel);
        }
    }
}
