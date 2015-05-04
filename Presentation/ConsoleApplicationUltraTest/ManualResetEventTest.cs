using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplicationUltraTest
{
    public class MockDeviceTest
    {
        private ManualResetEvent _mre = new ManualResetEvent(true);
        private MockSerialPort _serialPort;
        public MockDeviceTest()
        {
            _serialPort = new MockSerialPort();
            _serialPort.DataReceived += _serialPort_DataReceived;
        }

        void _serialPort_DataReceived(string obj)
        {
            Console.WriteLine(obj);
            _mre.Set();
        }

        public void SendSms(string[] phoneNumbers, string message)
        {
            foreach (var item in phoneNumbers)
            {
                SendSms(item, message);
            }
        }

        public void SendSmsAysc(string[] phoneNumbers, string message)
        {
            foreach (var item in phoneNumbers)
            {
                SendSms(item, message);
            }
        }

        public void SendSms(string phoneNumber, string message)
        {
            //System.Threading.Thread.Sleep(3000);
            _mre.WaitOne(5000);
            _serialPort.WriteLine(string.Format("{0}:{1}:{2}", phoneNumber, "0", message));
            Console.WriteLine(DateTime.Now.ToString("mm:hh:ss \t") + "sended to port");
            _mre.Reset();
        }
    }

    public class MockSerialPort
    {
        private Random _random = new Random();
        public event Action<string> DataReceived;

        public void WriteLine(string text)
        {
            Task.Run(() => Practice(text));
        }

        private void Practice(string text)
        {
            System.Threading.Thread.Sleep(10000);
            if (_random.Next(10) > 5)
            {
                DataReceived("Send_Success");
            }
            else
            {
                DataReceived("Send_Fail");
            }
        }
    }
}
