using Examen_Desarrollo_BCP.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examen_Desarrollo_BCP.Server.Controllers
{
    [Route("api/Movimientos")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        readonly string constr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["BCP_Connection"];
        // GET: api/<MovimientosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MovimientosController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MovimientoModel>> Get(string id)
        {
            List<MovimientoModel> movimientos = new();
            using SqlConnection connection = new(constr);
            using SqlCommand cmd = new("ListaMovimientos", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NRO_CUENTA", id);
            connection.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    movimientos.Add(new MovimientoModel
                    {
                        NRO_CUENTA = Convert.ToString(sdr["NRO_CUENTA"]),
                        TIPO = Convert.ToString(sdr["TIPO"]),
                        FECHA = DateTime.Parse((string)sdr["MONEDA"]),
                        IMPORTE = Math.Round(Convert.ToDecimal(sdr["IMPORTE"]), 2),
                    });
                }
            }
            connection.Close();
            return movimientos;
        }

        // POST api/<MovimientosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovimientosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovimientosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
