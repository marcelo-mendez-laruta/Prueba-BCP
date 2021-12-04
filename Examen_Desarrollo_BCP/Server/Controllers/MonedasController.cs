using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examen_Desarrollo_BCP.Shared.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Examen_Desarrollo_BCP.Server.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class MonedasController : Controller
    {
        readonly string constr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["BCP_Connection"];
        // GET: MonedasController
        [HttpGet]
        public ActionResult<IEnumerable<MonedaModel>> Index()
        {

            List<MonedaModel> monedas = new ();
            using (SqlConnection con = new (constr))
            {
                using SqlCommand cmd = new("ListadeMonedas", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        monedas.Add(new MonedaModel
                        {
                            Codigo = Convert.ToString(sdr["Codigo"]),
                            Nombre = Convert.ToString(sdr["Nombre"])
                        });
                    }
                }
                con.Close();
            }

            return monedas;

        }

    }
}
