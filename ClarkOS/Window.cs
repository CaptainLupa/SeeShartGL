using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ClarkOS {
    
    public class Window: GameWindow {

        public Window(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws) { }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            if (KeyboardState.IsKeyDown(Keys.Escape)) {
                Close();
            }
            
            base.OnUpdateFrame(e);
        }

    }

}