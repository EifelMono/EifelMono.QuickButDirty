# EifelMono.QuickButDirty

## Mvvm

```csharp
public class TVO : MvvmObject {
	public TVO(ScanCodeType type, string code)
	{
		Type.Value = type;
		Code.Value = code;
	}
        public MvvmProperty<ScanCodeType> Type { get; set; } = MvvmProperty.Create<ScanCodeType>();
	public MvvmProperty<string> Code { get; set; } = MvvmProperty.Create<string>();
}
```

```xml
<ListView Grid.Row="1" ItemsSource="{Binding Data.ScanCodes}" ItemSelected="ListView_ItemSelected">
        <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <StackLayout>
                            <Label StyleClass="key" Text="{Binding Type.Value}"  />
                            <Label StyleClass="value"  Text="{Binding Code.Value}" />
                        </StackLayout>
                    </ViewCell>
                </DataTemplate>
        </ListView.ItemTemplate>
</ListView>
```



