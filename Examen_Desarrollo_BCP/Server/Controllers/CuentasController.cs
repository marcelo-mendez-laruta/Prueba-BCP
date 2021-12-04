using Examen_Desarrollo_BCP.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examen_Desarrollo_BCP.Server.Controllers
{ 

    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        readonly string constr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["BCP_Connection"];
        // GET: api/<CuentasController>
        [HttpGet]
        public ActionResult<IEnumerable<CuentaModel>> Get()
        {
            List<CuentaModel> cuentas = new();
            using SqlConnection connection = new(constr);
            using SqlCommand cmd = new("ListaCuentas", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            connection.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    cuentas.Add(new CuentaModel
                    {
                        NRO_CUENTA = Convert.ToString(sdr["NRO_CUENTA"]),
                        TIPO = Convert.ToString(sdr["TIPO"]),
                        MONEDA = Convert.ToString(sdr["MONEDA"]),
                        NOMBRE = Convert.ToString(sdr["NOMBRE"]),
                        SALDO = Math.Round(Convert.ToDecimal(sdr["SALDO"]), 2),
                    });
                }
            }
            connection.Close();
            return cuentas;


        }

        // GET api/<CuentasController>/5
        [HttpGet("{id}")]
        public ActionResult<CuentaModel> Get(string id)
        {
            using SqlConnection connection = new(constr);
            CuentaModel cuenta = new();
            connection.Open();
            using SqlCommand cmd = new SqlCommand("ObtenerCuenta", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CUENTA", id);
            try
            {
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        cuenta = new CuentaModel
                        {
                            NRO_CUENTA = Convert.ToString(sdr["NRO_CUENTA"]),
                            TIPO = Convert.ToString(sdr["TIPO"]),
                            MONEDA = Convert.ToString(sdr["MONEDA"]),
                            NOMBRE = Convert.ToString(sdr["NOMBRE"]),
                            SALDO = Math.Round(Convert.ToDecimal(sdr["SALDO"]), 2),
                        };
                    }
                }
                connection.Close();
                return cuenta;
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        // POST api/<CuentasController>
        [HttpPost]
        public ActionResult<CuentaModel> Post(CuentaModel NuevaCuenta)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using SqlConnection connection = new(constr);
            connection.Open();
            using SqlCommand cmd = new SqlCommand("CrearCuenta", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CUENTA", NuevaCuenta.NRO_CUENTA);
            cmd.Parameters.AddWithValue("@TIPO", NuevaCuenta.TIPO);
            cmd.Parameters.AddWithValue("@MONEDA", NuevaCuenta.MONEDA);
            cmd.Parameters.AddWithValue("@NOMBRE", NuevaCuenta.NOMBRE);
            cmd.Parameters.AddWithValue("@SALDO", NuevaCuenta.SALDO);
            try
            {
                using IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["NRO_CUENTA"] + " " + reader["NOMBRE"]);
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }

        }

    }
}
