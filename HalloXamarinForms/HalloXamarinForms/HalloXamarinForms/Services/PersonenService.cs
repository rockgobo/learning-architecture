using HalloXamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HalloXamarinForms.Services
{
    class PersonenService
    {
        public List<Person> GetPersonen()
        {
            return new List<Person>
            {
                new Person{Name="Tom Ate", Status="Online", Profilbild="http://lorempixel.com/100/100/people/1/"},
                new Person{Name="Anna Nass", Status="Abwesend", Profilbild="http://lorempixel.com/100/100/people/2/"},
                new Person{Name="Peter Silie", Status="Online", Profilbild="http://lorempixel.com/100/100/people/3/"},
                new Person{Name="Franz Ose", Status="Offline", Profilbild="http://lorempixel.com/100/100/people/4/"},
                new Person{Name="Martha Pfahl", Status="Abwesend", Profilbild="http://lorempixel.com/100/100/people/5/"},
                new Person{Name="Rainer Zufall", Status="Online", Profilbild="http://lorempixel.com/100/100/people/6/"},
                new Person{Name="Klara Fall", Status="Beschäftigt", Profilbild="http://lorempixel.com/100/100/people/7/"},
                new Person{Name="Bill Dung", Status="Abwesend", Profilbild="http://lorempixel.com/100/100/people/8/"}
            };
        }
    }
}
