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
using System.Diagnostics;

namespace SOCD_Window_Form_Test_3
{
    public partial class Form1 : Form
    {
        Feeder feeder = new Feeder();
        public static bool joyDriveTest = true;
        public static string[] tempKeys = new string[21];
        public static bool run = true;
        KeyD keyDEvent = new KeyD();
        public static bool UpPrio = false;


        public Form1()
        {
            if (!File.Exists("KeyBindings.txt"))
            {
                KeyBindings.InitialBinder();
            }
            KeyBindings.ReadBind();
            feeder.StartFeeder();
            if (!joyDriveTest)
            {
                feeder.Relinq();
                this.Close();
            }
            InitializeComponent();
            UpY.SelectedItem = KeyBindings.binds[0];
            LeftX.SelectedItem = KeyBindings.binds[1];
            DownY.SelectedItem = KeyBindings.binds[2];
            RightX.SelectedItem = KeyBindings.binds[3];
            button0Bind.SelectedItem = KeyBindings.binds[4];
            button1Bind.SelectedItem = KeyBindings.binds[5];
            button2Bind.SelectedItem = KeyBindings.binds[6];
            button3Bind.SelectedItem = KeyBindings.binds[7];
            button4Bind.SelectedItem = KeyBindings.binds[8];
            button5Bind.SelectedItem = KeyBindings.binds[9];
            button6Bind.SelectedItem = KeyBindings.binds[10];
            button7Bind.SelectedItem = KeyBindings.binds[11];
            button8Bind.SelectedItem = KeyBindings.binds[12];
            button9Bind.SelectedItem = KeyBindings.binds[13];
            button10Bind.SelectedItem = KeyBindings.binds[14];
            button11Bind.SelectedItem = KeyBindings.binds[15];
            button12Bind.SelectedItem = KeyBindings.binds[16];
            button13Bind.SelectedItem = KeyBindings.binds[17];
            button14Bind.SelectedItem = KeyBindings.binds[18];
            button15Bind.SelectedItem = KeyBindings.binds[19];
            checkBox2.Checked = KeyIntercepter.send;
            feeder.SubscribeDown();
            feeder.SubscribeUp();


        }

        private void UpY_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[0] = UpY.SelectedItem.ToString();
        }

        private void LeftX_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[1] = LeftX.SelectedItem.ToString();
        }

        private void DownY_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[2] = DownY.SelectedItem.ToString();
        }

        private void RightX_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[3] = RightX.SelectedItem.ToString();
        }

        private void button0Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[4] = button0Bind.SelectedItem.ToString();
        }

        private void button1Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[5] = button1Bind.SelectedItem.ToString();
        }

        private void button2Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[6] = button2Bind.SelectedItem.ToString();
        }

        private void button3Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[7] = button3Bind.SelectedItem.ToString();
        }

        private void button4Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[8] = button4Bind.SelectedItem.ToString();
        }

        private void button5Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[9] = button5Bind.SelectedItem.ToString();
        }

        private void button6Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[10] = button6Bind.SelectedItem.ToString();
        }

        private void button7Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[11] = button7Bind.SelectedItem.ToString();
        }

        private void button8Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[12] = button8Bind.SelectedItem.ToString();
        }

        private void button9Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[13] = button9Bind.SelectedItem.ToString();
        }

        private void button10Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[14] = button10Bind.SelectedItem.ToString();
        }

        private void button11Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[15] = button11Bind.SelectedItem.ToString();
        }

        private void button12Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[16] = button12Bind.SelectedItem.ToString();
        }

        private void button13Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[17] = button13Bind.SelectedItem.ToString();
        }

        private void button14Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[18] = button14Bind.SelectedItem.ToString();
        }

        private void button15Bind_SelectedIndexChanged(object sender, EventArgs e)
        {
            tempKeys[19] = button15Bind.SelectedItem.ToString();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            run = false;
            this.feeder.Relinq();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                KeyIntercepter.block = true;
            }
            else KeyIntercepter.block = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            KeyBindings.Binder();
            KeyBindings.ReadBind();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                KeyIntercepter.send = true;
            }
            else KeyIntercepter.send = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                UpPrio = true;
            }
            else UpPrio = false;
        }

    }
}

