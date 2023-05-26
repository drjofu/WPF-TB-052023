using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AsyncBeispiele
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }

    CancellationTokenSource cts;

    private void BTN_Stop_Click(object sender, RoutedEventArgs e)
    {
      cts?.Cancel();
    }

    private async void BTN_Start_Click(object sender, RoutedEventArgs e)
    {
      cts = new CancellationTokenSource();

      BTN_Start.IsEnabled = false;
      //Task.Run(Inkrementieren)
      //  .ContinueWith(t => BTN_Start.IsEnabled = true,
      //  TaskScheduler.FromCurrentSynchronizationContext());

      var progress = new Progress<int>(Anzeigen);

      //var t1 = Task.Run(async () => await Inkrementieren(cts.Token, progress), cts.Token);
      var t1 = Inkrementieren(cts.Token, progress);

      Task<int> t2 = null;
      try
      {
        await t1;

        //await Task.WhenAll(t1, t1, t1);
        t2 = Berechnen(cts.Token);
        int x = await t2;
        LBL.Content = x;

      }
      catch (Exception ex)
      {
      }
      BTN_Start.IsEnabled = true;

      LBL_Status.Content = t1?.Status;

      cts?.Dispose();
    }

    private void Anzeigen(int data)
    {
      LBL.Content = data;
    }

    private async Task<int> Berechnen(CancellationToken cancellationToken)
    {
      //throw new ApplicationException("bumm");
      await Task.Delay(1000, cancellationToken);
      return 42;
    }

    private async Task Inkrementieren(CancellationToken cancellationToken,
      IProgress<int> progress)
    {
      for (int i = 0; i < 5; i++)
      {
        if (cancellationToken.IsCancellationRequested)
        {
          // aufräumen bei Bedarf
          cancellationToken.ThrowIfCancellationRequested();
        }

        progress.Report(i);

        await Task.Delay(1000);

        //int k = i;
        //Thread.Sleep(1000);  // nur zur Demo!
        ////LBL.Content = k;
        ////Dispatcher.Invoke(() => LBL.Content = k);
        //Dispatcher.BeginInvoke(() => LBL.Content = k);
        ////Dispatcher.BeginInvoke(() => Debug.WriteLine(k));
      }
    }

  }
}
