
namespace SeeShartGL.Common.Scene {

    public abstract class SceneBase {

        protected List<SceneNode> objects;

        public SceneBase() {
            objects = new List<SceneNode>();
        }

        public void update() {
            foreach (var v in objects) {
                v.update();
            }
        }
        
        public void addObject(GameObject obj) {
            this.objects.Add(obj);
        }

        public SceneNode getObject(int index) {
            return objects.ElementAt(index);
        }

    }

}