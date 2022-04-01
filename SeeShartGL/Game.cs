using System.Drawing;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

using OpenTK.Graphics.OpenGL4;
using SeeShartGL.Primitives;

namespace SeeShartGL {

	public class Game : GameWindow {
		private Square tri;

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
		}

		protected override void OnRenderFrame(FrameEventArgs args) {
			base.OnRenderFrame(args);
			
			GL.Clear(ClearBufferMask.ColorBufferBit);

			tri.useShader();
			tri.enable();
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