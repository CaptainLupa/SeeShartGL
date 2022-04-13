using System.Reflection.Metadata;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ClarkOS.Common {

	public class Shader {
		// ReSharper disable once InconsistentNaming
		private readonly int ID;

		private readonly Dictionary<string, int> _uniformLocations;

		public Shader(string vertPath, string fragPath) {
			var shaderSource = File.ReadAllText(vertPath);
			var vertexShader = GL.CreateShader(ShaderType.VertexShader);
			GL.ShaderSource(vertexShader, shaderSource);
			compileShader(vertexShader);

			var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
			shaderSource = File.ReadAllText(fragPath);
			GL.ShaderSource(fragmentShader, shaderSource);
			compileShader(fragmentShader);

			ID = GL.CreateProgram();
			
			GL.AttachShader(ID, vertexShader);
			GL.AttachShader(ID, fragmentShader);

			linkProgram(ID);
			
			GL.DetachShader(ID, vertexShader);
			GL.DetachShader(ID, fragmentShader);
			GL.DeleteShader(fragmentShader);
			GL.DeleteShader(vertexShader);
			
			GL.GetProgram(ID, GetProgramParameterName.ActiveUniforms, out var numOfUniforms);

			_uniformLocations = new Dictionary<string, int>();

			for (var i = 0; i < numOfUniforms; i++) {
				var key = GL.GetActiveUniform(ID, i, out _, out _);

				var location = GL.GetUniformLocation(ID, key);
				
				_uniformLocations.Add(key, location);
			}

		}

		private static void compileShader(int shader) {
			GL.CompileShader(shader);

			GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);

			if (code != (int) All.True) {
				var infoLog = GL.GetShaderInfoLog(shader);

				throw new Exception($"Error occured while compiling Shader({shader}).\n\n{infoLog}");
			}
		}

		private static void linkProgram(int program) {
			GL.LinkProgram(program);
			
			GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var code);

			if (code != (int) All.True) {
				var infoLog = GL.GetProgramInfoLog(program);

				throw new Exception($"Error occured while linked Program({program}).\n\n{infoLog}");
			}
		}

		public void use() {
			GL.UseProgram(ID);
		}

		public void suspend() {
			GL.UseProgram(0);
		}

		public int getAttribLocation(string attribName) {
			return GL.GetAttribLocation(ID, attribName);
		}

		public void setInt(string uniformName, int value) {
			use();
			GL.Uniform1(_uniformLocations[uniformName], value);
		}
		
		public void setFloat(string uniformName, float value) {
			use();
			GL.Uniform1(_uniformLocations[uniformName], value);
		}

		public void setMat4(string uniformName, Matrix4 data) {
			use();
			GL.UniformMatrix4(_uniformLocations[uniformName], true, ref data);
		}

		public void setVector3(string uniformName, Vector3 data) {
			use();
			GL.Uniform3(_uniformLocations[uniformName], data);
		}
	}

}