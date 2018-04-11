using System;
using System.Collections.Generic;
using System.Reflection;
using Freezer.Core;

namespace Freezer.Pools
{
    internal static class RemoteWorkerHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            List<Type> knownTypes = new List<Type>();
            
            knownTypes.Add(typeof(CroppedZone));
            knownTypes.Add(typeof(VisibleScreen));
            knownTypes.Add(typeof(JQuerySelectedZone));
            knownTypes.Add(typeof(CaptureZone));
            
            knownTypes.Add(typeof(DomReadyTrigger));
            knownTypes.Add(typeof(WindowLoadTrigger));
            knownTypes.Add(typeof(Trigger));
            knownTypes.Add(typeof(FreezerJsEventTrigger));

            return knownTypes;
        }
    }
}