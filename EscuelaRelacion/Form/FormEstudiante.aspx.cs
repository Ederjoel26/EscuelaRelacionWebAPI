using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EscuelaRelacion.Models;
using HTTPupt;

namespace EscuelaRelacion.Form
{
    public partial class FormEstudiante : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:59038");
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void btnIngresarEstudiante_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = new Estudiante()
            {
                Nombre = txtNombre.Text,
                ApellidoPaterno = txtApellidoPaterno.Text,
                ApellidoMaterno = txtApellidoMaterno.Text,
                Edad = int.Parse(txtEdad.Text)
            };

            String JsonEnviar = JsonConvertidor.Objeto_Json(estudiante);
            peticion.PedirComunicacion("Estudiante/AgregarEstudiante", MetodoHTTP.POST,TipoContenido.JSON);
            peticion.enviarDatos(JsonEnviar);
            String jsonRecibir = peticion.ObtenerJson();
            CargarDatos();
        }

        private void CargarDatos()
        {
            peticion.PedirComunicacion("Estudiante/MostrarEstudiantes",MetodoHTTP.GET,TipoContenido.JSON);
            String Estudiantes = peticion.ObtenerJson();
            List<Estudiante> estudiantes = JsonConvertidor.Json_ListaObjeto<Estudiante>(Estudiantes);
            gvTablaEstudiante.DataSource = estudiantes;
            gvTablaEstudiante.DataBind();
        }

        protected void gvTablaEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}