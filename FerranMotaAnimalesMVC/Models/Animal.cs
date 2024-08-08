using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FerranMotaAnimalesMVC.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string NombreAnimal { get; set; }
        public string Raza { get; set; }
        public int RIdTipoAnimal { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public Animal(int idAnimal, string nombreAnimal, string raza, int rIdTipoAnimal, DateTime? fechaNacimiento)
        {
            IdAnimal = idAnimal;
            NombreAnimal = nombreAnimal;
            Raza = raza;
            RIdTipoAnimal = rIdTipoAnimal;
            FechaNacimiento = fechaNacimiento;
        }

        public Animal() { }
    }
}