using OpenTK.Mathematics;
using static SeeShartGL.Common.SSGLMath;

namespace SeeShartGL.Common.Scene {

    public abstract class SceneNode: Drawable {

        protected Matrix4 modelMat;
        protected Matrix4 perspectiveMat;
        protected Matrix4 viewMat;
        protected Vector3 position;
        protected Quaternion rotation;
        protected Matrix4 rotMat;
        protected Vector3 scale;
        protected Matrix4 scaleMat;
        protected Matrix4 transMat;

        protected SceneNode(Mesh mesh): base(mesh) {
            position = Vector3.Zero;
            scale    = Vector3.One;
            rotation = Quaternion.Identity;
            modelMat = Matrix4.Identity;
            transMat = Matrix4.Identity;
            rotMat   = Matrix4.Identity;
            scaleMat = Matrix4.Identity;
        }

        public virtual void update() {
            transMat = Matrix4.CreateTranslation(position);
            rotMat   = Matrix4.CreateFromQuaternion(rotation);
            scaleMat = Matrix4.CreateScale(scale);
            modelMat = transMat * rotMat * scaleMat;
        }
        
        public void move(Vector3 dPos) {
            position += dPos;
        }

        public void move(float dX, float dY, float dZ) {
            position += new Vector3(dX, dY, dZ);
        }

        public void moveX(float dX) {
            position.X += dX;
        }

        public void moveY(float dY) {
            position.Y += dY;
        }

        public void moveZ(float dZ) {
            position.Z += dZ;
        }

        public void setPos(Vector3 newPos) {
            position = newPos;
        }

        public void rotate(Quaternion dQ) {
            rotation = dQ * rotation;
        }

        public void rotate(float dX, float dY, float dZ) {
            rotation = Quaternion.FromEulerAngles(toRadians(dX), toRadians(dY), toRadians(dZ)) *
                       rotation;
        }

        public void rotateZ(float dZ) {
            rotation = Quaternion.FromEulerAngles(0, 0, toRadians(dZ)) * rotation;
        }

        public void rotateY(float dZ) {
            rotation = Quaternion.FromEulerAngles(0, toRadians(dZ), 0) * rotation;
        }

        public void rotateX(float dZ) {
            rotation = Quaternion.FromEulerAngles(toRadians(dZ), 0, 0) * rotation;
        }

        public void setRotation(Quaternion q) {
            rotation = q;
        }

        public void setRotation(Vector3 euler) {
            rotation = Quaternion.FromEulerAngles(euler);
        }

        public void setRotation(float x, float y, float z) {
            rotation = Quaternion.FromEulerAngles(x, y, z);
        }

        public Vector3 getRotation() {
            return rotation.ToEulerAngles();
        }

    }

}