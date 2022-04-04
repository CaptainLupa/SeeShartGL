using OpenTK.Mathematics;
using SeeShartGL.Common.Meshes;
using SeeShartGL.Common.Scene;

namespace SeeShartGL.Common {

    public abstract class CameraBase: SceneNode {

        private float _fov;
        private Matrix4 _prespectiveMat;

        public CameraBase(float fov) : base(new NullMesh()) {
            _fov = fov;
        }

        public float fov() {
            return _fov;
        }

        public void changeFov(float f) {
            _fov = f;
        }

        public Matrix4 perspectiveMat() {
            return _prespectiveMat;
        }

        

    }

}