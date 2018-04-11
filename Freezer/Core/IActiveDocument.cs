using System.Drawing;

namespace Freezer.Core
{
    internal interface IActiveDocument
    {
        /// <summary>
        /// Get current browser size
        /// </summary>
        Size BrowserSize { get; }

        /// <summary>
        /// Get the document size
        /// </summary>
        Rectangle DocumentSize { get; }

        /// <summary>
        /// Evaluate a javascript against the running page
        /// </summary>
        /// <param name="jsCode"></param>
        /// <returns></returns>
        string RunJs(string jsCode);
    }
}