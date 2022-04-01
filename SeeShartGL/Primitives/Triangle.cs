﻿using OpenTK.Graphics.OpenGL4;
using SeeShartGL.Common;
using SeeShartGL.Common.Meshes;

namespace SeeShartGL.Primitives {

	public class Triangle: GameObject {
		public Triangle() : base(new TriangleMesh()) { }

		public override void draw() {
			GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
		}

		public override void enable() {
			GL.BindVertexArray(_vao);
		}

		public override void disable() {
			GL.BindVertexArray(0);
		}

		public override void update() {
			base.update();
		}
	}

}