﻿using System.Windows;
using System.Windows.Controls;

using TinyneProject.Models;

namespace TinyneProject.Dialogs
{
    public partial class BackgroundSelectorWindowDialog : Window
    {
        public NoteManager.BackgroundBrushes SelectedBackground;

        public BackgroundSelectorWindowDialog(Window window)
        {
            InitializeComponent();

            this.Owner = window;

            SelectedBackground = NoteManager.BackgroundBrushes.Default;

            MainPanel.Children.Add(new Button() { 
                Name = "buttonRed", 
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Red),
            });

            MainPanel.Children.Add(new Button()
            {
                Name = "buttonGreen",
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Green),
            });

            MainPanel.Children.Add(new Button()
            {
                Name = "buttonBlue",
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Blue),
            });

            MainPanel.Children.Add(new Button()
            {
                Name = "buttonBlack",
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Black),
            });

            MainPanel.Children.Add(new Button()
            {
                Name = "buttonYellow",
                Background = NoteManager.SetBrush(NoteManager.BackgroundBrushes.Yellow),
                
            });

            foreach (Button item in MainPanel.Children)
            {
                item.Height = 45;
                item.Width = 45;
                item.Margin = new Thickness(2);
                item.Style = (Style)Application.Current.FindResource("BackgroundSelectorButtonStyle");
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