using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBrontoLeagues.Utils
{
   public  class GenericHttpJson
    {
        public T PostEventResponse<T, U>(U pObject, string pUri, string pAuthorizationHeader)
        {
            try
            {
                if (String.IsNullOrEmpty(pUri))
                    throw new Exception("Incorrect format pUri");
                var http = new HttpClient();
                http.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent body = null;

                if (pObject != null)
                {
                    var jsonSerialized = JsonConvert.SerializeObject(pObject);
                    body = new StringContent(jsonSerialized, Encoding.UTF8, "application/json");
                }

                if (!String.IsNullOrEmpty(pAuthorizationHeader))
                {
                    var authenticationHeaderValue = new AuthenticationHeaderValue("Authorization", pAuthorizationHeader);
                    http.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
                }

                var response = http.PostAsync($"{pUri}", body).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                var jsonDeserialized = JsonConvert.DeserializeObject<T>(res);
                return jsonDeserialized;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public string GetEventResponse(string pUri, string pAuthorizationHeader)
        {
            try
            {
                if (String.IsNullOrEmpty(pUri))
                    throw new Exception("Incorrect format pUri");
                var http = new HttpClient();

                if (!String.IsNullOrEmpty(pAuthorizationHeader))
                {
                    var authenticationHeaderValue = new AuthenticationHeaderValue("Authorization", pAuthorizationHeader);
                    http.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
                }

                var response = http.GetAsync($"{pUri}").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

