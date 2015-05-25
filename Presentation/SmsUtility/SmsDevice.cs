using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmsUtility
{
    public class SmsDevice : IDisposable
    {
        private SerialPort fSerialPort;

        private ManualResetEvent _mre4out = new ManualResetEvent(true);
        private ManualResetEvent _mre4enter = new ManualResetEvent(true);
        private string _currentPhoneNumber;
        private string _currentMessage;

        private object _sync = new object();

        private bool bHeadFinded;

        private bool send_Succeed;


        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
        private int iSeachHead = 0;
        private int iSeachTail = 0;

        private int iSearchSucess = 0;
        private int iSearchFail = 0;
        byte[] bufSucess;
        byte[] bufFail;
        byte[] bufHead;
        byte[] bufTail;
        byte[] bufSms = new byte[500];
        int ibufSms;

        public SmsDevice(string portName)
        {
            fSerialPort = new SerialPort();
            fSerialPort.BaudRate = 9600;
            fSerialPort.PortName = portName;
            fSerialPort.Encoding = Encoding.GetEncoding("GBK");
            fSerialPort.Open();
            fSerialPort.DataReceived += MyDataReceived;


            int i;
            ibufSms = 0;
            bHeadFinded = false;
            string s = "SMS_SEND_SUCESS";
            bufSucess = System.Text.Encoding.Default.GetBytes(s);
            s = "SMS_SEND_FAIL";
            bufFail = System.Text.Encoding.Default.GetBytes(s);
            s = "+CMS:";
            bufHead = System.Text.Encoding.Default.GetBytes(s);
            s = "\r\n\0\0";
            bufTail = System.Text.Encoding.Default.GetBytes(s);
            i = bufTail.Length;
        }

        public void SendSms(string[] phoneNumbers, string message)
        {
            foreach (var item in phoneNumbers)
            {
                SendSms(item, message);
            }
        }

        public async void SendSmsAsync(string[] phoneNumbers, string message)
        {
            await Task.Run(() =>
            {
                foreach (var item in phoneNumbers)
                {
                    SendSms(item, message);
                }
            });
        }

        public void SendSms(string phoneNumber, string message)
        {
            _mre4enter.WaitOne(5000);
            _mre4enter.Reset();


            _mre4out.Reset();
            _currentPhoneNumber = phoneNumber;
            _currentMessage = message;
            Log("SendSms.txt", "----------------------------------------------------------------------------");
            Log("SendSms.txt", string.Format("正在发送......,{0},{1}", _currentPhoneNumber, _currentMessage));
            this.SendDTU();
            _mre4out.WaitOne(5000);


            _mre4enter.Set();
        }

        public void Dispose()
        {
            if (fSerialPort.IsOpen)
            {
                fSerialPort.Close();
            }
        }

        private void Log(string filename, string text)
        {
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                using (var sw = new StreamWriter(fs))
                {
                    fs.Seek(0, SeekOrigin.End);
                    sw.WriteLine("{0},{1}", DateTime.Now.ToLocalTime(), text);
                }
            }
        }

        private void SendDTU()
        {
            _mre4out.Set();
            return;
            string str_Content = _currentPhoneNumber + ":0:" + _currentMessage;
            fSerialPort.Write(str_Content);
        }

        private int SearchStrInStream(byte[] strToCmp, byte c, ref int i)
        {
            if (i > strToCmp.Length)
            {
                i = 0;
                return 0;
            }
            if (i != 0)
            {
                if (c != strToCmp[i])
                    i = 0;
            }
            if (c == strToCmp[i])
            {
                (i)++;
            }
            if ((int)(i) == strToCmp.Length)
            {

                i = 0;
                return 1;
            }
            return 0;
        }

        private void MyDataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            int i;
            int n = fSerialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
            byte[] buf = new byte[n];//声明一个临时数组存储当前来的串口数据

            fSerialPort.Read(buf, 0, n);//读取缓冲数据

            for (i = 0; i < n; i++)
            {
                if (1 == SearchStrInStream(bufSucess, buf[i], ref iSearchSucess))
                {
                    send_Succeed = true;

                    Log("SendSms.txt", string.Format("发送成功,{0},{1}", _currentPhoneNumber, _currentMessage));
                    _mre4out.Set();
                }

                if (1 == SearchStrInStream(bufFail, buf[i], ref iSearchFail))
                {
                    send_Succeed = false;
                    Log("SendSms.txt", string.Format("发送成功,{0},{1}", _currentPhoneNumber, _currentMessage));
                    _mre4out.Set();
                }

                //处理接收短信的部分，通过包头包围将短信内容分析出来，如果用户不需接收，不用关注
                if (bHeadFinded == true)
                {
                    bufSms[ibufSms] = buf[i];
                    ibufSms++;
                    if (1 == SearchStrInStream(bufTail, buf[i], ref iSeachTail))
                    {
                        bHeadFinded = false;
                        builder.Remove(0, builder.Length);
                        builder.Append(Encoding.GetEncoding("GBK").GetString(bufSms));

                        Log("RcvSms.txt", builder.ToString());

                        _mre4out.Set();
                    }
                }
                if (1 == SearchStrInStream(bufHead, buf[i], ref iSeachHead))
                {
                    bHeadFinded = true;
                    ibufSms = 0;
                }
            }
        }
    }
}
