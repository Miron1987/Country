using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Countries
{
    static class Networking
    {
        public static bool Request(string country, out List<Dictionary<string, object>> dictionary)
        {
            ///<summary>
            ///метод ищет страну по названию в интернете 
            ///на сайте https://restcountries.eu/rest/v2/name/
            ///сайт английский по-этому имя на английском
            ///тип ответа json
            ///ответ может содержать несколько стран
            ///поэтому приходится использовать список словарей
            ///если что-то нашли возвращаем true иначе false
            ///если ошибка - выводим сообщение 
            /// 
            /// </summary>
            dictionary = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://restcountries.eu/rest/v2/name/{country}");
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                List<Dictionary<string, object>> ctr;
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    string _str = sr.ReadToEnd();

                    try
                    {
                        ctr = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(_str);//.Substring(1, _str.Length - 2));
                    }

                    catch (Newtonsoft.Json.JsonReaderException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.GetType());
                        Console.WriteLine("Incorrect country name!!!");
                        ctr = null;
                        return false;
                    }
                }

                if (ctr != null)
                {

                    dictionary = ctr;

                    return true;
                }

                return false;
            }
                
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }
    }
}
