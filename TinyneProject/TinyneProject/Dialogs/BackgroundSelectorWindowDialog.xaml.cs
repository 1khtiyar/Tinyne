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
    public partial class BackgroundSelectorWindowDialog : Window
    {
        public NoteManager.BackgroundBrushes SelectedBackground;

        public BackgroundSelectorWindowDialog()
        {
            InitializeComponent();

            MainPanel.Children.Add(new Button() { 
                Name = "buttonRed", 
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Red),
                Height = 50, 
                Width = 50 ,
            });

            MainPanel.Children.Add(new Button()
            {
                Name = "buttonGreen",
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Green),
                Height = 50,
                Width = 50
            });

            MainPanel.Children.Add(new Button()
            {
                Name = "buttonBlue",
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Blue),
                Height = 50,
                Width = 50
            });

            MainPanel.Children.Add(new Button()
            {
                Name = "buttonBlack",
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Black),
                Height = 50,
                Width = 50
            });

            MainPanel.Children.Add(new Button()
            {
                Name = "buttonYellow",
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Yellow),
                Height = 50,
                Width = 50
            });

            foreach (Button item in MainPanel.Children)
            {
                item.Click += SelectBackground;
            }
        }

        private void SelectBackground(object sender, RoutedEventArgs e)
        {
            string brushName = string.Concat((sender as Button).Name.Substring(6), "BackgroundBrush");
            SelectedBackground = NoteManager.GetEnum(brushName);
            this.DialogResult = true;
        }
    }
}
