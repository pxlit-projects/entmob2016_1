using frontend.Domain;
using Robotics.Mobile.Core.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_App.Services
{
    public class VariableMessage
    {
        public IDevice connectedDevice { get; set; }
        public IAdapter adapter { get; set; }
        public Employee employee { get; set; }
    }
}
