using OpenTK.Graphics.OpenGL4;
using SeeShartGL.Common;

namespace SeeShartGL.Primitives {

	public class Triangle: GameObject {
		public Triangle() : base(new [] {
			 0.0f,  0.5f, 0.0f,   1.0f, 1.0f, 0.0f,   0.5f, 1.0f,
			 0.5f, -0.5f, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f,
			-0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f
		}) { }

		public override void draw() {
			GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
		}

		public override void enable() {
			GL.BindVertexArray(_vao);
		}

		public override void disable() {
			GL.BindVertexArray(0);
		}
	}

}