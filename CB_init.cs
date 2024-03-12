using System.Runtime.InteropServices;
using CandyBoxCS.src;

internal class CB_init
{
    /* 
     * Couple of basic formatting: https://learn.microsoft.com/en-us/dotnet/api/system.console.writeline?view=net-8.0
     * https://spectreconsole.net/
     * https://stackoverflow.com/questions/69016697/create-a-standalone-exe-file-in-visual-studio-2019
    */
    public static void CB_initiate()
    {
        SetWindowSizeOfTheTerminal();

        Console.Clear();
        /*
        Console.WriteLine("Hello World!");
        Console.WriteLine("\x1b[48;2;0;128;255mHello, World!\x1b[0m");
        Console.WriteLine("\x1b[38;2;255;128;0mHello, World!\x1b[0m");
        Console.WriteLine("\x1b[4mHello, World!\x1b[0m");
        Console.WriteLine("\x1b[4m\x1b[38;2;255;128;0m\x1b[48;2;0;128;255mHello, World!");
        Console.WriteLine("Hello, World!\x1b[0m");
        Console.WriteLine("Hello, World!");
        Console.WriteLine("\x1b[4m\x1b[38;2;255;128;0m\x1b[48;2;0;128;255mHello, World!\x1b[0m");
        Console.WriteLine("Test: ");
        */
        Console.WriteLine();
        Console.WriteLine("Hi, this game was originally made by aniwey at https://github.com/candybox2/candybox2.github.io");
        Console.WriteLine("The original was licensed under GPL3 license, so I though as a project I would give it a spin and do it in C# ");
        Console.WriteLine("While I probably will use some of the original ascii art, that is published under CC-BY-SA license");
        Console.WriteLine("The original Aacii art was created by Tobias Nordqvist, GodsTurf, dixsept, Dani \"Deinol\" Gómez and aniwey.");
        Console.WriteLine("Fully originally can be played at: https://candybox2.github.io/");
        Console.WriteLine();
        Console.WriteLine("If you wanna play this version of the game, just press ENTER");

        /*
        Console.WriteLine("test1");
        Console.WriteLine("test11"+Console.ReadKey().KeyChar.ToString());
        Console.WriteLine("test12"+Console.ReadKey().KeyChar.GetType());
        Console.WriteLine("test13"+Console.ReadKey().Key.ToString());
        Console.WriteLine("test14"+Console.ReadKey().Key.GetType());

        Console.ReadKey().KeyChar.ToString() == "q"
        Console.ReadKey().Key.ToString() == "Enter"
        */

        /*
        if((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
        if((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
        if((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
        Console.WriteLine(cki.Key.ToString());
        while (cki.Key != ConsoleKey.Escape);
        */

        if (Console.ReadKey(true).Key != ConsoleKey.Enter)
        {
            Console.Clear();
            Console.WriteLine("I'm sad :(\nSee you later!");
        }
        else
        {
            /* TODO - Enable this
            Console.Clear();
            Console.WriteLine("Do you wanna enable Debug mode? [y/s]");
            if (Console.ReadKey(true).Key == ConsoleKey.Y) IVariables.debugMode = true;;
            */
            IVariables.debugMode = true;
            Controller.MainGame(true);
        }
    }

    // https://learn.microsoft.com/en-us/answers/questions/1275773/how-to-resize-a-console-app-in-c-windows-terminal
    // Structure used by GetWindowRect
    struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    private static void SetWindowSizeOfTheTerminal()
    {
        // Import the necessary functions from user32.dll
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);
        // Get the handle of the console window
        IntPtr consoleWindowHandle = GetForegroundWindow();
        // Maximize the console window
        ShowWindow(consoleWindowHandle, 3); // int SW_MAXIMIZE = 3;
                                            // Get the screen size
        GetWindowRect(consoleWindowHandle, out Rect screenRect);
        // Resize and reposition the console window to fill the screen
        int width = screenRect.Right - screenRect.Left;
        int height = screenRect.Bottom - screenRect.Top;
        MoveWindow(consoleWindowHandle, screenRect.Left, screenRect.Top, width, height, true);
    }
}