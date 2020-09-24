using System.Collections.ObjectModel;

namespace TinyneProject.Models
{

    /// <summary>
    /// The class represents user's data that will be saved
    /// </summary>
    public class StorageData : OnPropertyChangedClass
    {

        private ObservableCollection<Note> notes;
        /// <summary>
        /// List of user-defined <seealso cref="Note"/>s
        /// </summary>
        public ObservableCollection<Note> Notes
        {
            get => notes;
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }


        public StorageData()
        {
            Notes = new ObservableCollection<Note>();
        }
    }
}
