using System.Windows;
using System.Windows.Input;

namespace TinyneProject.Dialogs
{
    public partial class AddNoteWindowDialog : Window
    {
        public string NewNoteDescription { get; set; }

        public AddNoteWindowDialog(Window window)
        {
            InitializeComponent();

            this.Owner = window;

            NewNoteDescription = string.Empty;

            NoteDescriptionBox.Text = NewNoteDescription;

            this.Loaded += AddNoteWindowDialog_Loaded;
        }

        private void AddNoteWindowDialog_Loaded(object sender, RoutedEventArgs e)
        {
            NoteDescriptionBox.Focus();
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

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
