using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace DbdSSUploader
{

    public partial class MainForm : Form
    {
        FileWatcher FileW;
        private bool acceptData = false;
        private string ext = "";
        private string filename = "";
        public MainForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Started...";
            FileW = new FileWatcher(currentSession,this);
            
        }
        public void updateLbl(string newMsg) 
        {
            
            this.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                toolStripStatusLabel1.Text = newMsg;
            });
        }
        private void isWatching_CheckedChanged(object sender, EventArgs e)
        {
           
            if (isWatching.Checked)
            {
                toolStripStatusLabel1.Text = "Waiting...";
                FileW.Start();
            }
            else 
            {
                FileW.Stop();
            }

        }

        private void reuploadBtn_Click(object sender, EventArgs e)
        {
            if (currentSession.SelectedItems.Count > 0)
            {

            }
            else 
            {
            
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
            if (data != null)
            {
                if ((data.Length == 1) && (data.GetValue(0) is String))
                {
                    filename = ((string[])data)[0];
                    ext = Path.GetExtension(filename).ToLower();
                    if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp"))
                    {
                        e.Effect = DragDropEffects.All;
                    }
                }
            }
        }

        private void MainForm_DragLeave(object sender, EventArgs e)
        {
            ext = "";
            filename = "";
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            MessageBox.Show("Dropped");
        }
    }
}
