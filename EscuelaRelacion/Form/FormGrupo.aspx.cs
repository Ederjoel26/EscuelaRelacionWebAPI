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
    public partial class FormGrupo : System.Web.UI.Page
    {
        PeticionHTTP peticion = new PeticionHTTP("http://localhost:59038");
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void btnIngresarGrupo_Click(object sender, EventArgs e)
        {
            Grupo grupo = new Grupo()
            {
                Nombre = txtNombre.Text,
                Aula = int.Parse(txtAula.Text)
            };

            String JsonEnviar = JsonConvertidor.Objeto_Json(grupo);
            peticion.PedirComunicacion("Grupo/AgregarGrupo", MetodoHTTP.POST, TipoContenido.JSON);
            peticion.enviarDatos(JsonEnviar);
            String jsonRecibir = peticion.ObtenerJson();
            CargarDatos();
        }

        private void CargarDatos()
        {
            peticion.PedirComunicacion("Grupo/MostrarGrupos", MetodoHTTP.GET, TipoContenido.JSON);
            String Grupo = peticion.ObtenerJson();
            List<Grupo> grupo = JsonConvertidor.Json_ListaObjeto<Grupo>(Grupo);
            gvTablaGrupo.DataSource = grupo;
            gvTablaGrupo.DataBind();
        }
    }
}