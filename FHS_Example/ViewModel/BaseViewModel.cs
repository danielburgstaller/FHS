using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FHS_Example.ViewModel
{
    public interface IBaseViewModel
    {
        /// <summary>
        /// Property Changed Eventhandler
        /// </summary>
        event PropertyChangedEventHandler PropertyChanged;
    }
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events ####################
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Events ####################

    }
}
