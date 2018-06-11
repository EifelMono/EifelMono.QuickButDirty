using System;

namespace EifelMono.QuickButDirty.Log {
    public class LogProxy : ILogProxy {
	public bool FileNameOnly { get; set; } = true;

	public virtual void Log(LogExtension.Detail details)
	{
	}
    }
}
 