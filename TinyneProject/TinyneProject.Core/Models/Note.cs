using System;

namespace TinyneProject.Models
{
    [Serializable]
    public class Note : OnPropertyChangedClass
    {
        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public Note(string description)
        {
            Description = description;
        }

        public Note()
        {
            Description = " ";
        }
    }
}
