using ClarkOS.Common.Scene;
using OpenTK.Mathematics;
using static ClarkOS.Common.SSGLMath;

namespace ClarkOS.Common {

    public abstract class GameObject : SceneNode {
        private SceneBase _parentScene;

        public GameObject(SceneBase ps, Mesh mesh): base(mesh) {
            _parentScene = ps;
        }

        public override void update() {
            base.update();

            _shader.use();
            _shader.setMat4("modelMatrix", modelMat);
            _shader.suspend();
        }
    }

}