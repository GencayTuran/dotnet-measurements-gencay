namespace ABB.Interview.API.Services.Interfaces
{
    public interface IDataHandlerService
    {
        Task<Dictionary<string, Dictionary<string, string>>> RetrieveData();
    }
}