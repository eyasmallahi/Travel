using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace API.Controllers
{
    public class TravelController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        public TravelController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        private List<Travel> LoadListFromDb()
        {
            List<Travel> listMain = new List<Travel>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Select * from tbl_Travel", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                Travel obj = new Travel();
                obj.id = dt.Rows[i]["id"].ToString();
                obj.FromContry = dt.Rows[i]["FromContry"].ToString();
                obj.ToContry = dt.Rows[i]["ToContry"].ToString();


                obj.TimeStamp = DateTime.Parse(dt.Rows[i]["TimeStamp"].ToString());
                obj.TravelPrice = (int)decimal.Parse(dt.Rows[i]["TravelPrice"].ToString());
               obj.PassengerCount = (int)decimal.Parse(dt.Rows[i]["PassengerCount"].ToString());


                listMain.Add(obj);

            }

            return listMain;
        }




        // GET: api/<AppUser>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Travel>>> GetUsers()
        {
            return LoadListFromDb();
        }

    }
}
