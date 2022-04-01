namespace SeeShartGL.Common {

	public class Mesh {
		// Includes position, color, and texture.
		private readonly float[] _vertices;

		public Mesh(float[] vertices) {
			_vertices = vertices;
		}

		public float[] getVertices() {
			return _vertices;
		}
	}

}