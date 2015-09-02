using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using vJoyInterfaceWrap;
using System.IO;

namespace SOCD_Window_Form_Test_3
{
    class Feeder
    {
        private vJoy joystick = new vJoy();

        private bool upKeyBool = false;
        private bool leftKeyBool = false;
        private bool downKeyBool = false;
        private bool rightKeyBool = false;

        private bool[] buttonsBool = new bool[16];


        public void SubscribeDown()
        {
            KeyD.keyDownEvent += new KeyDEventHandler(HeardDown);
        }
        private void HeardDown(KeyDEventArgs e)
        {
        RunFeederDown(e);
        }

        public void SubscribeUp()
        {
            KeyUp.keyUpEvent += new KeyUpEventHandler(HeardUp);
        }
        private void HeardUp(KeyUpEventArgs e)
        {
            RunFeederUp(e);
        }



        public void StartFeeder()
        {

            joystick.AcquireVJD(1);
            joystick.ResetVJD(1);

        }






        public void Relinq()
        {
            joystick.RelinquishVJD(1);
        }

        public void RunFeederDown(KeyDEventArgs e)
        {
            long maxval = 0;
            int X, Y;
            joystick.GetVJDAxisMax(1, HID_USAGES.HID_USAGE_X, ref maxval);

            if (e.KeyD == KeyBindings.binds[0])
            {
                upKeyBool = true;
                if (downKeyBool)
                {
                    if (Form1.UpPrio)
                    {
                        Y = (int)0;
                        joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                    }
                    else
                    {
                        Y = (int)((maxval / 2) + 1.2);
                        joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                    }
                }
                else
                {
                    Y = (int)0;
                    joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                }
            }
            else if (e.KeyD == KeyBindings.binds[1])
            {
                leftKeyBool = true;
                if (rightKeyBool)
                {
                    X = (int)((maxval / 2) + 1.2);
                    joystick.SetAxis(X, 1, HID_USAGES.HID_USAGE_X);
                }
                else
                {
                    X = 0;
                    joystick.SetAxis(X, 1, HID_USAGES.HID_USAGE_X);
                }

            }
            else if (e.KeyD == KeyBindings.binds[2])
            {
                downKeyBool = true;
                if (upKeyBool)
                {
                    if (Form1.UpPrio)
                    {
                        Y = (int)0;
                        joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                    }
                    else
                    {
                        Y = (int)((maxval / 2) + 1.2);
                        joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                    }
                }
                else
                {
                    Y = (int)(maxval);
                    joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                }
            }
            else if (e.KeyD == KeyBindings.binds[3])
            {
                rightKeyBool = true;
                if (leftKeyBool)
                {
                    X = (int)((maxval / 2) + 1.2);
                    joystick.SetAxis(X, 1, HID_USAGES.HID_USAGE_X);
                }
                else
                {
                    X = (int)(maxval);
                    joystick.SetAxis(X, 1, HID_USAGES.HID_USAGE_X);
                }
            }
            else
            {
                for (int i = 4; i < KeyBindings.binds.Length; i++)
                {
                    uint butid = (uint)(i - 3);
                    if (e.KeyD == KeyBindings.binds[i])
                    {
                        joystick.SetBtn(true, 1, butid);
                    }
                }
            }
        }



        public void RunFeederUp(KeyUpEventArgs e)
        {
            long maxval = 0;
            int X, Y;
            joystick.GetVJDAxisMax(1, HID_USAGES.HID_USAGE_X, ref maxval);

            if (e.KeyUp == KeyBindings.binds[0])
            {
                upKeyBool = false;
                if (downKeyBool)
                {
                    Y = (int)(maxval);
                    joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                }
                else
                {
                    Y = (int)((maxval / 2) + 1.2);
                    joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                }
            }
            else if (e.KeyUp == KeyBindings.binds[1])
            {
                leftKeyBool = false;
                if (rightKeyBool)
                {
                    X = (int)(maxval);
                    joystick.SetAxis(X, 1, HID_USAGES.HID_USAGE_X);
                }
                else
                {
                    X = (int)((maxval / 2) + 1.2);
                    joystick.SetAxis(X, 1, HID_USAGES.HID_USAGE_X);
                }

            }
            else if (e.KeyUp == KeyBindings.binds[2])
            {
                downKeyBool = false;
                if (upKeyBool)
                {
                    Y = 0;
                    joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                }
                else
                {
                    Y = (int)((maxval / 2) + 1.2);
                    joystick.SetAxis(Y, 1, HID_USAGES.HID_USAGE_Y);
                }
            }
            else if (e.KeyUp == KeyBindings.binds[3])
            {
                rightKeyBool = false;
                if (leftKeyBool)
                {
                    X = 0;
                    joystick.SetAxis(X, 1, HID_USAGES.HID_USAGE_X);
                }
                else
                {
                    X = (int)((maxval / 2) + 1.2);
                    joystick.SetAxis(X, 1, HID_USAGES.HID_USAGE_X);
                }
            }
            else
            {
                for (int i = 4; i < KeyBindings.binds.Length; i++)
                {
                    uint butid = (uint)(i - 3);
                    if (e.KeyUp == KeyBindings.binds[i])
                    {
                        joystick.SetBtn(false, 1, butid);
                    }
                }
            }
        }
    }
    }
