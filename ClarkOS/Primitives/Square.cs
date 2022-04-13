using ClarkOS.Common;
using ClarkOS.Common.Meshes;
using ClarkOS.Common.Scene;
using OpenTK.Graphics.OpenGL4;

namespace ClarkOS.Primitives {

	public class Square: GameObject {
		
		public Square(SceneBase ps) : base(ps, new SquareMesh()) { }
		
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