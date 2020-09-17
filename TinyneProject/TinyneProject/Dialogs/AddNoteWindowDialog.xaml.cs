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
using TinyneProject.ViewModels;
using static TinyneProject.Models.NoteManager;

namespace TinyneProject.Dialogs
{
    public partial class AddNoteWindowDialog : Window
    {
        public string UpdatedDescription { get; set; }
        public BackgroundBrushes UpdatedBackground { get; set; }

        public AddNoteWindowDialog()
        {
            UpdatedDescription = string.Empty;
            UpdatedBackground = BackgroundBrushes.Default;

            InitializeComponent();
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BackgroundButton_Click(object sender, RoutedEventArgs e)
        {
            BackgroundSelectorWindowDialog windowDialog = new BackgroundSelectorWindowDialog();
            windowDialog.Show();

            if (windowDialog.DialogResult==true)
            {
                UpdatedBackground = windowDialog.SelectedBackground;
            }
        }

        private void NoteDescriptionBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatedDescription = NoteDescriptionBox.Text;
        }
    }
}
