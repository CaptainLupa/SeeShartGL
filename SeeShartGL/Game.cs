using System.Drawing;
using OpenTK.Graphics.ES11;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SeeShartGL.Primitives;
using ClearBufferMask = OpenTK.Graphics.OpenGL4.ClearBufferMask;
using GL = OpenTK.Graphics.OpenGL4.GL;

namespace SeeShartGL {

	public class Game : GameWindow {
		private readonly Square tri;

		public Game(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws) {
			tri = new Square();	
		}

		protected override void OnUpdateFrame(FrameEventArgs args) {
			if (KeyboardState.IsKeyDown(Keys.Escape)) {
				Close();
			}
			
			base.OnUpdateFrame(args);
		}

		protected override void OnLoad() {
			base.OnLoad();

			GL.ClearColor(Color.Blue);
			
			tri.rotateZ(90);
		}

		protected override void OnRenderFrame(FrameEventArgs args) {
			base.OnRenderFrame(args);
			
			GL.Clear(ClearBufferMask.ColorBufferBit);

			tri.update();

			tri.enable();
			tri.useShader();
			tri.draw();

			SwapBuffers();
		}

		protected override void OnResize(ResizeEventArgs e) {
			GL.Viewport(0, 0, e.Width, e.Height);
			base.OnResize(e);
		}

		protected override void OnUnload() {
			base.OnUnload();
			
			
		}
	}

}