﻿using OpenTK.Graphics.OpenGL4;
using SeeShartGL.Common;
using SeeShartGL.Common.Meshes;

namespace SeeShartGL.Primitives {

	public class Square: GameObject {
		
		public Square() : base(new SquareMesh()) { }
		
		public override void draw() {
			GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
		}

		public override void enable() {
			GL.BindVertexArray(_vao);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, _ebo);
		}

		public override void disable() {
			GL.BindVertexArray(0);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
		}

		public override void update() {
			base.update();
		}
	}

}