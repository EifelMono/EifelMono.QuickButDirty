using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace EifelMono.QuickButDirty.Mvvm {
    public interface IMvvmOnPropertyChanged {
	void OnPropertyChanged(string propertyName);
    }
   
}
