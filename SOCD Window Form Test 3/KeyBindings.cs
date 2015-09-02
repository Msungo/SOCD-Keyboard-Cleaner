using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SOCD_Window_Form_Test_3
{
    static class KeyBindings
    {
        public static string[] binds = new string[20];

        public static void InitialBinder()
        {
            StreamWriter bindingsWriter = new StreamWriter("KeyBindings.txt");
            foreach (string bind in binds)
            {
                if (bind != null)
                {
                    bindingsWriter.WriteLine(bind, false);
                }
                else bindingsWriter.WriteLine("None", false);
            }
            bindingsWriter.Dispose();
        }

        public static void Binder()
        {
            StreamWriter bindingsWriter = new StreamWriter("KeyBindings.txt");
            foreach (string bind in Form1.tempKeys)
            {
                if (bind != null)
                {
                    bindingsWriter.WriteLine(bind, false);
                }
                else bindingsWriter.WriteLine("None", false);
            }
            bindingsWriter.Dispose();
        }
        public static void ReadBind()
        {
                string temp;

                    StreamReader sr = new StreamReader("KeyBindings.txt");
                    for (int i = 0; i < (binds.Length); i++)
                    {
                        temp = sr.ReadLine();
                        if (temp != null)
                        {
                            binds[i] = temp;
                        }
                        else binds[i] = "None";
                    }
                    sr.Dispose();

        }
    }

}
