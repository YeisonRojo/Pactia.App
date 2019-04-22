using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace SharedContent
{
    public class Service
    {
        public T HttpGet<T>(string url, string controller, string method, string parameter)
        {            
            string path = string.Format("{0}/{1}/{2}?{3}", url, controller, method, parameter);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var json = reader.ReadToEnd();
                        var result = JsonConvert.DeserializeObject<T>(json);
                        return result;
                    }
                }
                else
                {
                    if(response.StatusCode == HttpStatusCode.NotFound) 
                    {
                        throw new Exception("No se encontraron registros.");
                    }
                    else
                    {
                        throw new Exception("El servicio no está disponible actualmente, por favor intente de nuevo mas tarde.");
                    }
               }
        }
    }
}
