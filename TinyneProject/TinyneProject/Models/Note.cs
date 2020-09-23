using System;
using static TinyneProject.Models.NoteManager;

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


        private BackgroundBrushes background;
        public BackgroundBrushes Background
        {
            get => background;
            set
            {
                background = value;
                OnPropertyChanged();
            }
        }


        public Note(string description, BackgroundBrushes brush)
        {
            Description = description;
            Background = brush;
        }

        public Note()
        {
            Description = " ";
            Background = BackgroundBrushes.Default;
        }
    }
}
