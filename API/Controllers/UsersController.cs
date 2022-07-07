using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    
    public class UsersController : BaseApiController
    {

        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        { 
        _configuration= configuration;
        
        }

        private List<AppUser> LoadListFromDb()
        {
            string cs = _configuration.GetConnectionString("DefaultConnection");

            List<AppUser> listMain = new List<AppUser>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from tbl_User", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    AppUser obj = new AppUser();
                    obj.Id = dt.Rows[i]["Id"].ToString();
                    obj.FullName = dt.Rows[i]["FullName"].ToString();
                    obj.Age = (int)decimal.Parse(dt.Rows[i]["Age"].ToString());

                    obj.phoneNumber = dt.Rows[i]["phoneNumber"].ToString();
                    obj.Contry = dt.Rows[i]["Contry"].ToString();
                    obj.City = dt.Rows[i]["City"].ToString();
                    obj.street = dt.Rows[i]["street"].ToString();
                    obj.Email = dt.Rows[i]["Email"].ToString();
                    obj.UserType = dt.Rows[i]["UserType"].ToString();

                    obj.TravelID = dt.Rows[i]["TravelID"].ToString();

                    listMain.Add(obj);

                }

                return listMain;
            }
        }


       
        // GET: api/<AppUser>
        [HttpGet]
        public async Task<ActionResult< IEnumerable<AppUser>>> GetUsers()
        {
            return LoadListFromDb();
        }

      


    }
}
