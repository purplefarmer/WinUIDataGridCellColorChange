using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridTestSample;

public class Item
{
	public string Name { get; set; }
	public int Age { get; set; }
	public string Address { get; set; }
}

public partial class MainWindowViewModel : ObservableObject
{
	[ObservableProperty]
	private ObservableCollection<Item> people = new()
	{
		{ new Item() { Name="John", Age=37, Address="US" } },
		{ new Item() { Name="Minsu", Age=22, Address="Korea" } },
		{ new Item() { Name="Foo", Age=15, Address="UK" } },
		{ new Item() { Name="Bar", Age=24, Address="China" } },
	};
}
