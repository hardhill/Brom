using Brom.Servers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brom
{
    public partial class frmMain : Form
    {
        Some some;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //load window
            some = new Some();
            some.OnChangeCount += Some_OnChangeCount;
        }

        private void Some_OnChangeCount(long e)
        {
            BeginInvoke((Action)(() =>
            {
                Text = Convert.ToString(e);
            }));

        }

        private void bHttp_Click(object sender, EventArgs e)
        {
            if (!some.Running)
            {
                some.StartAsync();
            }
            else
            {
                some.Stop();
            }
        }
    }
}
