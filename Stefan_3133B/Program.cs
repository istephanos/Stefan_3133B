using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_3133B
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Window3D ex=new Window3D();
            ex.Run(30.0,0.0);
        }
    }
}
