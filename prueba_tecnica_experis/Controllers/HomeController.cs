using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using business;
using data;
using data.Models;

namespace prueba_tecnica_experis.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Se instancia la clase de capa de negocio
        /// </summary>
        readonly busines model = new busines();

        /// <summary>
        /// Vista principal
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo para consular las opciones de tecnologia por id de tecnologia
        /// </summary>
        /// <param name="idtipotecnologia"></param>
        /// <returns></returns>

        public JsonResult GetOpcionesTecnologia(int idtipotecnologia)
        {
            int rta = 0;
            string result = "";

            List<opciones_tecnologia> Opciones = new List<opciones_tecnologia>();
            
            try
            {
                Opciones = model.GetOpcionesByTipo(idtipotecnologia);
                if(Opciones.Count > 0)
                {
                    int count = 0;
                    foreach(opciones_tecnologia i in Opciones)
                    {
                        count += 1;
                        result += "<tr>";
                        result += "<td><input type='checkbox' id='chk_"+count+"' value='"+i.orden_id+"'></td>";
                        result += "<td>"+i.orden_id+"</td>";
                        result += "<td>"+i.descripcion+"</td>";
                        result += "</tr>";
                    }
                }
                else
                {
                    result += "<tr>";
                    result += "<td colspan='3' class='text-center'>Sin información</td>";
                    result += "</tr>";
                }
                
            }
            catch (Exception ex)
            {
                rta = 1;
                result = "No se ha podido obtener la informacion: " + ex.Message;
            }

            return Json(new {respuesta = rta, resultado = result, count = Opciones.Count },JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Metodo para buscar los usuarios de las tecnologias seleccionadas
        /// </summary>
        /// <param name="seleccionados"></param>
        /// <returns></returns>
        public ActionResult BuscarUsuarios(string seleccionados)
        {
            List<Usuario> ListaUsuarios = model.GetUsuarios(seleccionados);
            List<tipo_entrevista> tipoentrevista = model.Get_tipo_entrevista_list();
            ViewBag.tipoentrevista = tipoentrevista;
            return View(ListaUsuarios);
        }

        /// <summary>
        /// Metiodo para validad la disponibilidad de la entrevista
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <returns></returns>
        public bool Validar_Disponibilidad(DateTime fecha, string hora)
        {
            bool rta = model.Validar_Disponibilidad(fecha, hora);
            return rta;
        }


        /// <summary>
        /// Metodo json para guardar la entrevista
        /// </summary>
        /// <param name="posicion"></param>
        /// <param name="id_candidato"></param>
        /// <param name="tipo_entrevista"></param>
        /// <param name="fecha_entrevista"></param>
        /// <param name="hora_entrevista"></param>
        /// <param name="observaciones"></param>
        /// <returns></returns>
        public JsonResult GuardarEntrevista(int posicion, int id_candidato, int tipo_entrevista, DateTime fecha_entrevista, string hora_entrevista, string observaciones)
        {
            bool rta = false;
            candidato candidato = model.GetCandidatoById(id_candidato);
            if (candidato == null)
            {
                Usuario usuario = model.GetUsuarioById(id_candidato);
                rta = model.InsertarCandidato(usuario);
            }
            else
            {
                
                rta = true;
            }

            if (rta)
            {
                candidato = model.GetCandidatoById(id_candidato);
                entrevista entrevista = new entrevista();
                entrevista.candidato_id = candidato.id_candidato;
                entrevista.tipo_entrevista_id = tipo_entrevista;
                entrevista.fecha_entrevista = fecha_entrevista;
                entrevista.hora_entrevista = hora_entrevista;
                entrevista.observaciones = observaciones;

                rta = model.InsertarEntrevista(entrevista);

                if (rta)
                {
                    posicion = posicion + 1;
                    return Json(new { rta = rta, psc = posicion, msj = "Visita programada correctamente" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { rta = rta, psc = posicion, msj = "Ah ocurrido un error durante la programacion de la entrevista" },JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { rta = rta, psc = posicion, msj = "Ah ocurrido un error durante la programacion de la entrevista" },JsonRequestBehavior.AllowGet);
            }
            
        }

        /// <summary>
        /// Metodo para obtener el listado de entrevistas
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public ActionResult EntrevistasList(DateTime? fecha)
        {
            List<entrevista> entrevistas = model.GetEntrevistas(fecha);

            return View(entrevistas);
        }

    }
}