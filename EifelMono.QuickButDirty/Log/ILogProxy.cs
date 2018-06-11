using System;

namespace EifelMono.QuickButDirty.Log {
    public interface ILogProxy
    {
        void Log(LogExtension.Detail details);

        bool FileNameOnly { get; set; }
    }
}
 