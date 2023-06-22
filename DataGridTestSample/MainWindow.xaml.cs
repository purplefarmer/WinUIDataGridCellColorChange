using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DataGridTestSample;



public sealed partial class MainWindow : Window
{
	MainWindowViewModel ViewModel = new MainWindowViewModel();

	public MainWindow()
	{
		this.InitializeComponent();
	}

	private void btnChangeCellColor_Click(object sender, RoutedEventArgs e)
	{
		var cell = FindCell(PeopleGrid, 1, 2);
		cell.Background = new SolidColorBrush(Colors.Red);
	}



	private DataGridCell FindCell(DataGrid dataGrid, int rowIndex, int columnIndex)
	{
		var rows = new List<DataGridRow>();
		FindChildren<DataGridRow>(rows, PeopleGrid);

		var cells = new List<DataGridCell>();

		if (rowIndex < rows.Count)
		{
			FindChildren<DataGridCell>(cells, rows[rowIndex]);
		}

		return (columnIndex < cells.Count) ? cells[columnIndex] : null;
	}



	private void FindChildren<T>(List<T> results, DependencyObject startNode) where T : DependencyObject
	{
		int count = VisualTreeHelper.GetChildrenCount(startNode);
		for (int i = 0; i < count; i++)
		{
			DependencyObject current = VisualTreeHelper.GetChild(startNode, i);
			if ((current.GetType()).Equals(typeof(T)) || (current.GetType().GetTypeInfo().IsSubclassOf(typeof(T))))
			{
				T asType = (T)current;
				results.Add(asType);
			}
			FindChildren<T>(results, current);
		}
	}
}
