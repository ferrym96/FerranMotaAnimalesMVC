using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FerranMotaAnimalesMVC.Models
{
    public class TipoAnimal
    {
        public int IdTipoAnimal { get; set; }
        public string TipoDescripcion { get; set; }

        public TipoAnimal(int idTipoAnimal, string tipoDescripcion)
        {
            IdTipoAnimal = idTipoAnimal;
            TipoDescripcion = tipoDescripcion;
        }
    }
}