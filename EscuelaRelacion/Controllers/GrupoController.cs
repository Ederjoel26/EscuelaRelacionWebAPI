using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EscuelaRelacion.Models;

namespace EscuelaRelacion.Controllers
{
    public class GrupoController : ApiController
    {
        ModeloEscuela Escuela = new ModeloEscuela();

        [ActionName("AgregarGrupo")]
        [HttpPost]
        public bool Post(Grupo grupo)
        {
            try 
            {
                Escuela.Grupos.Add(grupo);
                Escuela.SaveChanges();
                return true;
            } 
            catch 
            {
                return false;
            }
        }

        [ActionName("MostrarGrupos")]
        [HttpGet]
        public IQueryable<GrupoDTO> Get()
        {
            IQueryable<GrupoDTO> Grupos =  from BaseDato in Escuela.Grupos
                                           select new GrupoDTO
                                           {
                                               ID = BaseDato.ID,
                                               Nombre = BaseDato.Nombre,
                                               Aula = BaseDato.Aula
                                           };
            return Grupos;
        }

        [ActionName("MostrarUnGrupo")]
        [HttpGet]
        public IQueryable<GrupoDTO> Get(int ID)
        {
            IQueryable<GrupoDTO> grupoDTO = from BaseDatos in Escuela.Grupos
                                where BaseDatos.ID == ID
                                select new GrupoDTO
                                {
                                    ID = BaseDatos.ID,
                                    Nombre = BaseDatos.Nombre,
                                    Aula = BaseDatos.Aula
                                };
            return grupoDTO;
        }

        [ActionName("ActualizarGrupo")]
        [HttpPut]
        public bool Put(Grupo grupo)
        {
            try
            {
                Escuela.Entry(grupo).State = System.Data.Entity.EntityState.Modified;
                Escuela.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            } 
        }

        [ActionName("BorrarGrupo")]
        [HttpDelete]
        public bool Delete(int ID)
        {
            try
            {
                Grupo grupo = Escuela.Grupos.Find(ID);
                Escuela.Entry(grupo).State = System.Data.Entity.EntityState.Deleted;
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
