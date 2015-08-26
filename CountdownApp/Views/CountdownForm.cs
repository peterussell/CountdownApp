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

namespace CountdownApp.Views
{
    public partial class CountdownForm : Form
    {
        public event EventHandler<EventArgs> OnCountdownComplete;
        public event EventHandler<EventArgs> OnCountdownStopped;

        public CountdownForm()
        {
            InitializeComponent();
        }

        public void DoCountdown(int time)
        {
            for (int i = time; i > 0; i--)
            {
                counter.Text = i.ToString();
                this.Refresh();
                Thread.Sleep(1000);
            }

            if (OnCountdownComplete != null)
                OnCountdownComplete(this, new EventArgs());
        }

        public void Stop()
        {
            if (OnCountdownStopped != null)
                OnCountdownStopped(this, new EventArgs());
        }
    }
}
