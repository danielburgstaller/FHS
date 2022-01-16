
namespace FHS_Example.Service
{
    public interface ICDNJSService
    {
        /// <summary>
        /// Gets the Libraries from the API 
        /// </summary>
        /// <param name="limit">amount of items to be queried</param>
        /// <returns></returns>
        Task<List<LibraryDTO>> GetLibraries(int limit);
    }
}