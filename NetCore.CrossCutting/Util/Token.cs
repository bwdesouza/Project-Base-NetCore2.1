using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NetCore.CrossCutting.Util
{
    public static class Token
    {
        /// <summary>
        /// Recebe o token bearer e decodifica para json
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string DecodeToken(string token)
        {
            try
            {
                if (String.IsNullOrEmpty(token))
                    return String.Empty;

                var handler = new JwtSecurityTokenHandler();
                token = token.Contains(" ") ? token.Split(' ')[1] : token;
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                               
                var strJson = JsonConvert.SerializeObject(jsonToken.Payload);                               

                return strJson.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }       
    }
}
