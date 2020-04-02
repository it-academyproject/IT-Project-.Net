using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ItAcademyProjecteNET.Lib.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "ItAcademyProjecteNET";
        public const string AUDIENCE = "http://localhost:44313/";
        const string KEY = "mysupersecret_secretkey!345";
        public const int LIFETIME = 10;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
