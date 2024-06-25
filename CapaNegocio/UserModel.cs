using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocio
{
    public class UserModel
    {

        CD_Usuario user_CD = new CD_Usuario();
        public bool LoginUser(string user, string pass)
        {
            return user_CD.Login(user, pass);
        }
    }
}
