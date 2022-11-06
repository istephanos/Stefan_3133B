using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefan_3133B
{
    class Window3D : GameWindow
    {
        private KeyboardState previousKeyboard;
        private Randomizer rando;
        private Line3D firstline;
        private Triunghi3D triangle1;
        Color DEFAULT_BKG_COLOR = Color.Goldenrod;
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            rando = new Randomizer();
            firstline = new Line3D(rando);
            triangle1 = new Triunghi3D(rando);
            DisplayHelp();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //set background
            GL.ClearColor(DEFAULT_BKG_COLOR);

            //set viewport
            GL.Viewport(0, 0, this.Width, this.Height);

            //set perspective
            Matrix4 perspectiva = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / (float)this.Height, 1, 350);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspectiva);

            //set the eye(camera)
            Matrix4 eye = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref eye);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //logic code
            KeyboardState currentKeyboard = Keyboard.GetState();

            if (currentKeyboard[Key.Escape])
            {
                Exit();
            }

            if (currentKeyboard[Key.H] && !previousKeyboard[Key.H])
            {
                DisplayHelp();
            }
            //modificare fundal cu culoare randomizata
            if (currentKeyboard[Key.B] && !previousKeyboard[Key.B])
            {
                GL.ClearColor(rando.RandomColor());
            }
            //revenire la culoarea default de fundal
            if (currentKeyboard[Key.R] && !previousKeyboard[Key.R])
            {
                GL.ClearColor(DEFAULT_BKG_COLOR);
            }
            //activare/dezactivare disco mode :)
            if (currentKeyboard[Key.X] && !previousKeyboard[Key.X])
            {
                firstline.DiscoMode(rando);
            }
            //activare/dezactivare vizibilitate linie
            if (currentKeyboard[Key.V] && !previousKeyboard[Key.V])
            {
                firstline.ToggleVisibility();
            }
            //modificare grosime linie
            if (currentKeyboard[Key.Z] && !previousKeyboard[Key.Z])
            {
                firstline.ToggleWidth();
            }
            previousKeyboard = currentKeyboard;
            //manipulare triunghi
            if (currentKeyboard[Key.T] && !previousKeyboard[Key.T])
            {
                firstline.ToggleWidth();
            }
            //end logic code
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            //render code
            firstline.Draw();
            triangle1.Draw();
            //end render code
            SwapBuffers();
        }
        //user manual :))
        private void DisplayHelp()
        {
            Console.WriteLine("\n================MENIU===============");
            Console.WriteLine("H   - MENIU");
            Console.WriteLine("ESC - inchidere aplicatie");
            Console.WriteLine("B   - schimbare culoare de fundal");
            Console.WriteLine("R   - resetare la valori implicite");
            Console.WriteLine("X   - DISCO MODE");
            Console.WriteLine("V   - visibilitate linie");
            Console.WriteLine("Z   - schimbare grosime linie");
            Console.WriteLine("T   - afisare/ascundere triunghi");
        }
    }
}
