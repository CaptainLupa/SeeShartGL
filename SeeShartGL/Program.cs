﻿using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace SeeShartGL {

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