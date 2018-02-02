using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Turing_Machine.TuringMachineLib
{
    static class Program
    {

        
        

        [STAThread]
        static void Main()
        {

            mainWindow window = new mainWindow();

            Application.Run(window);
        }
    }
}
