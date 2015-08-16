using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EdnaUtility.Data;
using EdnaUtility.Drivers;

namespace EdnaUtility
{
    public partial class Form1 : Form
    {
        private RealtimeClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.maskedTextBox1.Text = "fysis.u1dcsai.A0002";
            this.maskedTextBox2.Text = DateTime.Now.AddMinutes(-2).ToString();
            //this.maskedTextBox3.Text = "2015-05-08 15:00:00";
            this.maskedTextBox3.Text = DateTime.Now.ToString();
            this.maskedTextBox1.GotFocus += (s, a) =>
            {
                this.maskedTextBox1.SelectAll();
            };
            this.maskedTextBox2.GotFocus += (s, a) =>
            {
                this.maskedTextBox2.SelectAll();
            };
            this.maskedTextBox3.GotFocus += (s, a) =>
            {
                this.maskedTextBox3.SelectAll();
            };
            try
            {
                this.client = new eDNA();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var pn = this.maskedTextBox1.Text;
                if (string.IsNullOrEmpty(pn))
                {
                    this.maskedTextBox1.Focus();
                    MessageBox.Show("请输入点名!");
                    return;
                }
                var st = this.maskedTextBox2.Text;
                var et = this.maskedTextBox3.Text;
                DateTime start;
                DateTime end;
                if (!DateTime.TryParse(st, out start))
                {
                    this.maskedTextBox2.Focus();
                    MessageBox.Show("开始时刻时间格式不正确！");
                    return;
                }
                if (!DateTime.TryParse(et, out end))
                {
                    this.maskedTextBox3.Focus();
                    MessageBox.Show("结束时刻时间格式不正确！");
                    return;
                }
                int interval = int.Parse(this.textBox1.Text);
                var sample = TimeSpan.FromSeconds(interval);

                var pt = new PointModel { Name = pn };
                var max = this.client.Statis(pt, start, end, StatisType.Maximum);
                var min = this.client.Statis(pt, start, end, StatisType.Minimum);
                var avg = this.client.Statis(pt, start, end, StatisType.Average);
                var hist_st = this.client.Hist(pt, start);
                var hist_et = this.client.Hist(pt, end);
                //var hist_all = this.client.Hist(pt, start, end,sample);
                var msg = string.Format("MAX:{0:F4}\n\rMIN:{1:F4}\n\rAVG:{2:F4}\n\r{3:yyyy-MM-dd HH:mm:ss}\t{4:F4}\\n\r{5:yyyy-MM-dd HH:mm:ss}\t{6:F4}", max, min, avg, hist_st.Time, hist_st.Value, hist_et.Time, hist_et.Value);
                this.label4.Text = msg;
                this.listBox1.Items.Clear(); 
                //foreach (var data in hist_all)
                //{
                //    this.listBox1.Items.Add(string.Format("{0:yyyy-MM-dd HH:mm:ss}\t{1:F4}", data.Time, data.Value));
                //}
                while (start < end)
                {
                    this.listBox1.Items.Add(string.Format("{0:yyyy-MM-dd HH:mm:ss}\t{1:F4}", this.client.Hist(pt, start).Time, this.client.Hist(pt, start).Value));
                    start=start.AddSeconds(interval);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
