public class Simulation
{
    public float[] vertices =
    {
        -0.5f, -0.5f, 0.0f, //Bottom-left vertex
        0.5f, -0.5f, 0.0f, //Bottom-right vertex
        0.0f, 0.5f, 0.0f //Top vertex
    };

    public void Vertex_Rotation(float x, float y)
    {
        float cx = (vertices[0] + vertices[3] + vertices[6]) / 3f;
        float cy = (vertices[1] + vertices[4] + vertices[7]) / 3f;
        float[] centroid = {cx, cy, 0.0f};

        float dx = vertices[0] - cx;
        float dy = vertices[1] - cy;
        
       double angle = Math.Atan2(dy, dx);
    }
}