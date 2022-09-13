using EscuelaRelacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace EscuelaRelacion.Controllers
{
    public class EstudianteController : ApiController
    {
        ModeloEscuela Escuela = new ModeloEscuela();
        [ActionName("AgregarEstudiante")]
        [HttpPost]
        public bool Post(Estudiante estudiante)
        {
            try
            {
                Escuela.Estudiantes.Add(estudiante);
                Escuela.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [ActionName("MostrarEstudiantes")]
        [HttpGet]
        public IQueryable<EstudianteDTO> Get()
        {
            IQueryable<EstudianteDTO> estudiantes = from BaseDatos in Escuela.Estudiantes
                                                    select new EstudianteDTO
                                                    {
                                                        ID = BaseDatos.ID,
                                                        Nombre = BaseDatos.Nombre,
                                                        ApellidoPaterno = BaseDatos.ApellidoPaterno,
                                                        ApellidoMaterno = BaseDatos.ApellidoMaterno,
                                                        Edad = BaseDatos.Edad
                                                    };
            return estudiantes;
        }

        [ActionName("MostrarUnEstudiante")]
        [HttpGet]
        public IQueryable<EstudianteDTO> Get(int ID)
        {
            IQueryable<EstudianteDTO> estudianteDTO = from BaseDatos in Escuela.Estudiantes
                                          where BaseDatos.ID == ID
                                          select new EstudianteDTO
                                          {
                                            ID = BaseDatos.ID,
                                            Nombre = BaseDatos.Nombre,
                                            ApellidoPaterno = BaseDatos.ApellidoPaterno,
                                            ApellidoMaterno = BaseDatos.ApellidoMaterno,
                                            Edad = BaseDatos.Edad
                                          };
            return estudianteDTO;
        }

        [ActionName("ActualizarEstudiante")]
        [HttpPut]
        public bool Put(Estudiante estudiante)
        {
            try
            {
                Escuela.Entry(estudiante).State = System.Data.Entity.EntityState.Modified;
                Escuela.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [ActionName("EliminarEstudiante")]
        [HttpDelete]
        public bool Delete(int ID)
        {
            try
            {
                Estudiante estudiante = Escuela.Estudiantes.Find(ID);
                Escuela.Entry(estudiante).State = System.Data.Entity.EntityState.Deleted;
                Escuela.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
