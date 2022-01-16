using FHS_Example.Model;
using FHS_Example.Service;
using Microsoft.JSInterop;

namespace FHS_Example.ViewModel
{
    public interface ILibrariesViewModel
    {
        public List<LibraryDTO> libraries { get; set; }

        public Task GetLibrariesAsync(int amount);

        public Task Open(LibraryDTO dto);
    }
    public class LibrariesViewModel : BaseViewModel, ILibrariesViewModel
    {

        private ILibraryModel _librariesModel;
        private IJSRuntime _runtime;

        public LibrariesViewModel(ILibraryModel librariesModel, IJSRuntime runtime)
        {
            _librariesModel = librariesModel;
            _runtime = runtime;
        }
        #region Property libraries
        private List<LibraryDTO> _libraries;
        /// <summary>
        /// Gets or sets a value indicating whether.
        /// </summary>
        public List<LibraryDTO> libraries
        {
            get => _libraries;
            set
            {
                if (_libraries == value)
                    return;

                _libraries = value;
                OnPropertyChanged(nameof(libraries));
            }
        }
        #endregion Property MyProperty

        public async Task GetLibrariesAsync(int amount)
        {
            libraries = await _librariesModel.GetLibraries(amount);
        }

        public async Task Open(LibraryDTO dto)
        {
            await _runtime.InvokeVoidAsync("navigate", dto.latest);
        }
    }
}
