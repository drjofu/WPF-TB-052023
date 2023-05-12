using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Datenbindung2
{
  class Person : INotifyPropertyChanged
  {
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    //public int Alter { get; set; }
    private int alter;

    public int Alter
    {
      get { return alter; }
      set
      {
        if (alter == value) return;

        alter = value;
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AlterXXX"));
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IstErfahren"));

        OnPropertyChanged();
        OnPropertyChanged(nameof(IstErfahren));
      }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public bool IstErfahren => Alter > 65;

    public event PropertyChangedEventHandler PropertyChanged;
  }

  class Firma
  {
    public string Name { get; set; } = "Hinz & Kunz";
    public ObservableCollection<Person> Mitarbeiter { get; set; } = new()
    {
        new Person() {Vorname="Dagobert", Nachname="Duck", Alter=78},
        new Person() {Vorname="Donald", Nachname="Duck", Alter=55},
        new Person() {Vorname="Micky", Nachname="Mouse", Alter=67},
        new Person() {Vorname="Daisy", Nachname="Duck", Alter=45},
        new Person() {Vorname="Panzer", Nachname="Knacker", Alter=34},
        new Person() {Vorname="Gustav", Nachname="Gans", Alter=25}
    };
  }
}
