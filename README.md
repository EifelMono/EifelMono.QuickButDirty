# EifelMono.QuickButDirty

## Bindings

### Xaml
:
```xml
    <StackPanel>
        <TextBox Text="{Binding Data.Name.Value}" />
        <TextBox Text="{Binding Data.TimeStamp.Value}" />
    </StackPanel>
```
:

### Code
:
```csharp

    public class BindingData : BindingObject {

    public BindingProperty<String> Name { get; set; } = new BindingProperty<String>();
	public BindingProperty<DateTime> TimeStamp { get; set; } = new BindingProperty<DateTime>();

    BindingData Data { get; set; }

    public MainWindow()
	{
	    InitializeComponent();
	    DataContext = Data = new BindingData();
	}
```
:




