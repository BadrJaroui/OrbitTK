using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

class Program
{
    public static void Main()
    {
        var nativeWindowSettings = new NativeWindowSettings
        {
            Size = new Vector2i(800, 800),
            Title = "OpenTK test"
        };

        using (var window = new ExampleWindow(GameWindowSettings.Default, nativeWindowSettings))
        {
            window.Run();
        }
    }

    public class ExampleWindow : GameWindow
    {
        public ExampleWindow(GameWindowSettings gameWindowSettings,
            NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings){}

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

            Simulation sim = new();
            sim.vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, sim.vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, sim.vertices.Length * sizeof(float), sim.vertices, BufferUsage.StaticDraw);
        }
    }

    public class Simulation
    {
        public int vertexBufferObject;
        
        public float[] vertices =
        {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            0.5f, -0.5f, 0.0f, //Bottom-right vertex
            0.0f, 0.5f, 0.0f //Top vertex
        };
    }
}