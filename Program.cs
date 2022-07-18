// C# program to print Hello World!
using System;
using System.Threading;
using System.Runtime.InteropServices;

// Class declaration
class Program
{
    // Closing Stuff
    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("Kernel32")]
    private static extern IntPtr GetConsoleWindow();

    const int SW_HIDE = 0;
    const int SW_SHOW = 5;

    // Main Method
    static void Main(string[] args)
    {
        // Closing Console
        IntPtr hwnd;
        hwnd = GetConsoleWindow();
        ShowWindow(hwnd, SW_HIDE);

        var discord = new Discord.Discord(998051529309311046, (UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();

        var activity = new Discord.Activity
        {
            State = "Testing Custom discord Rich presence",
            Details = "I dont know what to put here",
            Timestamps =
              {
                  Start = 5,
                  End = 10,
              },
            Assets =
              {
                  LargeImage = "foo largeImageKey", // Larger Image Asset Value
                  LargeText = "foo largeImageText", // Large Image Tooltip
                  SmallImage = "foo smallImageKey", // Small Image Asset Value
                  SmallText = "foo smallImageText", // Small Image Tooltip
              },
            Instance = true,
        };

        int i = 0;
        while (true)
        {
            if (i == 0)
            {
                activityManager.UpdateActivity(activity, (result) =>
                {
                    if (result == Discord.Result.Ok)
                    {
                        Console.WriteLine("Updated!");
                    }
                    else
                    {
                        Console.WriteLine("Update Failed");
                    }
                });
            }

            discord.RunCallbacks();
            Thread.Sleep(1000);

            i = (i + 1) % 15;
        }
    }
}
