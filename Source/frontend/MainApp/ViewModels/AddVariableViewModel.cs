using frontend.Domain;
using frontend.Service;
using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace MainApp.ViewModels
{
    public class AddVariableViewModel : INotifyPropertyChanged
    {
        private IVariableService service;


        private Variable currentVariable;


        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddVariableViewModel(IVariableService service)
        {
            this.service = service;
            LoadData();
            LoadCommands();
        }



        public Variable CurrentVariable
        {
            get
            {
                return currentVariable;
            }
            set
            {
                currentVariable = value;
                RaisePropertyChanged("CurrentVariable");
            }
        }

        private void LoadData()
        {



            CurrentVariable = new Variable();
        }

        private void LoadCommands()
        {
            AddCommand = new RelayCommand<ContentDialog>(AddVariable, CanAddVariable);
        }

        private bool CanAddVariable(object obj)
        {
            return CurrentVariable != null;
        }

        private void AddVariable(ContentDialog dialog)
        {
            try
            {


                service.Add(CurrentVariable);
                dialog.Title = "Succesfull!";
                dialog.Hide();
            }
            catch (Exception)
            {
                dialog.Title = "Error! Please try again";
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
