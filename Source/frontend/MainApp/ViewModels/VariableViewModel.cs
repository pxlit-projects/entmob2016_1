using frontend.Domain;
using frontend.Service;
using MainApp.Utility;
using MainApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class VariableViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Variable> variables;
        private Variable selectedVariable;

        public ICommand UpdateCommand { get; set; }

        public ICommand ShowCityDialogCommand { get; set; }

        private IVariableService service;

        public VariableViewModel(IVariableService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }

        public ObservableCollection<Variable> Variables
        {
            get
            {
                return variables;
            }
            set
            {
                variables = value;
                RaisePropertyChanged("Variables");
            }
        }

        public Variable SelectedVariable
        {
            get
            {
                return selectedVariable;
            }
            set
            {
                selectedVariable = value;
                RaisePropertyChanged("SelectedVariable");
            }
        }

        private void LoadData()
        {
            var dummy = service.All().OrderBy(d => d.Variable_id);
            Variables = new ObservableCollection<Variable>(dummy);
            SelectedVariable = variables.ElementAt(0);
        }

        private void LoadCommands()
        {
            UpdateCommand = new CustomCommand(Update, CanUpdate);

            ShowCityDialogCommand = new CustomCommand(ShowCityDialog, null);
        }

        private bool CanUpdate(object obj)
        {
            return SelectedVariable != null;
        }



        private void Update(object obj)
        {
            service.Update(SelectedVariable);
            LoadData();
        }




        public async void ShowCityDialog(object obj)
        {
            var dialog = new AddVariableDialog();
            var result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                LoadData();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
}
