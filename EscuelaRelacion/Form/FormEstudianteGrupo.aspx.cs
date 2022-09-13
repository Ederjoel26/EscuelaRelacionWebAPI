using EscuelaRelacion.Models;
using HTTPupt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace EscuelaRelacion.Form
{
    public partial class FormEstudianteGrupo : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:59038");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosGv();
                CargarDatosDdl();
            }
        }

        protected void btnRelacionar_Click(object sender, EventArgs e)
        {
            List<EstudianteGrupo> estudiantes = new List<EstudianteGrupo>();

            foreach(GridViewRow registro in gvTablaEstudiante.Rows)
            {
                CheckBox seleccion = (CheckBox)registro.FindControl("chbEstudiantes");
                
                if (seleccion.Checked)
                {
                    EstudianteGrupo estudianteGrupo = new EstudianteGrupo()
                    {
                        GrupoID = int.Parse(ddlGrupos.SelectedValue),
                        EstudianteID = int.Parse(registro.Cells[1].Text)
                    };

                    estudiantes.Add(estudianteGrupo);
                }
            }

            String jsonEnviar = JsonConvertidor.Objeto_Json(estudiantes);
            peticion.PedirComunicacion("EstudianteGrupo/Insertar", MetodoHTTP.POST, TipoContenido.JSON);
            peticion.enviarDatos(jsonEnviar);
            String jsonRecibir = peticion.ObtenerJson();
        }
        private void CargarDatosGv()
        {
            peticion.PedirComunicacion("Estudiante/MostrarEstudiantes", MetodoHTTP.GET, TipoContenido.JSON);
            String Estudiantes = peticion.ObtenerJson();
            List<Estudiante> estudiantes = JsonConvertidor.Json_ListaObjeto<Estudiante>(Estudiantes);
            gvTablaEstudiante.DataSource = estudiantes;
            gvTablaEstudiante.DataBind();
        }
        private void CargarDatosDdl()
        {
            ddlGrupos.DataTextField = "Nombre";
            ddlGrupos.DataValueField = "ID";
            peticion.PedirComunicacion("Grupo/MostrarGrupos", MetodoHTTP.GET, TipoContenido.JSON);
            String Grupos = peticion.ObtenerJson();
            List<Grupo> grupo = JsonConvertidor.Json_ListaObjeto<Grupo>(Grupos);
            ddlGrupos.DataSource = grupo;
            ddlGrupos.DataBind(); 
        }
    }
}