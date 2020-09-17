using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using TinyneProject.Models;
using TinyneProject.Services;

namespace TinyneProject.ViewModels
{
    /// <summary>
    /// ViewModel for <seealso cref="MainWindow"/>
    /// </summary>
    internal class MainWindowViewModel:OnPropertyChangedClass
    {
        private ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get => notes;
            set 
            { 
                notes = value;
                OnPropertyChanged();
            }
        }


        public SolidColorBrush brush;

        private StorageIOService iOService;

        private StorageData currentStorageData;
        public StorageData currentData
        {
            get { return currentStorageData; }
            set 
            { 
                currentStorageData = value;
                OnPropertyChanged();
            }
        }

        private Window window;


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
            this.Notes = currentData.Notes;

            brush = (SolidColorBrush)Application.Current.FindResource("YellowBackgroundBrush");

            #region Commands initializing

            CloseWindowCommand = new RelayCommand(CloseWindowClick);
            MinimizeWindowCommand= new RelayCommand(MinimizeWindowClick);
            TopMostWindowCommand= new RelayCommand(TopMostWindowClick);
            LogoWindowCommand= new RelayCommand(LogoWindowClick);

            AddNoteCommand= new RelayCommand(AddNoteClick);
            DeleteNoteCommand= new ParameterizedRelayCommand(DeleteNoteClick);
            EditNoteCommand= new ParameterizedRelayCommand(EditNoteClick);

            #endregion
        }

        private void EditNoteClick(object note)
        {
            MessageBox.Show((note as Note).Description);
        }

        private void DeleteNoteClick(object note)
        {
            currentData.Notes.Remove(note as Note);
        }

        private void AddNoteClick()
        {
            currentData.Notes.Add(new Note());
        }

        private void LogoWindowClick()
        {
            MessageBox.Show("Test");
        }

        private void TopMostWindowClick()
        {
            window.Topmost = !window.Topmost;
        }

        private void MinimizeWindowClick()
        {
            window.WindowState = WindowState.Minimized;
        }

        private void CloseWindowClick()
        {
            iOService.Save(currentData);
            window.Close();
        }
    }
}
