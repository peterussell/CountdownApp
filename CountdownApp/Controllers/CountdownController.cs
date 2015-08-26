using CountdownApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountdownApp.Controllers
{
    public class CountdownController
    {
        private CountdownForm _view;

        public CountdownController()
        {
            _view = new CountdownForm();
        }

        public void DoCountdown(int time)
        {
            _view.Show();
            _view.OnCountdownComplete += _view_OnCountdownComplete;
            _view.OnCountdownStopped += _view_OnCountdownStopped;
            _view.DoCountdown(time);
        }
        
        public void Stop()
        {
            _view.Stop();
        }

        private void _view_OnCountdownComplete(object sender, EventArgs e)
        {
            _view.Close();
        }

        private void _view_OnCountdownStopped(object sender, EventArgs e)
        {
            _view.Close();
        }
    }
}
