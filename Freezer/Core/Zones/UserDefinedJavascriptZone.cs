using System;
using System.Drawing;
using Freezer.Engines;
using Gecko;

namespace Freezer.Core
{
    /// <summary>
    /// Represents a CaptureZone defined by javascript implementation returning coordinates of the capture zone.
    /// The callback should return object with properties : x, y, width, height
    /// </summary>
    [Serializable]
    public sealed class UserDefinedJavascriptZone : CaptureZone
    {
        private UserDefinedJavascriptZone()
        {
            
        }

        /// <summary>
        /// Creates an instance of UserDefinedJavascriptZone
        /// </summary>
        /// <param name="callBackName">Name of javascript callback function</param>
        /// <param name="callBackImplementation">Implementation of the callback</param>
        public UserDefinedJavascriptZone(string callBackName, string callBackImplementation)
        {
            if (callBackName == null)
                throw new ArgumentNullException(nameof(callBackName));

            if (callBackImplementation == null)
                throw new ArgumentNullException(nameof(callBackImplementation));

            CallBackName = callBackName;
            CallBackImplementation = callBackImplementation;
        }

        /// <summary>
        /// Gets name of the javascript callback function. This function MUST return an object with properties: x, y, width, height
        /// </summary>
        public string CallBackName { get; internal set; }

        /// <summary>
        /// Gets the implementation of the function
        /// </summary>
        public string CallBackImplementation { get; internal set; }
        

        internal override Rectangle GetZone(IActiveDocument activeDocument)
        {
            string rawResult= string.Empty;

            try
            {
                activeDocument.RunJs(CallBackImplementation);

                string callableCallBackName = CallBackName.Trim();

                if (!callableCallBackName.EndsWith("()"))
                    callableCallBackName = $"{callableCallBackName}()";

                rawResult = activeDocument.RunJs(
                    $"var callresult_____ = {callableCallBackName};" +
                    $"callresult_____.x + ';' + callresult_____.y + ';' + " +
                    $"callresult_____.width + ';' + callresult_____.height");

                if (rawResult == null)
                    throw new CaptureEngineException($"Error while calling {callableCallBackName}",
                        CaptureEngineState.InvalidCaptureZone);

                string [] arrayResult = rawResult.Split(';');

                int x = int.Parse(arrayResult[0]);
                int y = int.Parse(arrayResult[1]);
                int width = int.Parse(arrayResult[2]);
                int height = int.Parse(arrayResult[3]);

                return new Rectangle(x, y, width, height);
            }
            catch (FormatException fex)
            {
                throw new CaptureEngineException($"Result returned by {CallBackName} does not contains " +
                                                 $"at least one of these following properties: x, y, width, height. Or, " +
                                                 $"one of these properties does not have integer value. {rawResult}", 
                                                 fex, CaptureEngineState.InvalidCaptureZone);
            }
            catch (GeckoJavaScriptException ex)
            {
                throw new CaptureEngineException($"Error while running {nameof(UserDefinedJavascriptZone)}"
                    , ex, CaptureEngineState.InvalidCaptureZone);
            }

            catch (GeckoException)
            {
                // Can't forward GeckoException because it's not serializable 

                throw new CaptureEngineException($"Error while running {nameof(UserDefinedJavascriptZone)}"
                    , null, CaptureEngineState.InvalidCaptureZone);
            }
            catch (CaptureEngineException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new CaptureEngineException("Internal error"
                    , ex, CaptureEngineState.InternalError);
            }
        }
    }
}
