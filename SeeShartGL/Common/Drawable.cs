using OpenTK.Graphics.OpenGL4;

namespace SeeShartGL.Common {

	public abstract class Drawable {
		protected readonly int _vbo, _vao, _ebo;
		protected readonly Shader _shader;
		private readonly Mesh _mesh;
		public abstract void draw();

		public void useShader() {
			_shader.use();
		}

		public void suspendShader() {
			_shader.suspend();
		}
		public abstract void enable();
		public abstract void disable();

		protected Drawable(Mesh mesh) {
			_shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
			_mesh = mesh;
			
			_vao = GL.GenVertexArray();
			GL.BindVertexArray(_vao);
			
			_vbo = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
			GL.BufferData(BufferTarget.ArrayBuffer, _mesh.vertices().Length * sizeof(float), _mesh.vertices(), BufferUsageHint.StaticDraw);

			// Position
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 0);
			GL.EnableVertexAttribArray(0);
			
			// Color
			GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 8 * sizeof(float), 3 * sizeof(float));
			GL.EnableVertexAttribArray(1);

			// Texture Coords
			GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, 8 * sizeof(float), 6 * sizeof(float));
			GL.EnableVertexAttribArray(2);

			if (!_mesh.hasIndices()) return;

			_ebo = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
			
			GL.BufferData(BufferTarget.ElementArrayBuffer, _mesh.indices().Length * sizeof(uint), _mesh.indices(), BufferUsageHint.StaticDraw);
		}
		
	}

}