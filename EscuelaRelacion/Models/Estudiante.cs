using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscuelaRelacion.Models
{
    public class Estudiante
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public virtual List<EstudianteGrupo> EstudianteGrupos { get; set; }
    }

    public class EstudianteDTO
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public int Edad { get; set; }
    }
}