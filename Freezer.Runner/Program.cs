using System;

namespace Freezer.Runner
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string boundingHostName = args[0];
            int boundingPort = int.Parse(args[1]);
            string xulPath = args[2];
            string parentIdentifier = args[3]; 

            RunnerCore.SetupHost(boundingHostName, boundingPort, xulPath, parentIdentifier);
        }
    }
}
