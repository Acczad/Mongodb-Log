namespace Sana.Log.Abstraction.Model
{
    public class SanaInformationLogModel : SanaBaseLogDataModel
    {
        private SanaInformationLogModel(string message, string systemName) : base(LogLevel.Information, message, systemName) { }

        public  SanaInformationLogModel GetInstance(string message, string systemName)
        {
            return new SanaInformationLogModel(message, systemName);
        }
    }
}
