using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbdSSUploader
{
    public partial class MainForm : Form
    {
        FileWatcher FileW;
        public MainForm()
        {
            InitializeComponent();
            FileW = new FileWatcher(currentSession);
            
        }

        private void isWatching_CheckedChanged(object sender, EventArgs e)
        {
           
            if (isWatching.Checked)
            {
                FileW.Start();
            }
            else 
            {
                //FileW stop
            }

        }
    }
}
