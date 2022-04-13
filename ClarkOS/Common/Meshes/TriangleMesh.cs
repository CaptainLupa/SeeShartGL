namespace ClarkOS.Common.Meshes {

	public class TriangleMesh: Mesh {
		public TriangleMesh() : base(new [] {
			0.0f,  0.5f, 0.0f,   1.0f, 1.0f, 0.0f,   0.5f, 1.0f,
			0.5f, -0.5f, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f,
			-0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f
		}) { }
	}

}