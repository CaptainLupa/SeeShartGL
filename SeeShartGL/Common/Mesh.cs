namespace SeeShartGL.Common {

	public class Mesh {
		// Includes position, color, and texture.
		public readonly float[] vertices;
		public readonly uint[] indices;
		public readonly bool hasIndices;

		public Mesh(float[] v) {
			vertices = v;
			hasIndices = false;
		}

		public Mesh(float[] v, uint[] i) {
			vertices = v;
			indices = i;
			hasIndices = true;
		}
	}

}