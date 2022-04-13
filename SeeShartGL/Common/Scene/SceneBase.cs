
namespace SeeShartGL.Common.Scene {

    public abstract class SceneBase {

        protected List<SceneNode> objects;
        protected List<CameraBase> cameras;
        protected CameraBase activeCamera;

        protected SceneBase() {
            cameras = new List<CameraBase>();
            objects = new List<SceneNode>();
        }

        public void update() {
            foreach (var v in objects) {
                v.update();
            }

            foreach (var c in cameras) {
                c.update();
            }
        }

        public void draw() {
            foreach (var v in objects) {
                v.draw();
            }
        }
        
        public void addObject(GameObject obj) {
            this.objects.Add(obj);
        }

        public SceneNode getObject(int index) {
            return objects.ElementAt(index);
        }

        public void addCamera(CameraBase camera) {
            cameras.Add(camera);
        }

        public CameraBase getCamera(int index) {
            return cameras.ElementAt(index);
        }

        public void setActiveCamera(int index) {
            activeCamera = getCamera(index);
        }

    }

}