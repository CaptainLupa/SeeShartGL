using OpenTK.Mathematics;

namespace SeeShartGL.Common {

	public abstract class GameObject : Drawable {
		protected Vector3 position;
		protected Vector3 scale;
		protected Quaternion rotation;
		protected Matrix4 transMat;
		protected Matrix4 rotMat;
		protected Matrix4 scaleMat;
		protected Matrix4 modelMat;

		public GameObject(Mesh mesh) : base(mesh) {
			position = Vector3.Zero;
			scale = Vector3.One;
			rotation = Quaternion.Identity;
			modelMat = Matrix4.Identity;
			transMat = Matrix4.Identity;
			rotMat = Matrix4.Identity;
			scaleMat = Matrix4.Identity;
		}

		public virtual void update() {
			transMat = Matrix4.CreateTranslation(position);
			rotMat = Matrix4.CreateFromQuaternion(rotation);
			scaleMat = Matrix4.CreateScale(scale);
			modelMat = transMat * rotMat * scaleMat;

			_shader.use();
			_shader.setMat4("modelMatrix", modelMat);
			_shader.suspend();
		}

		/*****************************************************************************************************/
		/*************************** Position, Rotation, Scale Manipulation **********************************/
		/*****************************************************************************************************/

		public void move(Vector3 dPos) => position += dPos;
		public void move(float dX, float dY, float dZ) => position += new Vector3(dX, dY, dZ);
		public void moveX(float dX) => position.X += dX;
		public void moveY(float dY) => position.Y += dY;
		public void moveZ(float dZ) => position.Z += dZ;
		public void setPos(Vector3 newPos) => position = newPos;
		
		public void rotate(Quaternion dQ) => rotation = dQ * rotation;
		public void rotate(float dX, float dY, float dZ) => rotation = new Quaternion(SSGLMath.toRadians(dX), SSGLMath.toRadians(dY), SSGLMath.toRadians(dZ)) * rotation;

		public void rotateZ(float dZ) {
			rotation = new Quaternion(0, 0, 1, SSGLMath.toRadians(dZ)) * rotation;
		}

		public void rotateY(float dZ) => rotation = new Quaternion(0, 1, 0, SSGLMath.toRadians(dZ)) * rotation;
		public void rotateX(float dZ) => rotation = new Quaternion(1, 0, 0, SSGLMath.toRadians(dZ)) * rotation;
	}

}