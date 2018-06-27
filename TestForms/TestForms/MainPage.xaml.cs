using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EifelMono.QuickButDirty.Binding;
using EifelMono.QuickButDirty.Extension;
using System.Windows.Input;
using System.Diagnostics;

namespace TestForms {
    public partial class MainPage : ContentPage {

	public class AddressItem : BindingClass {
	    public AddressItem() { }
	    public AddressItem(string name, string lastName) : this()
	    {
		Name.Value = name;
		LastName.Value = lastName;
		TimeStamp.Value = DateTime.Now;
	    }
	    public BindingProperty<string> Name { get; set; } = new BindingProperty<string>();
	    public BindingProperty<string> LastName { get; set; } = new BindingProperty<string>();

	    public BindingProperty<DateTime> TimeStamp { get; set; } = new BindingProperty<DateTime>();

	    internal AddressItem Pipe(Func<object, object> p)
	    {
		throw new NotImplementedException();
	    }
	}
	public class BindingData : BindingClass {
	    public BindingProperty<DateTime> TimeStamp { get; set; }
		= new BindingProperty<DateTime>()
		.Default(DateTime.MinValue);

	    public AddressItem Address { get; set; } =
		new AddressItem()
		.Pipe((item) => {
		    item.Name.Value = "Andreas";
		    item.Name.OnChanged = (o, n) => Debug.WriteLine($"old={o} new={n}");
		    item.LastName.Value = "Klapperich";
		});

	    private BindingCollection<AddressItem> _Addresses = null;
	    public BindingCollection<AddressItem> Addresses {
		get {
		    if (_Addresses == null) {
			_Addresses = new BindingCollection<AddressItem>
			{
			    new AddressItem("Karl", "Wurst"),
			    new AddressItem("Hans", "Dampf"),
			    new AddressItem("Axel", "Schweis"),
			    new AddressItem("Rainer", "Zufall")
			};
		    }
		    return _Addresses;
		}
	    }

	    public BindingProperty<double> Progress { get; set; } = new BindingProperty<double>();

	    ICommand _CommandChangeEntries = null;
	    public ICommand CommandChangeEntries {
		get {
		    return _CommandChangeEntries ?? (_CommandChangeEntries = new Xamarin.Forms.Command(() => {
			Address.Name.Value = $"{DateTime.Now} Name";
			Address.LastName.Value = $"{DateTime.Now} LastName";
		    }));
		}
	    }

	    ICommand _CommandAddList;
	    public ICommand CommandAddList {
		get {
		    return _CommandAddList ?? (_CommandAddList = new Xamarin.Forms.Command(() => {
			Addresses.Add(new AddressItem($"{Addresses.Count} Name", $"{Addresses.Count} LastName"));
		    }));
		}
	    }

	    public ICommand _CommandSetListTimestamp;
	    public ICommand CommandSetListTimestamp {
		get {
		    return _CommandSetListTimestamp ?? (_CommandSetListTimestamp = new Xamarin.Forms.Command(() => {
			foreach (var a in Addresses)
			    a.TimeStamp.Value = DateTime.Now;
		    }));
		}
	    }


	}

	BindingData Data { get; set; }

	public void RunLoop()
	{
	    Task.Run(async () => {
		for (int i = 100; i >= 0; i = i - 10) {
		    Data.Progress.Value = ((double)i)/100;
		    await Task.Delay(TimeSpan.FromSeconds(1));
		}

		while (true) {
		    Data.TimeStamp.Value = DateTime.Now;
		    await Task.Delay(TimeSpan.FromSeconds(1));
		}
	    });
	}
	public MainPage()
	{
	    InitializeComponent();
	    BindingContext = Data = new BindingData();
	    RunLoop();
	}
    }
}
