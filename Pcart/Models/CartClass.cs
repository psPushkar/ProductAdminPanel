using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pcart.Models
{
    public class CartClass
    {
        CartContext cc = new CartContext();
        public bool IsValidUser(UserLogin u)
        {
            UserDetails ud = new UserDetails
            {
                Email = u.Email
            };

            UserDetails nu = cc.Dsusers.Where(a => a.Email.ToLower() == ud.Email).SingleOrDefault();

            if ((nu != null) && (u.Password == nu.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static implicit operator UserLogin(UserDetails ud)
        //{
        //    return new UserLogin
        //    {
        //        Email = ud.Email,
        //        Password = ud.Password
        //    };
        //}

        //public static implicit operator UserDetails(UserLogin ul)
        //{
        //    return new UserDetails
        //    {
        //        Email = ul.Email,
        //        Password = ul.Password
        //    };
        //}
    }
}