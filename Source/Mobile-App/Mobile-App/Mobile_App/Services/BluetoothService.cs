using Android.Bluetooth;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_App.Services
{
    class BluetoothService
    {
        private const string UUIDPROFILE = "00001101-0000-1000-8000-00805F9834FE";
        private BluetoothDevice result;
        private BluetoothSocket mSocket;
        private BufferedReader reader;

        public BluetoothService() {
            reader = null;
        }
        private void OpenDeviceConnection() {

        }
    }
}
