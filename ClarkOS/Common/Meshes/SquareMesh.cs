namespace ClarkOS.Common.Meshes {

	public class SquareMesh: Mesh {
		public SquareMesh() : base(new [] {
			 0.5f,  0.5f, 0.0f,   1.0f, 0.0f, 0.0f,   1.0f, 1.0f,
			 0.5f, -0.5f, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f,
			-0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f,
			-0.5f,  0.5f, 0.0f,   1.0f, 1.0f, 0.0f,   0.0f, 1.0f
		}, new uint[] {
			0, 1, 3, 1, 2, 3
		}) { }
	}

}