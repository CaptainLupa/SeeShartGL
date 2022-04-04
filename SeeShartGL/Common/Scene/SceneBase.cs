
namespace SeeShartGL.Common.Scene {

    public abstract class SceneBase {

        protected List<GameObject> objects;

        public void update() {
            foreach (var v in objects) {
                v.update();
            }
        }
        
        public void addObject(GameObject obj) {
            this.objects.Add(obj);
        }

    }

}