using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using VeraDemoNet.DataAccess;

namespace VeraDemoNet.Controllers
{
    public abstract class AuthControllerBase : Controller
    {
        private string sqlUser =
            "select username, real_name as realname, blab_name as blabname, is_admin as isadmin from users where username = @username and password = @password";

        protected BasicUser LoginUser(string userName, string passWord)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            using (var dbContext = new BlabberDB())
            {
                dbContext.Database.Connection.Open();
                var userCommand = dbContext.Database.Connection.CreateCommand();
                userCommand.CommandText = sqlUser;
                userCommand.Parameters.Add(new SqlParameter("@username", userName));
                userCommand.Parameters.Add(new SqlParameter("@password", Md5Hash(passWord)));
                var result = userCommand.ExecuteReader();

                if (result.Read())
                {
                    Session["username"] = userName;
                    return new BasicUser
                    {
                        UserName = result.GetString(0),
                        RealName = result.GetString(1),
                        BlabName = result.GetString(2),
                        IsAdmin = result.GetBoolean(3)
                    };
                }
            }

            return null;
        }

        protected string GetLoggedInUsername()
        {
            return Session["username"].ToString();
        }

        protected void LogoutUser()
        {
            Session["username"] = null;
        }

        protected bool IsUserLoggedIn()
        {
            return string.IsNullOrEmpty(Session["username"] as string) == false;

        }

        protected RedirectToRouteResult RedirectToLogin(string targetUrl)
        {
            return new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary
                (new
                {
                    controller = "Account",
                    action = "Login",
                    ReturnUrl = HttpContext.Request.RawUrl
                }));
        }

        protected static string Md5Hash(string input)
        {
            var sb = new StringBuilder();
            if (string.IsNullOrEmpty(input))
            {
                return sb.ToString();
            }

            using (MD5 md5 = MD5.Create())
            {
                var retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(input));

                foreach (var t in retVal)
                {
                    sb.Append(t.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}