using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace WinFormUI
{
    public partial class frmMain : Form
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        public frmMain()
        {
            InitializeComponent();
            cmbChoice.SelectedIndex = 0;  
           
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
        private void Initialize(string textArea)
        {
          
            synthesizer.SetOutputToDefaultAudioDevice();
            synthesizer.SpeakAsync(textArea);
 
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            { 
                Initialize(txtTextArea.Text);
                btnStart.Text = "Stop"; 
            }
            else if (btnStart.Text == "Stop")
            {
                synthesizer.SpeakAsyncCancelAll();
                btnStart.Text = "Start";
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (btnPause.Text == "Pause")
            {
                synthesizer.Pause();
                btnPause.Text = "Resume";
            }
            else if (btnPause.Text == "Resume")
            {
                synthesizer.Resume();
                btnPause.Text = "Pause";
            }
        }
    }
}
