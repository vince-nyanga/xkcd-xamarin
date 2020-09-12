using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace XKCDApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ViewModelBase()
        {
        }

        public virtual Task Initialize() => Task.CompletedTask;

        protected void OnPropertyChanged([CallerMemberName] string key = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(key));
    }
}
