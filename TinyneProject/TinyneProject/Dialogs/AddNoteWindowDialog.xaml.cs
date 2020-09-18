using System.Windows;

using TinyneProject.Models;

namespace TinyneProject.Dialogs
{
    public partial class AddNoteWindowDialog : Window
    {
        public string NewNoteDescription { get; set; }
        public NoteManager.BackgroundBrushes NewNoteBackground { get; set; }

        public AddNoteWindowDialog()
        {
            InitializeComponent();

            NewNoteDescription = string.Empty;
            NewNoteBackground = NoteManager.BackgroundBrushes.Default;

            NoteDescriptionBox.Text = NewNoteDescription;
            BackgroundButton.Background = NoteManager.SetBrush(NewNoteBackground);
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            NewNoteDescription = NoteDescriptionBox.Text;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundSelectorWindowDialog windowDialog = new BackgroundSelectorWindowDialog();

            if (windowDialog.ShowDialog()==true)
            {
                NewNoteBackground = windowDialog.SelectedBackground;
                BackgroundButton.Background = NoteManager.SetBrush(NewNoteBackground);
            }
        }
    }
}
