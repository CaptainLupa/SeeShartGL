#version 440 core

layout(location = 0) in vec3 position;
layout(location = 1) in vec3 color;
layout(location = 2) in vec2 textureCoordinates;

uniform mat4 modelMatrix;
uniform mat4 perspectiveMatrix;
uniform mat4 viewMatrix;

out vec3 oColor;
out vec2 oTextureCoordinates;

void main(void) {
    oColor = color;
    oTextureCoordinates = textureCoordinates;
    gl_Position = modelMatrix * vec4(position, 1);
}