using System.Collections.Generic;

namespace Datenbindung2
{
  class Person
  {
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public int Alter { get; set; }

    public bool IstErfahren => Alter > 65;
  }

  class Firma
  {
    public string Name { get; set; } = "Hinz & Kunz";
    public List<Person> Mitarbeiter { get; set; } = new()
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
