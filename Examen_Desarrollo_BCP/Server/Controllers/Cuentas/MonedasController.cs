using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examen_Desarrollo_BCP.Shared.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Examen_Desarrollo_BCP.Server.Controllers.Cuentas
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonedasController : Controller
    {
        private string constr = "Data Source=host.docker.internal,1433;Initial Catalog=bcpdb;User ID=sa;Password=bcp12345";
        // GET: MonedasController
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
