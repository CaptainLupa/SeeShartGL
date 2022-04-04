using OpenTK.Mathematics;
using static SeeShartGL.Common.SSGLMath;

namespace SeeShartGL.Common {

    public abstract class GameObject : Drawable {

        protected Matrix4 modelMat;
        protected Vector3 position;
        protected Quaternion rotation;
        protected Matrix4 rotMat;
        protected Vector3 scale;
        protected Matrix4 scaleMat;
        protected Matrix4 transMat;

        public GameObject(Mesh mesh) : base(mesh) {
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

            _shader.use();
            _shader.setMat4("modelMatrix", modelMat);
            _shader.suspend();
        }

        /*****************************************************************************************************/
        /*************************** Position, Rotation, Scale Manipulation **********************************/
        /*****************************************************************************************************/

        

    }

}