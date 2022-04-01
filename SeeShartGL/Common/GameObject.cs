using OpenTK.Mathematics;

namespace SeeShartGL.Common {

	public abstract class GameObject: Drawable {
		private Vector3 _position;
		private Vector3 _scale;
		private Quaternion _rotation;
		private Matrix4 _modelMat;

		public GameObject(float[] vertices): base(vertices) {
			_position = Vector3.Zero;
			_scale = Vector3.One;
			_rotation = Quaternion.Identity;
			_modelMat = Matrix4.Identity;
		}

		public GameObject(float[] vertices, uint[] indices) : base(vertices, indices) {
			_position = Vector3.Zero;
			_scale = Vector3.One;
			_rotation = Quaternion.Identity;
			_modelMat = Matrix4.Identity;
		}
		
		
	}

}