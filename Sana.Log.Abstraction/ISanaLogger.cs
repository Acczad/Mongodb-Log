using Sana.Log.Abstraction.Model;
using System.Threading.Tasks;

namespace Sana.Log.Abstraction
{
    public  interface ISanaLogger
    {
        Task Information(SanaInformationLogModel logModel);
        Task Error(SanaErrorLogModel logModel);
    }

}
