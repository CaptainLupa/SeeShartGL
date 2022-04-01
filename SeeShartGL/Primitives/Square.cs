using OpenTK.Graphics.OpenGL4;
using SeeShartGL.Common;

namespace SeeShartGL.Primitives {

	public class Square: GameObject {
		
		public Square() : base(new [] {
			0.5f,  0.5f, 0.0f,   1.0f, 0.0f, 0.0f,   1.0f, 1.0f,
			0.5f, -0.5f, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f,
			-0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f,
			-0.5f,  0.5f, 0.0f,   1.0f, 1.0f, 0.0f,   0.0f, 1.0f
		}, new uint[] {
			0, 1, 3, 1, 2, 3
		}) { }
		
		public override void draw() {
			GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
		}

		public override void enable() {
			GL.BindVertexArray(_vao);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
		}

		public override void disable() {
			GL.BindVertexArray(0);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
		}
	}

}