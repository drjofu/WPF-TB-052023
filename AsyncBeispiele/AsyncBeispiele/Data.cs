using System.ComponentModel;
using System.Threading;

namespace AsyncBeispiele
{
  public class Data : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;

    public int Counter { get; set; }

    Timer timer;
    public Data()
    {
      timer = new(TimerTick, null, 0, 1000);
    }

    private void TimerTick(object state)
    {
      Counter++;
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Counter)));
    }
  }
}
