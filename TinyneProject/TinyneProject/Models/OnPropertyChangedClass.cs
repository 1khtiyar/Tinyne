using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TinyneProject.Models
{
    /// <summary>
    /// Class with implemented <seealso cref="INotifyPropertyChanged"/> interface
    /// </summary>
    public class OnPropertyChangedClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
