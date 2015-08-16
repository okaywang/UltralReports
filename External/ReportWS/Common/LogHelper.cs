using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rinch.Common
{
    public class LogHelper
    {
        public LogHelper()
        { 
        }
        private bool _createByHour = false;         
        public LogHelper(bool createByHour)
        {
            _createByHour = createByHour;
        }
        private string CreateLogErrorFile(bool ? isError = false)
        {
            string logFilePath = string.Empty;
            //获取程序运行的目录路径
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            string logDir = string.Format(@"{0}log\{1}",basePath,DateTime.Now.ToString("yyyy-MM-dd"));
            
            //以时间命名日志文件名，如果日志文件超过2M，自动创建新的
            logFilePath = string.Format(@"{0}\{1}_{2}.txt"
                    , logDir
                    , (isError.Value) ? "Error" : "Info"
                    , (_createByHour) ? DateTime.Now.ToString("yyyy-MM-dd HH") : DateTime.Now.ToString("yyyy-MM-dd"));
            
            if (!File.Exists(logFilePath))
            {
                try
                {
                    Directory.CreateDirectory(logDir);

                    StreamWriter sw = File.CreateText(logFilePath);
                    sw.Close();
                }
                catch (Exception ex)
                {                    
                    throw ex;
                }
            }
            return logFilePath;
        }
        private void Write(string fileName,string msg)
        {
            msg = string.Format("{0}:{1}", DateTime.Now, msg);
            try
            {
                FileInfo fi = new FileInfo(fileName);
                //日志文件大于5M则返回
                if (fi.Length>5*1024*1024)
                {
                    return;
                }
                FileStream fs = new FileStream(fileName, FileMode.Append);
                
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void WriteError(string error)
        {
            string currentFile = CreateLogErrorFile(true);

            Write(currentFile, error);
        }
        public void WriteInfo(string Info)
        {
            string currentFile = CreateLogErrorFile();

            Write(currentFile, Info);
        }
    }
}
