using System.Runtime.InteropServices;

namespace BerestaTest;

class Program
{
    [DllImport("libBerestaCore.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "run_script")]
    public static extern IntPtr RunScript(string code);
    
    private static void Main()
    {
        string script = "console_print(\"Hello from C# via BerestaCore!\");";
        
        IntPtr resultPtr = RunScript(script);
        
        string result = Marshal.PtrToStringAnsi(resultPtr) ?? "<null>";
        
        Console.WriteLine("DLL returned: ");
        Console.WriteLine(result);
    }
}