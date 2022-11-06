using OpenTK;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_3133B
{
    class AdminFis
    {
        string numeFisier;
        public AdminFis()
        {
            numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
        }
        public List<List<float>> GetCoordonate()
        {
            List<List<float>> list = new List<List<float>>();
            foreach(string line in System.IO.File.ReadLines(numeFisier))
            {
                list.Add(line.Split(',')?.Select(float.Parse)?.ToList());
            }    
            return list;
        }
    }
}
