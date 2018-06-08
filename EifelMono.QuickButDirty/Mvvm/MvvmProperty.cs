using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace EifelMono.QuickButDirty.Mvvm
{
    public class MvvmProperty
    {
        public string PropertyName { get; set; }
        public IMvvmOnPropertyChanged MvvmParent { get; set; } = null;
        public void OnPropertyChanged(string propertyName = null) =>
            MvvmParent?.OnPropertyChanged(propertyName ?? PropertyName);
        public void RefreshAll() => OnPropertyChanged(string.Empty);
        public static MvvmProperty<T> Create<T>([CallerMemberName]string propertyName = "") where T : IComparable
        {
            return new MvvmProperty<T>() { PropertyName = propertyName };
        }
    }
    public class MvvmProperty<T> : MvvmProperty where T : IComparable
    {
        protected T _Value = default(T);
        public T LastValue = default(T);
        protected bool First = true;
        public T Value
        {
            get => _Value; set
            {
                try
                {
                    if (value.CompareTo(_Value) != 0 || First)
                    {
                        First = false;
			LastValue = _Value;
                        _Value = value;
                        OnPropertyChanged();
                        OnChanged?.Invoke(LastValue, value);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    _Value = value;
                    OnPropertyChanged();
                }
            }
        }
        public Action<T, T> OnChanged { get; set; }

        public MvvmProperty<T> DoOnChanged(Action<T, T> onChanged)
        {
            OnChanged = onChanged;
            return this;
        }
    }
}
