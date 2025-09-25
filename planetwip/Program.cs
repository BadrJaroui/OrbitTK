using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
class Program
{
    public static void Main()
    {
        var nativeWindowSettings = new NativeWindowSettings
        {
            Size = new Vector2i(800, 800),
            Title = "OpenTK test"
        };

        using (var window = new SimWindow(GameWindowSettings.Default, nativeWindowSettings))
        {
            window.Run();
        }
    }
}