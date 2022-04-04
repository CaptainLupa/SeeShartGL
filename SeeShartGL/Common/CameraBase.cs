using SeeShartGL.Common.Scene;

namespace SeeShartGL.Common {

    public abstract class CameraBase: SceneNode {

        private float _fov;
        private bool 

        public CameraBase(float fov) : base() {
            _fov = fov;
        }

        public float fov() {
            return _fov;
        }

    }

}