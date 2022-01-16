using FHS_Example.Service;

namespace FHS_Example.Model
{
    public interface ILibraryModel
    {
        public Task<List<LibraryDTO>> GetLibraries(int amount);
    }
    public class LibraryModel : ILibraryModel
    {
        private ICDNJSService _service;
        public LibraryModel(ICDNJSService cdnJsService)
        {

            _service = cdnJsService;
        }
        public async Task<List<LibraryDTO>> GetLibraries(int amount)
        {
            return await _service.GetLibraries(amount);
        }
    }
}
