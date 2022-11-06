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
    class Line3D
    {
        private Vector3 pointA;
        private Vector3 pointB;
        private Vector3 pointC;
        private bool visibility;
        private float width;
        private Color color;
        private float BIG_SIZE = 5.0f;
        private float DEFAULT_SIZE = 1.0f;
        public Line3D(Randomizer r)
        {
            pointA = new Vector3(0, 0, 0);
            pointB = new Vector3(10, 0, 0);
            pointC = new Vector3(1, 0, 4);
            visibility = true;
            width = 1.0f;
            color = r.RandomColor();
        }
        public void Draw()
        {
            if (visibility)
            {
                //desenare linie
                GL.LineWidth(width);
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(color);
                GL.Vertex3(pointA);
                GL.Vertex3(pointB);
                GL.End();
                //sfarsit desenare linie
            }
        }
        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void ToggleWidth()
        {
            if (width == DEFAULT_SIZE)
            {
                width = BIG_SIZE;
            }
            else
            {
                width = DEFAULT_SIZE;
            }
        }
        public void DiscoMode(Randomizer r)
        {
            color = r.RandomColor();
        }
    }
}
