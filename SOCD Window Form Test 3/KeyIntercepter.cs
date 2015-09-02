using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SOCD_Window_Form_Test_3
{

    class KeyIntercepter
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static bool block = false;
        public static bool send = true;


        public static void Hook()
        {
            _hookID = SetHook(_proc);
        }

        public static void Unhook()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
        {


                int vkCode = Marshal.ReadInt32(lParam);
                string keyTest = ((Keys)vkCode).ToString();
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                {
                    foreach (string bind in KeyBindings.binds)
                    {
                        if (bind == keyTest)
                        {
                            if (send)
                            {
                                KeyDEventArgs keyD = new KeyDEventArgs();
                                keyD.KeyD = keyTest;
                                KeyD.OnkeyDownEvent(keyD);
                            }
                            if (block)
                            {
                                return (System.IntPtr)1;
                            }
                            else
                            {
                                return CallNextHookEx(_hookID, nCode, wParam, lParam);
                            }
                        }
                    }
                }


                if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
                {
                    foreach (string bind in KeyBindings.binds)
                    {
                        if (bind == keyTest)
                        {
                            if (send)
                            {
                                KeyUpEventArgs keyUp = new KeyUpEventArgs();
                                keyUp.KeyUp = keyTest;
                                KeyUp.OnkeyUpEvent(keyUp);
                            }
                            if (block)
                            {
                                return (System.IntPtr)1;
                            }
                            else
                            {
                                return CallNextHookEx(_hookID, nCode, wParam, lParam);
                            }
                        }
                    }
                }
            
            return CallNextHookEx(_hookID, nCode, wParam, lParam);

            
        }

    

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
    public class KeyD
    {
        public static event KeyDEventHandler keyDownEvent;
        
        public static void OnkeyDownEvent(KeyDEventArgs e)
        {
            if (keyDownEvent != null)
            {
            keyDownEvent(e);
            }
        }

    }
    public delegate void KeyDEventHandler(KeyDEventArgs e);
    public class KeyDEventArgs : EventArgs
    {
        public string KeyD { get; set; }
    }

    public class KeyUp
    {
        public static event KeyUpEventHandler keyUpEvent;

        public static void OnkeyUpEvent(KeyUpEventArgs e)
        {
            if (keyUpEvent != null)
            {
                keyUpEvent(e);
            }
        }

    }
    public delegate void KeyUpEventHandler(KeyUpEventArgs e);
    public class KeyUpEventArgs : EventArgs
    {
        public string KeyUp { get; set; }
    }
}

