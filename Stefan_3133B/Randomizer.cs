using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_3133B
{
    class Randomizer
    {
        private const int MIN_VALUE= -25;
        private const int MAX_VALUE = 25;
        private Random r = new Random();
        public Randomizer()
        {
            r = new Random();
        }
        /// <summary>
        /// aceasta metoda returneaza o culoare random
        /// </summary>
        /// <returns></returns>
        public Color RandomColor()
        {
            int genR = r.Next(0, 255);//genereaza un numar random intre 0 si 255
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);
            return Color.FromArgb(genR, genG, genB);
        }
        /// <summary>
        /// metoda genereaza puncte cu coordonate random, ale caror valori se iau din intervalul [-25,25]
        /// </summary>
        /// <returns>metoda returneaza puncte 3D </returns>
        public Vector3 Generate3DPoint()
        {
            int a = r.Next(MIN_VALUE, MAX_VALUE);
            int b = r.Next(MIN_VALUE, MAX_VALUE);
            int c = r.Next(MIN_VALUE, MAX_VALUE);
            Vector3 vec = new Vector3(a, b, c);
            return vec;
        }
        public int GeneratePositiveInt(int limit)
        {
            int a = r.Next(0, limit);
            return a;
        }
    }
}
