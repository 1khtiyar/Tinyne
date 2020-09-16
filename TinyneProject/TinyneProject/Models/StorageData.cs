using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyneProject.Models
{
    internal class StorageData:OnPropertyChangedClass
    {

        private ObservableCollection<Note> notes;
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
