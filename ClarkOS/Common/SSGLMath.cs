using OpenTK.Mathematics;

namespace ClarkOS.Common {

	public static class SSGLMath {
		public static float toRadians(float v) {
			return v * ((float) System.Math.PI / 180);
		}

		public static Vector3 toRadians(Vector3 v) {
			return v * ((float) System.Math.PI / 180);
		}
	}

}