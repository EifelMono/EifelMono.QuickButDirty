using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace EifelMono.QuickButDirty.Mvvm
{
    public class MvvmObject : INotifyPropertyChanged, IMvvmOnPropertyChanged
    {
        public MvvmObject()
        {
            foreach (var mvvmProperty in MvvmProperties)
            {
                mvvmProperty.MvvmParent = this;
            }
        }

        #region MvvmProperties
        protected List<MvvmProperty> _MvvmProperties = null;
        public List<MvvmProperty> MvvmProperties
        {
            get
            {
                if (_MvvmProperties == null)
                {
                    _MvvmProperties = new List<MvvmProperty>();
                    var properties = this.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(x => x.PropertyType.IsSubclassOf(typeof(MvvmProperty)));
                    foreach (var p in properties)
                    {
                        var identifier = (MvvmProperty)(p.GetValue(this, null));
                        if (identifier != null)
                            if (!_MvvmProperties.Contains(identifier))
                                _MvvmProperties.Add(identifier);
                    }
                }
                return _MvvmProperties;
            }
        }
        #endregion

        #region Bindings
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            (PropertyChanged)?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public void RefreshAll() => OnPropertyChanged(string.Empty);
        #endregion
    }

}
