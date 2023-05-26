using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoutedEventsBeispiel
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void MouseDownHandler(object sender, MouseButtonEventArgs e)
    {
      //MessageBox.Show($"MouseDown {sender.GetType().Name}");
      Debug.WriteLine($"MouseDown {sender.GetType().Name}");
    }

    private void PreviewMouseDownHandler(object sender, MouseButtonEventArgs e)
    {
      //MessageBox.Show($"PreviewMouseDown {sender.GetType().Name}");
      // e.Handled = true;
      Debug.WriteLine($"PreviewMouseDown {sender.GetType().Name}");
    }
  }
}
