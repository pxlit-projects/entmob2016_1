using Android.Bluetooth;
using Java.IO;
using Java.Util;
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
        private InputStreamReader mReader;
        private System.IO.Stream mStream;

        private UUID GetUUIDFromString() {
            return UUID.FromString(UUIDPROFILE);
        }
        private void Close(IDisposable aConnectedObject) {
            if (aConnectedObject == null) return;
            try
            {
                aConnectedObject.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            aConnectedObject = null;
        }
        public BluetoothService() {
            reader = null;
        }
        private void OpenDeviceConnection(BluetoothDevice btDevice) {
            try
            {
                mSocket = btDevice.CreateRfcommSocketToServiceRecord(GetUUIDFromString());
                mSocket.Connect();
                mStream = mSocket.InputStream;
                mReader = new InputStreamReader(mStream);
            }
            catch (IOException e)
            {
                //Close(mSocket);
                Close(mStream);
                //Close(mReader);
                throw e;
            }
        }
        public String GetDataFromDevice() {
            return mReader.Read().ToString();
        }
        public void getAllPairedDevices() {
            BluetoothAdapter btAdapter = BluetoothAdapter.DefaultAdapter;
            var devices = btAdapter.BondedDevices;
            if (devices != null && devices.Count > 0) {
                foreach (BluetoothDevice mDevice in devices)
                {
                    OpenDeviceConnection(mDevice);
                }
            }
        }
    }
}
