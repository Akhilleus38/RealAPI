using System;
using System.Collections.Generic;
using System.Text;

namespace RealAPI.Model.Login
{
   
    public class LoginApiResponseModel
    {

        
        public string token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expireDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refreshToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string refreshTokenExpireDate { get; set; }
    }


}
