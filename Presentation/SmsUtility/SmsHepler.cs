using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmsUtility
{
    public class SmsDevice
    {
        private SerialPort _serialPort;
        private ManualResetEvent _mre = new ManualResetEvent(true);

        public SmsDevice()
        {
            _mre = new ManualResetEvent(true);
            _serialPort.DataReceived += SerialPort_DataReceived;
        }

        public void SendSms(string[] phoneNumbers, string message)
        {
            foreach (var item in phoneNumbers)
            {
                SendSms(item, message);
            }
        }

        public void SendSms(string phoneNumber, string message)
        {
            _mre.WaitOne();
            var text = SmsProtocol.GetText_SendSms(phoneNumber, message);
            _serialPort.WriteLine(text);
            _mre.Reset();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var n = _serialPort.BytesToRead;
            var buffer = new byte[n];
            _serialPort.Read(buffer, 0, buffer.Length);

            var str = Encoding.GetEncoding("GBK").GetString(buffer);



            _mre.Set();
        }
    }

    public class SmsProtocol
    {
        public const string SEND_SUCCESS = "SMS_SEND_SUCESS";
        public const string SEND_FAIL = "SMS_SEND_FAIL";

        public static string GetText_SendSms(string phoneNumber, string message)
        {
            return string.Format("{0}:{1}:{2}", phoneNumber, "0", message);
        }
    }
}
