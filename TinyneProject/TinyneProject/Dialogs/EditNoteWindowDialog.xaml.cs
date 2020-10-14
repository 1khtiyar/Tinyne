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

        public EditNoteWindowDialog(Note note,Window window)
        {
            InitializeComponent();

            this.Owner = window;

            CurrentNoteDescription = note.Description;

            NoteDescriptionBox.Text = CurrentNoteDescription;

            this.Loaded += AddNoteWindowDialog_Loaded;
        }

        private void AddNoteWindowDialog_Loaded(object sender, RoutedEventArgs e)
        {
            NoteDescriptionBox.Focus();
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Cancel:
                    this.DialogResult = false;
                    break;
                case Key.Escape:
                    this.DialogResult = false;
                    break;
                default:
                    break;
            }
        }
    }
}
