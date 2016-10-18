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

namespace GTA_SanAndreas
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

        private void button2_Click(object sender, EventArgs e)
        {
            Jtag.Notify(XRPC.XNotiyLogo.FLASHING_HAPPY_FACE, "Lots of Money!");
            Jtag.SetMemory(0xC22318C9, new Byte[] { 0x99, 0x99, 0x99, 0x99 });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Jtag.Notify(XRPC.XNotiyLogo.FAMILY_TIMER_X_TIME_REMAINING, "Going forward in time 1 hour");
            Jtag.SetMemory(0xC2259272, new Byte[] { 0x3C });
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
            byte[] array = BitConverter.GetBytes((uint)0x42F8);
            Jtag.SetMemory(0xC5575440, array);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Jtag.SetMemory(0xC55754E3, new Byte[] { 0x99 }); //pistol
            Jtag.SetMemory(0xC55754E7, new Byte[] { 0x99 });
            Jtag.SetMemory(0xC5575503, new Byte[] { 0x99 }); //shotgun
            Jtag.SetMemory(0xC557551F, new Byte[] { 0x99 }); //uzi
            Jtag.SetMemory(0xC557551B, new Byte[] { 0x99 });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true)
            {
                Jtag.Notify(XRPC.XNotiyLogo.FLASHING_FROWNING_FACE, "Infinite ammo: DISABLED");
                timer2.Enabled = false;
            }
            else
            {
                Jtag.Notify(XRPC.XNotiyLogo.FLASHING_HAPPY_FACE, "Infinite ammo: ENABLED");
                timer2.Enabled = true;
            }
        }
    }
}
