using System;
using System.Drawing;
using System.Globalization;
using Freezer.Engines;
using Gecko;

namespace Freezer.Core
{
    /// <summary>
    /// Represents a CaptureZone defined by a jQuery selector
    /// </summary>
    [Serializable]
    public sealed class JQuerySelectedZone : CaptureZone
    {
        /// <summary>
        /// Should only be used for serialization
        /// </summary>
        private JQuerySelectedZone()
        {
            
        }

        /// <summary>
        /// Creates a JQuerySelectedZone with specified selector
        /// </summary>
        /// <param name="selector">string representing the jQuery selector. Eg : body, #chartcontainer</param>
        public JQuerySelectedZone(string selector)
        {
            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            Selector = selector;
        }

        /// <summary>
        /// Gets a string representing the jQuerySelector for this instance
        /// </summary>
        public string Selector { get; internal set; }

        internal override Rectangle GetZone(IActiveDocument activeDocument)
        {
            try
            {
                int x =
                    (int)
                        Math.Round(Convert.ToDouble(activeDocument.RunJs($"$('{Selector}').offset().left;"),
                            CultureInfo.InvariantCulture));
                
                int y =
                    (int)
                        Math.Round(Convert.ToDouble(activeDocument.RunJs($"$('{Selector}').offset().top;"),
                            CultureInfo.InvariantCulture));

                int width =
                    (int)
                        Math.Round(Convert.ToDouble(activeDocument.RunJs($"$('{Selector}').innerWidth();"),
                            CultureInfo.InvariantCulture));
                
                int height =
                    (int)
                        Math.Round(Convert.ToDouble(activeDocument.RunJs($"$('{Selector}').innerHeight();"),
                            CultureInfo.InvariantCulture));

                return new Rectangle(x, y, width, height);
            }
            catch (FormatException ex)
            {
                throw new CaptureEngineException("Bad jQuery Selector.", ex, CaptureEngineState.InvalidCaptureZone);
            }
            catch (GeckoJavaScriptException ex)
            {
                throw new CaptureEngineException(
                    "Bad jQuery Selector. Error while running javascript selector. (Maybe the captured page doesn't have jQuery 1.2.6 +)",
                    ex, CaptureEngineState.InvalidCaptureZone);
            }
            catch (Exception ex)
            {
                throw; 
            }
        }
    }
}