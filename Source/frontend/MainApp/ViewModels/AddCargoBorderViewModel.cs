using frontend.Domain;
using frontend.Service;
using MainApp.Authentication;
using MainApp.Messages;
using MainApp.Navigation;
using MainApp.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainApp.ViewModels
{
    public class AddCargoBorderViewModel : INotifyPropertyChanged
    {
        private ICargoService cargoService;
        private IVariableService variableService;
        private ICargoBorderService cargoBorderService;
        private Cargo selectedCargo;
        private CargoBorder currentCargoBorder;
        private List<string> variableList;
        private string selectedVariable;

        public ICommand AddCommand { get; set; }

        public AddCargoBorderViewModel(ICargoService cargoService, IVariableService variableService, ICargoBorderService cargoBorderService)
        {
            this.cargoService = cargoService;
            this.variableService = variableService;
            this.cargoBorderService = cargoBorderService;
            LoadCommands();
            LoadData();
            Messenger.Default.Register<Cargo>(this, HandleCargoMessage);
        }

        private void HandleCargoMessage(Cargo cargo)
        {
            SelectedCargo = cargo;
        }

        private void LoadCommands()
        {
            AddCommand = new CustomCommand(AddBorder, null);
        }

        private void LoadData()
        {
            CurrentCargoBorder = new CargoBorder();
            VariableList = new List<string>();
            List<Variable> variables = variableService.All();
            variables.ForEach(v => VariableList.Add(v.Description));
        }

        public void AddBorder(object obj)
        {
            if (SelectedVariable != null)
            {
                List<Variable> variables = variableService.All();
                CurrentCargoBorder.Variable = variables.FirstOrDefault(v => v.Description == SelectedVariable);

                var cargoBorders = cargoBorderService.All();

                if (cargoBorders.Count > 0)
                {
                    var lastCargoBorderId = cargoBorders.Max(c => c.Cargo_border_id);
                    CurrentCargoBorder.Cargo_border_id = lastCargoBorderId + 1;
                }
                else
                {
                    CurrentCargoBorder.Cargo_border_id = 1;
                }
                
                SelectedCargo.Borders.Add(CurrentCargoBorder);
                cargoService.Update(SelectedCargo);
                new NavService().NavigateTo("Cargos");
            }
        }

        public Cargo SelectedCargo
        {
            get
            {
                return selectedCargo;
            }
            set
            {
                selectedCargo = value;
                RaisePropertyChanged("SelectedCargo");
            }
        }

        public CargoBorder CurrentCargoBorder
        {
            get
            {
                return currentCargoBorder;
            }
            set
            {
                currentCargoBorder = value;
                RaisePropertyChanged("CurrentCargoBorder");
            }
        }

        public List<string> VariableList
        {
            get
            {
                return variableList;
            }
            set
            {
                variableList = value;
            }
        }

        public string SelectedVariable
        {
            get
            {
                return selectedVariable;
            }
            set
            {
                selectedVariable = value;
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
