using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace Datenbindung1
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    static App()
    {
      string text = string.Format("{0:0.0}", 1.2345);

      FrameworkElement.LanguageProperty.OverrideMetadata(
        typeof(FrameworkElement),
        new FrameworkPropertyMetadata(
          XmlLanguage.GetLanguage(
             CultureInfo.CurrentCulture.Name)
          )
        );

    }
  }
}
