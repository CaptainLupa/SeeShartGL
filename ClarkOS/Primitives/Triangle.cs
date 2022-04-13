using ClarkOS.Common;
using ClarkOS.Common.Meshes;
using ClarkOS.Common.Scene;
using OpenTK.Graphics.OpenGL4;

namespace ClarkOS.Primitives {

	public class Triangle: GameObject {
		public Triangle(SceneBase ps) : base(ps, new TriangleMesh()) { }

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