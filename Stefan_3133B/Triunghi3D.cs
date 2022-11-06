using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_3133B
{
    /// <summary>
    /// aceasta clasa este responsabila cu desenarea de triunghiuri
    /// </summary>
    class Triunghi3D
    {
        AdminFis AdminFis = new AdminFis();
        List<List<float>> floats = new List<List<float>>();
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private Color color1;
        private Color color2;
        private Color color3;
        private bool visibility;
        private float linewidth;
        private Randomizer localRandomizer;
        public Triunghi3D(Randomizer r)
        {
            floats = AdminFis.GetCoordonate();
            pointA.X = floats[0][0];
            pointA.Y = floats[0][1];
            pointA.Z = floats[0][2];
            pointB.X = floats[1][0];
            pointB.Y = floats[1][1];
            pointB.Z = floats[1][2];
            pointC.X = floats[2][0];
            pointC.Y = floats[2][1];
            pointC.Z = floats[2][2];
            // pointA = r.Generate3DPoint();
            //pointB = r.Generate3DPoint();
            // pointC = r.Generate3DPoint();
            color1 = r.RandomColor();
            color2 = r.RandomColor();
            color3 = r.RandomColor();
            visibility = true;
            linewidth = 2.0f;
            localRandomizer = r;
        }
        /// <summary>
        /// metoda Draw() deseneaza atunci cand este apelata un triunghi cu coordonatele punctelor luate din fisierul text 
        /// toate cele 3 varfuri avand culori diferite generate random
        /// </summary>
        public void Draw()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Triangles);
                GL.Color3(color1);
                GL.Vertex3(pointA);
                GL.Color3(color2);
                GL.Vertex3(pointB);
                GL.Color3(color3);
                GL.Vertex3(pointC);

                GL.End();
            }

        }
        /// <summary>
        /// functia activeaza/dezactiveaza vizibilitatea triunghiului
        /// </summary>
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }
        public void Morph()
        {
            int select = localRandomizer.GeneratePositiveInt(2);
            Vector3 aux = localRandomizer.Generate3DPoint();
            if (select == 0)
            {
                pointA = aux;
            }
            else
            {
                pointB = aux;

            }
        }
    }
}