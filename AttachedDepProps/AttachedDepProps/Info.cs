using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttachedDepProps
{
  public class Info
  {


    public static string GetProgrammierer(DependencyObject obj)
    {
      return (string)obj.GetValue(ProgrammiererProperty);
    }

    public static void SetProgrammierer(DependencyObject obj, string value)
    {
      obj.SetValue(ProgrammiererProperty, value);
    }

    // Using a DependencyProperty as the backing store for Programmierer.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ProgrammiererProperty =
        DependencyProperty.RegisterAttached("Programmierer", typeof(string), typeof(Info), new FrameworkPropertyMetadata("unbekannt",ProgrammiererChanged));

    private static void ProgrammiererChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      
    }
  }
}
