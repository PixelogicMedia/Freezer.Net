using System;
using System.Drawing;
using System.IO;
using Freezer.Core;

namespace Freezer.SamplesConsole
{
    class Program
    {
        static void Main()
        {
            var screenShotJob = ScreenshotJobBuilder.Create("google.fr")
                .SetBrowserSize(new Size(640, 1136))
                .SetTrigger(new WindowLoadTrigger())
                .SetTimeout(TimeSpan.FromSeconds(30D));

            File.WriteAllBytes("this_is_not_even_my_final_screenshot.png", screenShotJob.Freeze()); 
        }
    }
}
