using System.Drawing;
using ClarkOS.Common.Scene;
using ClarkOS.Primitives;
using OpenTK.Graphics.ES11;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ClearBufferMask = OpenTK.Graphics.OpenGL4.ClearBufferMask;
using GL = OpenTK.Graphics.OpenGL4.GL;

namespace ClarkOS {

	public class Game : GameWindow {
		private readonly Square tri;
		private readonly DefaultScene scene;
		private static float _aspectRatio;

		public Game(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws) {
			scene = new DefaultScene();
			tri = new Square(scene);
			scene.addObject(tri);
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
			
			tri.rotateZ(20);

			tri.update();

			tri.enable();
			tri.useShader();
			tri.draw();

			SwapBuffers();
		}

		protected override void OnResize(ResizeEventArgs e) {
			GL.Viewport(0, 0, e.Width, e.Height);
			base.OnResize(e);
			_aspectRatio = e.Width / e.Height;
		}

		public static float getAspectRatio() {
			return _aspectRatio;
		}

		protected override void OnUnload() {
			base.OnUnload();
		}
	}

}