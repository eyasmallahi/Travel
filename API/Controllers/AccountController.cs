using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;

        }





        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDTO loginDTO)
        { 

            return 

        }






            [HttpPost("Register")]
        public async Task<ActionResult<AppUser>> Registers(RegisterDto registerDto)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                FullName = registerDto.FullName,
                HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password)),
                SaltPassword = hmac.Key

            };
            string cs = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(cs))
            {


                user.HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password));
                user.SaltPassword = hmac.Key;

                string Query = "INSERT INTO tbl_User(Id, FullName, Age, Email, phoneNumber, Contry, City, street, HashPassword, SaltPassword ,user_role ) VALUES(@id,@FullName,@Age,@Email,@phoneNumber,@Contry,@City,@street,@password, @SaltPassword, @user_role)";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@id", registerDto.Id);
                cmd.Parameters.AddWithValue("@FullName", registerDto.FullName);
                cmd.Parameters.AddWithValue("@Age", registerDto.Age);
                cmd.Parameters.AddWithValue("@Email", registerDto.Email);
                cmd.Parameters.AddWithValue("@phoneNumber", registerDto.phoneNumber);
                cmd.Parameters.AddWithValue("@Contry", registerDto.Contry);
                cmd.Parameters.AddWithValue("@City", registerDto.City);
                cmd.Parameters.AddWithValue("@street", registerDto.street);
                cmd.Parameters.AddWithValue("@password", user.HashPassword);
                cmd.Parameters.AddWithValue("@SaltPassword", user.SaltPassword);
                cmd.Parameters.AddWithValue("@user_role", registerDto.user_role);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Ok();


            }




            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    if (con.State == ConnectionState.Closed)
            //        con.Open();
            //    IDataReader reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        user.Id = registerDto.Id;
            //        user.FullName = registerDto.FullName;
            //user.HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.password));
            //user.SaltPassword = hmac.Key;
            //        user.street = registerDto.street;
            //        user.Age = registerDto.Age;
            //        user.City = registerDto.City;
            //        user.Contry = registerDto.Contry;
            //        user.UserType = registerDto.UserType;
            //        user.Id = registerDto.Id;
            //        user.Email = registerDto.Email;
            //        user.phoneNumber = registerDto.phoneNumber;

            //    } }

            //return user;
        }



    }

}
