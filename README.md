# EifelMono.QuickButDirty

## Bindings

### Xaml

#### WPF
```xml
    <StackPanel>
        <TextBox Text="{Binding Data.Name.Value}" />
        <TextBox Text="{Binding Data.TimeStamp.Value}" />
    </StackPanel>
```

#### Xamarin.Forms
```xml
    <StackLayout>
        <Label Text="{Binding Data.Name.Value}" />
        <Label Text="{Binding Data.TimeStamp.Value}" />
    </StackLayout>


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
        // WPF
	    DataContext = Data = new BindingData();
        // Xamarin.Forms
        BindingContext = = Data = new BindingData();
	}
```
:
   
## Extenstions

* T Pipe<T>(this T value, Action<T> action)
* T Pipe<T>(this T value, Func<T, T> function);


