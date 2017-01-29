using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XRPCLib;

namespace Virtua_Fighter_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static XRPC Jtag = new XRPC();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jtag.Connect();
            if (Jtag.activeConnection)
            {
                label1.Text = "XRPC connected";
                Jtag.Notify(XRPC.XNotiyLogo.FLASHING_HAPPY_FACE, "XRPC Connected!");
            }
            else
            {
                label1.Text = "XRPC connection failed";
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                Jtag.Notify(XRPC.XNotiyLogo.FLASHING_FROWNING_FACE, "Infinite health: DISABLED");
                timer1.Enabled = false;
            }
            else
            {
                Jtag.Notify(XRPC.XNotiyLogo.FLASHING_HAPPY_FACE, "Infinite health: ENABLED");
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] array = BitConverter.GetBytes((uint)0xA0);
            Jtag.SetMemory(0xC21EDF54, array);
        }
    }
}
