using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ClarkOS.Common {
    /// <summary>
    /// Simple class to create vertex and fragment shaders.
    /// </summary>
    public class Shader {

        public readonly int Handle;

        private readonly Dictionary<string, int> _uniformLocations;

        public Shader(string vertexPath, string fragmentPath) {
            // Vertex Shader
            var shaderSource = File.ReadAllText(vertexPath);
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, shaderSource);
            CompileShader(vertexShader);

            // Fragment Shader
            shaderSource = File.ReadAllText(fragmentPath);
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, shaderSource);
            CompileShader(fragmentShader);

            Handle = GL.CreateProgram();
            
            GL.AttachShader(Handle, vertexShader);
            GL.AttachShader(Handle, fragmentShader);

            LinkProgram(Handle);

            GL.DetachShader(Handle, vertexShader);
            GL.DetachShader(Handle, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
            
            // Uniform stuff
            
            GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);

            _uniformLocations = new Dictionary<string, int>();

            for (var i = 0; i < numberOfUniforms; i++) {
                var key      = GL.GetActiveUniform(Handle, i, out _, out _);
                var location = GL.GetUniformLocation(Handle, key);
                
                _uniformLocations.Add(key, location);
            }
        }
        
        public void Use() {
            GL.UseProgram(Handle);
        }

        public int GetAttribLocation(string attribName) {
            return GL.GetAttribLocation(Handle, attribName);
        }
        
        /****************************************Uniform Setters*****************************************/

        public void SetInt(string name, int data) {
            Use();
            GL.Uniform1(_uniformLocations[name], data);
        }

        public void SetFloat(string name, float data) {
            Use();
            GL.Uniform1(_uniformLocations[name], data);
        }

        public void SetMat4(string name, Matrix4 data) {
            Use();
            GL.UniformMatrix4(_uniformLocations[name], true, ref data);
        }

        public void SetVec3(string name, Vector3 data) {
            Use();
            GL.Uniform3(_uniformLocations[name], data);
        }

        /***************************************Static Functions*****************************************/
        
        /// <summary>
        /// Compiles shader and checks for errors.
        /// </summary>
        /// <param name="shader">Shader to compile</param>
        /// <exception cref="Exception">Shows infoLog from GL.GetShaderInfoLog(int)</exception>
        private static void CompileShader(int shader) {
            GL.CompileShader(shader);
            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);

            if (code == (int) All.True) return;

            var infoLog = GL.GetShaderInfoLog(shader);

            throw new Exception($"Error occured while compiling shader {shader}.\n\n{infoLog}");
        }

        /// <summary>
        /// Links program and checks for errors.
        /// </summary>
        /// <param name="program">Program to link</param>
        /// <exception cref="Exception">Shows InfoLog from GL.GetProgramInfoLog(int)</exception>
        private static void LinkProgram(int program) {
            GL.LinkProgram(program);
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var code);

            if (code == (int) All.True) return;

            var infoLog = GL.GetProgramInfoLog(program);

            throw new Exception($"Error occured while linking program {program}.\n\n{infoLog}");
        }
    }

}