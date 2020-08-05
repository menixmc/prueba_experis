using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.Models;
using data;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace business
{
    public class busines
    {
        /// <summary>
        /// Instancia del modelo
        /// </summary>
        readonly modeloEntities db = new modeloEntities();


        /// <summary>
        /// Metodo para obtener el listado de opciones pos id
        /// </summary>
        /// <param name="idtipotecnologia"></param>
        /// <returns></returns>
        public List<opciones_tecnologia> GetOpcionesByTipo(int idtipotecnologia)
        {
            return db.opciones_tecnologia.Where(l => l.tipo_tecnologia_id == idtipotecnologia).ToList();
        }


        /// <summary>
        /// Metodo get para consumir la api
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static dynamic ConsumirApi(string url)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            HttpWebRequest myWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
            myWebRequest.Credentials = CredentialCache.DefaultCredentials;
            myWebRequest.Proxy = null;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myWebRequest.GetResponse();
            Stream myStream = myHttpWebResponse.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myStream);
            string Datos = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd());
            dynamic data = JsonConvert.DeserializeObject(Datos);
            return data;
        }


        /// <summary>
        /// Metodo para consultar usuarios consumiendo la api
        /// </summary>
        /// <param name="seleccionados"></param>
        /// <returns></returns>
        public List<Usuario> GetUsuarios(string seleccionados)
        {
            List<Usuario> listadousuarios = new List<Usuario>();
            var lista_seleccionados = seleccionados.Split(',');
            try
            {
                dynamic informacion = ConsumirApi("http://jsonplaceholder.typicode.com/users");
                listadousuarios = JsonConvert.DeserializeObject<List<Usuario>>(JsonConvert.SerializeObject(informacion));

                List<Usuario> Usuarios = new List<Usuario>();

                int impares = lista_seleccionados.Where(l => Convert.ToInt32(l) % 2 != 0).Count();
                if (impares > 0)
                {
                    var usuariosimpares = listadousuarios.Where(l => l.id % 2 != 0).ToList();
                    Usuarios.AddRange(usuariosimpares);
                }

                int pares = lista_seleccionados.Where(l => Convert.ToInt32(l) % 2 == 0).Count();
                if (pares > 0)
                {
                    var usuariosipares = listadousuarios.Where(l => l.id % 2 == 0).ToList();
                    Usuarios.AddRange(usuariosipares);
                }

                return Usuarios.OrderBy(l => l.id).ToList(); ;
            }
            catch
            {
                return listadousuarios;
            }
            
        }

        /// <summary>
        /// Metodo para obtener un usuario por id
        /// </summary>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public Usuario GetUsuarioById(int idusuario)
        {
            List<Usuario> listadousuarios = new List<Usuario>();
            dynamic informacion = ConsumirApi("http://jsonplaceholder.typicode.com/users");
            listadousuarios = JsonConvert.DeserializeObject<List<Usuario>>(JsonConvert.SerializeObject(informacion));

            if(listadousuarios.Count > 0)
            {
                return listadousuarios.Where(l => l.id == idusuario).FirstOrDefault();
            }
            else
            {
                return new Usuario();
            }
        }

        /// <summary>
        /// Metodo para obtener un candidato por id
        /// </summary>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public candidato GetCandidatoById(int idusuario)
        {
            return db.candidato.Where(l => l.api_id == idusuario).FirstOrDefault();
        }

        /// <summary>
        /// Metodo para insertar un usuario en base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool InsertarCandidato(Usuario usuario)
        {
            try
            {
                candidato obj = new candidato();
                obj.id_candidato = usuario.id;
                obj.api_id = usuario.id;
                obj.nombre = usuario.name;
                obj.email = usuario.email;
                obj.direccion_calle = usuario.address.street;
                obj.direccion_suite = usuario.address.suite;
                obj.direccion_ciudad = usuario.address.city;
                obj.direccion_codigo_postal = usuario.address.zipcode;
                obj.telefono = usuario.phone;
                obj.sitio_web = usuario.website;
                obj.compañia_nombre = usuario.company.name;
                obj.compañia_catchPhrase = usuario.company.catchPhrase;
                obj.compañia_bs = usuario.company.bs;
                db.candidato.Add(obj);
                db.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }


        /// <summary>
        /// Metodo para obtener el listado de tipo de entrevista
        /// </summary>
        /// <returns></returns>
        public List<tipo_entrevista> Get_tipo_entrevista_list()
        {
            List<tipo_entrevista> lista = new List<tipo_entrevista>();
            try
            {
                lista = db.tipo_entrevista.ToList();
                return lista;
            }
            catch
            {
                return lista;
            }
        }

        /// <summary>
        /// Metodo para validar la disponibilidad de una entrevista
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="hora"></param>
        /// <returns></returns>
        public bool Validar_Disponibilidad(DateTime fecha, string hora)
        {
            bool rta = true;
            try
            {
                entrevista entrevista = db.entrevista.Where(l => l.fecha_entrevista == fecha && l.hora_entrevista == hora).FirstOrDefault();
                if (entrevista != null)
                {
                    rta = false;
                }
            }
            catch(Exception ex)
            {
                rta = false;
            }
            

            return rta;
        }

        /// <summary>
        /// Metodo para insertar una entrevista
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool InsertarEntrevista(entrevista obj)
        {
            try
            {
                db.entrevista.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para obtener el listado de entrevistas programadas
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<entrevista> GetEntrevistas(DateTime? fecha)
        {
            if(fecha != null)
            {
                return db.entrevista.Where(l => l.fecha_entrevista == fecha).ToList();
            }
            else
            {
                return db.entrevista.ToList();
            }
        }
    }
}
