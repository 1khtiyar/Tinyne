using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TinyneProject.Models
{
    /// <summary>
    /// Implements <seealso cref="INotifyPropertyChanged"/>
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
