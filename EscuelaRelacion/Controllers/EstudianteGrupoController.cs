using EscuelaRelacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscuelaRelacion.Controllers
{
    public class EstudianteGrupoController : ApiController
    {
        ModeloEscuela bd = new ModeloEscuela();
        [ActionName("Insertar")]
        [HttpPost]
        public bool Post(List<EstudianteGrupo> estudiantesGrupo)
        {
            try
            {
                foreach (EstudianteGrupo estudiante in estudiantesGrupo)
                {
                    var consulta = bd.EstudianteGrupos.Where(c => c.GrupoID == estudiante.GrupoID && c.EstudianteID == estudiante.EstudianteID);

                    if (consulta.Count() == 0)
                    {
                        bd.EstudianteGrupos.Add(estudiante);
                        bd.SaveChanges();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        [ActionName("MostrarEstudiante")]
        [HttpGet]
        public IQueryable<EstudianteGrupoDTO> Get(int ID)
        {
            IQueryable<EstudianteGrupoDTO> estudianteGrupoDTO = from BaseDatos in bd.EstudianteGrupos
                                                    where BaseDatos.Estudiante.ID == ID
                                                    select new EstudianteGrupoDTO
                                                    {
                                                        EstudianteNombre = BaseDatos.Estudiante.Nombre,
                                                        EstudianteApellidoPaterno = BaseDatos.Estudiante.ApellidoPaterno,
                                                        EstudianteApellidoMaterno = BaseDatos.Estudiante.ApellidoMaterno,
                                                        EstudianteEdad = BaseDatos.Estudiante.Edad,
                                                        GrupoID = BaseDatos.Grupo.ID,
                                                        GrupoNombre = BaseDatos.Grupo.Nombre,
                                                        GrupoAula = BaseDatos.Grupo.Aula
                                                    };
            return estudianteGrupoDTO;
        }
    }
}
