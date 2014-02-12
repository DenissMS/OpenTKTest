// Released to the public domain. Use, modify and relicense at will.

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using OpenTK.Input;

namespace StarterKit
{
    class Game : GameWindow
    {
        /// <summary>Creates a 800x600 window with the specified title.</summary>
        public Game()
            : base(800, 600, GraphicsMode.Default, "OpenTK Quick Start Sample")
        {
            VSync = VSyncMode.On;
        }

        /// <summary>Load resources here.</summary>
        /// <param name="e">Not used.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.3f, 0.3f, 0.6f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
        }

        /// <summary>
        /// Called when your window is resized. Set your viewport here. It is also
        /// a good place to set up your projection matrix (which probably changes
        /// along when the aspect ratio of your window).
        /// </summary>
        /// <param name="e">Not used.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        /// <summary>
        /// Called when it is time to setup the next frame. Add you game logic here.
        /// </summary>
        /// <param name="e">Contains timing information for framerate independent logic.</param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            if (Keyboard[Key.Escape])
                Exit();
        }

        /// <summary>
        /// Called when it is time to render the next frame. Add your rendering code here.
        /// </summary>
        /// <param name="e">Contains timing information.</param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            //DrawSquare(0.8f, Color.Silver);
            DrawLine(0.6f, Color.Sienna);
            
            

            SwapBuffers();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // The 'using' idiom guarantees proper resource cleanup.
            // We request 30 UpdateFrame events per second, and unlimited
            // RenderFrame events (as fast as the computer can handle).
            using (Game game = new Game())
            {
                game.Run(30.0);
            }
        }
        private void DrawSquare(float c, Color color)
        {
            GL.Begin(BeginMode.Quads);
            GL.Color3(color);
            GL.Vertex2(-c, -c);
            GL.Vertex2(-c, c);
            GL.Vertex2(c, c);
            GL.Vertex2(c, -c);
            GL.End();
        }

        private void DrawLine(float c, Color color)
        {
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(color);
            GL.Vertex2(-c, -c);
            GL.Vertex2(-c, c);
            GL.Vertex2(c, c);
            
            //GL.Vertex3(c, -c, -c);
            //GL.DrawArrays(PrimitiveType.LineLoop, 1, 3);
            GL.End();
        }
    }
}