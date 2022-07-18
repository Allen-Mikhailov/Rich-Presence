// C# program to print Hello World!
using System;
using System.Threading;

// Class declaration
class Program
{

    // Main Method
    static void Main(string[] args)
    {

        var discord = new Discord.Discord(998051529309311046, (UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();

        var activity = new Discord.Activity
        {
            State = "In Play Mode",
            Details = "Playing the Trumpet!",
            Timestamps =
              {
                  Start = 5,
              },
            Assets =
              {
                  LargeImage = "foo largeImageKey", // Larger Image Asset Value
                  LargeText = "foo largeImageText", // Large Image Tooltip
                  SmallImage = "foo smallImageKey", // Small Image Asset Value
                  SmallText = "foo smallImageText", // Small Image Tooltip
              },
            Party =
              {
                  Id = "foo partyID",
                  Size = {
                      CurrentSize = 1,
                      MaxSize = 4,
                  },
              },
            Secrets =
              {
                  Match = "foo matchSecret",
                  Join = "foo joinSecret",
                  Spectate = "foo spectateSecret",
              },
            Instance = true,
        };

        while (true)
        {
            discord.RunCallbacks();
            Thread.Sleep(15000);
            Console.WriteLine("It worked :D");

            activityManager.UpdateActivity(activity, (result) =>
            {
                if (result == Discord.Result.Ok)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            });
        }
    }
}
