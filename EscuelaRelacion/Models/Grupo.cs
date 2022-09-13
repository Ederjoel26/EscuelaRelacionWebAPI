using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscuelaRelacion.Models
{
    public class Grupo
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public int Aula { get; set; }
        public virtual List<EstudianteGrupo> EstudianteGrupos { get; set; }
    }

    public class GrupoDTO
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public int Aula { get; set; }
    }
}