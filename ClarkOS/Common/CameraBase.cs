using ClarkOS.Common.Meshes;
using ClarkOS.Common.Scene;
using OpenTK.Mathematics;

namespace ClarkOS.Common {

    public abstract class CameraBase: SceneNode {

        private float _fov;
        private Matrix4 _perspectiveMat;

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
            update();
            return _perspectiveMat;
        }

        public override void update() {
            base.update();

            _perspectiveMat = Matrix4.CreatePerspectiveFieldOfView(_fov, Game.getAspectRatio(), 0.1f, 1000);
        }
    }

}