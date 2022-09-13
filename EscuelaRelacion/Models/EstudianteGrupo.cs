using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscuelaRelacion.Models
{
    public class EstudianteGrupo
    {
        public int ID { get; set; }
        public int EstudianteID { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public int GrupoID { get; set; }
        public virtual Grupo Grupo { get; set; }
    }

    public class EstudianteGrupoDTO
    {
        public int EstudianteID { get; set; }
        public String EstudianteNombre { get; set; }
        public String EstudianteApellidoPaterno { get; set; }
        public String EstudianteApellidoMaterno { get; set; }
        public int EstudianteEdad { get; set; }
        public int GrupoID { get; set; }
        public String GrupoNombre { get; set; }
        public int GrupoAula { get; set; }
    }
}