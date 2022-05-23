using ClarkOS.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ClarkOS {
    
    public class Window: GameWindow {

        private readonly float[] _verticies = {
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f
        };

        private int _vertexBufferObj;
        private int _vertexArrayObj;

        private Shader _shader;

        public Window(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws) { }

        protected override void OnLoad() {
            base.OnLoad();
            
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            _vertexBufferObj = GL.GenBuffer();
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObj);
            
            
        }

        protected override void OnUpdateFrame(FrameEventArgs e) {
            if (KeyboardState.IsKeyDown(Keys.Escape)) {
                Close();
            }
            
            base.OnUpdateFrame(e);
        }

    }

}