using OpenTK.Mathematics;
using SeeShartGL.Common.Scene;
using static SeeShartGL.Common.SSGLMath;

namespace SeeShartGL.Common {

    public abstract class GameObject : SceneNode {

        public GameObject(Mesh mesh): base(mesh) {
            
        }

        public override void update() {
            base.update();

            _shader.use();
            _shader.setMat4("modelMatrix", modelMat);
            _shader.suspend();
        }
    }

}