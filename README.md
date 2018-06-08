# EifelMono.QuickButDirty

## Mvvm

    ```csharp
public class TVO : MvvmObject {
	public TVO(ScanCodeType type, string code)
	{
		Type.Value = type;
		Code.Value = code;
	}
    public MvvmProperty<ScanCodeType> Type { get; set; } = new MvvmProperty<ScanCodeType>();
	public MvvmProperty<string> Code { get; set; } = new MvvmProperty<string>();
}
    ```




