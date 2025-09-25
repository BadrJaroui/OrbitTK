layout (location = 0) in vec3 aPosition;

void Main()
{
    gl_position = vec4(aPosition, 1.0);
}