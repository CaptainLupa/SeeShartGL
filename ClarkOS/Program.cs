using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace ClarkOS {

	public static class Program{
		private static void Main() {
			var nws = new NativeWindowSettings() {
				Size  = new Vector2i(800, 600),
				Title = "Big Sweaty Nuts",
				Flags = ContextFlags.ForwardCompatible,
			};

			using var window = new Window(GameWindowSettings.Default, nws);

			window.Run();
		}
	}

}