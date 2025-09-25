using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class SimWindow : GameWindow
{
    public SimWindow(GameWindowSettings gameWindowSettings,
        NativeWindowSettings nativeWindowSettings)
        : base(gameWindowSettings, nativeWindowSettings){}

    private int vao;
    private int vbo;
    private int shaderProgram;
    private Simulation sim = new();

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        if (KeyboardState.IsKeyDown(Keys.Escape)) Close();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        GL.ClearColor(255f, 255f, 255f, 0.8f);
        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.UseProgram(shaderProgram);
        GL.BindVertexArray(vao);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            
        SwapBuffers();
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        vao = GL.GenVertexArray();
        GL.BindVertexArray(vao);
        
        vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, sim.vertices.Length * sizeof(float), sim.vertices, BufferUsage.StaticDraw);
        
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexArrayAttrib(vao, 0);

        shaderProgram = GL.CreateProgram();
        
        int vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, LoadShaderSource("shader.vert"));
        GL.CompileShader(vertexShader);
        
        int fragShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragShader, LoadShaderSource("shader.frag"));
        GL.CompileShader(fragShader);

        GL.AttachShader(shaderProgram, vertexShader);
        GL.AttachShader(shaderProgram, fragShader);

        GL.LinkProgram(shaderProgram);

        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragShader);
    }

    protected override void OnUnload()
    {
        GL.DeleteVertexArray(vao);
        GL.DeleteBuffer(vbo);
        GL.DeleteProgram(shaderProgram);
    }
    
    public static string LoadShaderSource(string filePath)
    {
        string shaderSource = "";

        try
        {
            using (StreamReader reader = new StreamReader("../../../Shaders/" + filePath))
            {
                shaderSource = reader.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to load shader source file: " + e.Message);
        }

        return shaderSource;
    }
}