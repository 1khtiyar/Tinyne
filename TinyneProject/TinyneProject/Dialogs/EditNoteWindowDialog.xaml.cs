using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using TinyneProject.Models;

namespace TinyneProject.Dialogs
{
    public partial class EditNoteWindowDialog : Window
    {
        public string CurrentNoteDescription { get; set; }
        public NoteManager.BackgroundBrushes CurrentNoteBackground { get; set; }

        public EditNoteWindowDialog(Note note)
        {
            InitializeComponent();

            CurrentNoteDescription = note.Description;
            CurrentNoteBackground = note.Background;

            NoteDescriptionBox.Text = CurrentNoteDescription;
            BackgroundButton.Background = NoteManager.SetBrush(CurrentNoteBackground);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void SaveNoteButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentNoteDescription = NoteDescriptionBox.Text;
            this.DialogResult = true;
        }

        private void BackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundSelectorWindowDialog windowDialog = new BackgroundSelectorWindowDialog();

            if (windowDialog.ShowDialog() == true)
            {
                CurrentNoteBackground = windowDialog.SelectedBackground;
                BackgroundButton.Background = NoteManager.SetBrush(CurrentNoteBackground);
            }
        }
    }
}
