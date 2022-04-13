#version 410 core

in vec3 oColor;
in vec2 oTextureCoordinates;

out vec4 color;

void main(void) {
    color = vec4(oColor, 1.0);
}