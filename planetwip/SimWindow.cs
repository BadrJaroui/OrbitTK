using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class SimWindow : GameWindow
{
    public SimWindow(GameWindowSettings gameWindowSettings,
        NativeWindowSettings nativeWindowSettings)
        : base(gameWindowSettings, nativeWindowSettings){}

    private Simulation sim = new();

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);

        if (KeyboardState.IsKeyDown(Keys.Escape)) Close();
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        GL.ClearColor(0f, 0f, 0f, 1.0f);
        GL.Clear(ClearBufferMask.ColorBufferBit);
            
        SwapBuffers();
    }

    protected override void OnLoad()
    {
        base.OnLoad();
            
        sim.vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, sim.vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, sim.vertices.Length * sizeof(float), sim.vertices, BufferUsage.StaticDraw);
    }
}