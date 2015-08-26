using CountdownApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountdownApp
{
    public partial class MainForm : Form
    {
        private Queue<Thread> _cThreads;
        private int _threadCount;

        public MainForm()
        {
            InitializeComponent();
            _cThreads = new Queue<Thread>();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            var cdc = new CountdownController();
            Thread t = new Thread(() => cdc.DoCountdown(10)) { Name = "Thread " + _threadCount++ };
            _cThreads.Enqueue(t);
            threadList.AppendText(t.Name + "\r\n");
            t.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (_cThreads.Count == 0)
                return;

            Thread t = _cThreads.Dequeue();
            threadList.Text = threadList.Text.Replace(t.Name + "\r\n", string.Empty);
            t.Abort();
        }
    }
}
