using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static TinyneProject.Models.NoteManager;

namespace TinyneProject.Models
{
    [Serializable]
    internal class Note : OnPropertyChangedClass
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


        private SolidColorBrush background;
        public SolidColorBrush Background
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
            Background = NoteManager.GetBrush(brush);
        }

        public Note()
        {
            Description = "...";
            Background = NoteManager.SetBrush();
        }
    }
}
