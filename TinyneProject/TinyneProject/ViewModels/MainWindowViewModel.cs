using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

using TinyneProject.Dialogs;
using TinyneProject.Models;
using TinyneProject.Services;
using TinyneProject.Views;

namespace TinyneProject.ViewModels
{
    /// <summary>
    /// ViewModel for <seealso cref="MainWindow"/>
    /// </summary>
    internal class MainWindowViewModel : OnPropertyChangedClass
    {

        private SolidColorBrush onTopButtonForegroundBrush;
        public SolidColorBrush OnTopButtonForegroundBrush
        {
            get => onTopButtonForegroundBrush;
            set
            {
                onTopButtonForegroundBrush = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Intermediate member for input/output operations with main storage file
        /// </summary>
        private StorageIOService iOService;


        private StorageData currentStorageData;
        /// <summary>
        /// Created/changed data for the current application session
        /// </summary>
        public StorageData currentData
        {
            get { return currentStorageData; }
            set
            {
                currentStorageData = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Temp member (a reference to the main window)
        /// </summary>
        private readonly Window window;

        #region Commands defining

        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }
        public RelayCommand TopMostWindowCommand { get; set; }
        public RelayCommand LogoWindowCommand { get; set; }

        public RelayCommand AddNoteCommand { get; set; }
        public ParameterizedRelayCommand DeleteNoteCommand { get; set; }
        public ParameterizedRelayCommand EditNoteCommand { get; set; }

        #endregion

        public MainWindowViewModel(Window window)
        {
            this.window = window;
            iOService = new StorageIOService();

            currentData = iOService.Load();
            //this.Notes = currentData.Notes;

            OnTopButtonForegroundBrush = (SolidColorBrush)Application.Current.FindResource("WindowButtonForeBrush");

            window.MouseLeave += Window_MouseLeave;
            window.MouseEnter += Window_MouseEnter;

            #region Commands initializing

            CloseWindowCommand = new RelayCommand(CloseWindow);
            MinimizeWindowCommand = new RelayCommand(MinimizeWindow);
            TopMostWindowCommand = new RelayCommand(PutWindowOnTopMost);
            LogoWindowCommand = new RelayCommand(WindowLogoClick);

            AddNoteCommand = new RelayCommand(AddNote);
            DeleteNoteCommand = new ParameterizedRelayCommand(DeleteNote);
            EditNoteCommand = new ParameterizedRelayCommand(EditNote);

            #endregion
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            window.Opacity = 1D;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!window.Topmost) return;

            window.Opacity = 0.2D;
        }

        private void EditNote(object note)
        {
            EditNoteWindowDialog windowDialog = new EditNoteWindowDialog(note as Note, window);

            if (windowDialog.ShowDialog() == true)
            {
                (note as Note).Background = windowDialog.CurrentNoteBackground;
                (note as Note).Description = windowDialog.CurrentNoteDescription;
            }
        }

        private void DeleteNote(object note)
        {
            currentData.Notes.Remove(note as Note);
        }

        private void AddNote()
        {
            AddNoteWindowDialog windowDialog = new AddNoteWindowDialog(window);

            if (windowDialog.ShowDialog() == true)
            {
                currentData.Notes.Add(new Note()
                {
                    Background = windowDialog.NewNoteBackground,
                    Description = windowDialog.NewNoteDescription
                });
            }
        }

        private void WindowLogoClick()
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Owner = window;

            if (aboutWindow.ShowDialog() == true)
                return;
        }

        private void PutWindowOnTopMost()
        {
            window.Topmost = !window.Topmost;
            OnTopButtonForegroundBrush = window.Topmost?(SolidColorBrush)Application.Current.FindResource("WhiteBrush7Opac"): (SolidColorBrush)Application.Current.FindResource("WindowButtonForeBrush");
        }

        private void MinimizeWindow()
        {
            window.WindowState = WindowState.Minimized;
        }

        private void CloseWindow()
        {
            iOService.Save(currentData);
            window.Close();
        }
    }
}
