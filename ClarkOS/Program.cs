using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using ClarkOS.Common;

namespace ClarkOS {

	public class Program{
		static void Main() {
			var nws = new NativeWindowSettings() {
				Size = new Vector2i(800, 600),
				Title = "Wow",

				Flags = ContextFlags.ForwardCompatible
			};

			using var window = new Game(GameWindowSettings.Default, nws);

			window.Run();
		}
	}

}