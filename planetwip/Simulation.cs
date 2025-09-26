public class Simulation
{

    public float[] vertices = DrawCircle(100);

    public void Vertex_Rotation()
    {
        float cx = (vertices[0] + vertices[3] + vertices[6]) / 3f;
        float cy = (vertices[1] + vertices[4] + vertices[7]) / 3f;
        float[] centroid = {cx, cy, 0.0f};

        float dx0 = vertices[0] - cx;
        float dy0 = vertices[1] - cy;
        float dx1 = vertices[3] - cx;
        float dy1 = vertices[4] - cy;
        float dx2 = vertices[6] - cx;
        float dy2 = vertices[7] - cy;
        
       double angle0 = Math.Atan2(dy0, dx0);
       double angle1 = Math.Atan2(dy1, dx1);
       double angle2 = Math.Atan2(dy2, dx2);

       double r0 = Math.Sqrt(dx0 * dx0 + dy0 * dy0);
       double r1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);
       double r2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);

       double newAngle0 = angle0 + 0.001f;
       double newAngle1 = angle1 + 0.001f;
       double newAngle2 = angle2 + 0.001f;
       
       double newX0 = cx + r0 * Math.Cos(newAngle0);
       double newY0 = cy + r0 * Math.Sin(newAngle0);
       double newX1 = cx + r1 * Math.Cos(newAngle1);
       double newY1 = cy + r1 * Math.Sin(newAngle1);
       double newX2 = cx + r2 * Math.Cos(newAngle2);
       double newY2 = cy + r2 * Math.Sin(newAngle2);
       
       vertices[0] = (float)newX0;
       vertices[1] = (float)newY0;

       vertices[3] = (float)newX1;
       vertices[4] = (float)newY1;

       vertices[6] = (float)newX2;
       vertices[7] = (float)newY2;
    }

    public static float[] DrawCircle(int numv)
    {
        float r = 0.2f;
        float cx = 0f;
        float cy = 0f;
        
        float[] vertices = new float[numv * 3];

        for (int i = 0; i < numv; i++)
        {
            double angle = 2 * Math.PI * i / numv;
            vertices[i * 3] = cx + r * (float)Math.Cos(angle);
            vertices[i * 3 + 1] = cy + r * (float)Math.Sin(angle);
            vertices[i * 3 + 2] = 0f;
        }

        return vertices;
    }
}