namespace ClarkOS.Common {

	public class Mesh {
		// Includes position, color, and texture.
		private readonly float[] _vertices;
		private readonly uint[]? _indices;

		protected Mesh(float[] v) {
			_vertices = v;
		}

		protected Mesh(float[] v, uint[]? i) {
			_vertices = v;
			_indices = i;
		}

		public bool hasIndices() {
			return _indices != null;
		}

		public float[] vertices() {
			return _vertices;
		}

		public uint[]? indices() {
			return  _indices;
		}
	}

}