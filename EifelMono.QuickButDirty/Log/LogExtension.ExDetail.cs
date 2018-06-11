using System;

namespace EifelMono.QuickButDirty.Log {
    public static partial class LogExtension
    {
        public class ExDetail : Detail
        {
            /// <summary>
            /// Exception of this Log Detail
            /// </summary>
            /// <value>The ex.</value>
            public Exception Ex { get; set; }
        }
    }
}
 