using Examen_Desarrollo_BCP.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examen_Desarrollo_BCP.Server.Controllers.Cuentas
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
            using (SqlConnection con = new(constr))
            {
                using SqlCommand cmd = new("ListaCuentas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
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
                            SALDO= Math.Round(Convert.ToDecimal(sdr["SALDO"]), 2),
                        });
                    }
                }
                con.Close();
            }

            return cuentas;
        }

        // GET api/<CuentasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CuentasController>
        [HttpPost]
        public ActionResult<CuentaModel> Post(CuentaModel NuevaCuenta)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (SqlConnection connection = new(constr))
            {
                connection.Open();
                using SqlCommand textCommand = new SqlCommand("CrearCuenta", connection);
                textCommand.CommandType = System.Data.CommandType.StoredProcedure;
                textCommand.Parameters.AddWithValue("@NRO_CUENTA", NuevaCuenta.NRO_CUENTA);
                textCommand.Parameters.AddWithValue("@TIPO", NuevaCuenta.TIPO);
                textCommand.Parameters.AddWithValue("@MONEDA", NuevaCuenta.MONEDA);
                textCommand.Parameters.AddWithValue("@NOMBRE", NuevaCuenta.NOMBRE);
                textCommand.Parameters.AddWithValue("@SALDO", NuevaCuenta.SALDO);
                try
                {
                    using IDataReader reader = textCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["NRO_CUENTA"] + " " + reader["NOMBRE"]);
                    }
                }
                catch (Exception e)
                {
                    return BadRequest();
                }               
            }
            return Ok();
        }

    }
}
