using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AglInterviewTest
{
    public class RESTClient
    {
        string baseAddress = "";
        public string BaseUrl
        {
            get { return baseAddress; }
            set { baseAddress = value; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RESTClient() { }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        /// <param name="serviceBaseUrl">Base URL of the Service</param>
        public RESTClient(string serviceBaseUrl)
        {
            this.BaseUrl = serviceBaseUrl;
        }

        public enum httpMethod { GET, POST, PUT, DELETE };

        private httpMethod _httpMethod;

        public httpMethod RequestType
        {
            get { return _httpMethod; }
            set { _httpMethod = value; }
        }
       
        /// <summary>
        /// Method to Send the Webservice request and get the response object for given URI Action
        /// </summary>
        /// <typeparam name="T">Type of return object</typeparam>
        /// <param name="uriActionString">Action path of the API URI (Exceluding the base uri)</param>
        /// <returns>Object of T type</returns>
        public T GetWSObject<T>(string uriActionString)
        {
            T returnValue =
                default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response;
                    switch (this.RequestType)
                    {
                        case httpMethod.GET:
                            response = client.GetAsync(this.BaseUrl + uriActionString).Result;
                            break;
                        case httpMethod.POST:

                            response = client.PostAsync(uriActionString, null).Result;
                            break;
                        case httpMethod.PUT:
                            response = client.PutAsync(uriActionString, null).Result;
                            break;
                        case httpMethod.DELETE:
                            response = client.DeleteAsync(uriActionString).Result;
                            break;
                        default:
                            response = client.GetAsync(uriActionString).Result;
                            break;
                    }
                    response.EnsureSuccessStatusCode();
                    returnValue = JsonConvert.DeserializeObject<T>(((HttpResponseMessage)response).Content.ReadAsStringAsync().Result);
                }
                return returnValue;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        /// <summary>
        /// Method to Send the Webservice request along with the content and get the response object for given URI Action
        /// </summary>
        /// <typeparam name="T">Type of return object</typeparam>
        /// <param name="uriActionString">Action path of the API URI (Exceluding the base uri)</param>
        /// <param name="jsonContent">request Content to send</param>
        /// <returns></returns>
        public T GetWSObject<T>(string uriActionString,
                                            string jsonContent)
        {
            T returnValue =
                default(T);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(this.BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response;
                    StringContent sc = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    switch (this.RequestType)
                    {
                        case httpMethod.GET:
                            response = client.GetAsync(uriActionString).Result;
                            break;
                        case httpMethod.POST:

                            response = client.PostAsync(uriActionString, sc).Result;
                            break;
                        case httpMethod.PUT:
                            response = client.PutAsync(uriActionString, sc).Result;
                            break;
                        case httpMethod.DELETE:
                            response = client.DeleteAsync(uriActionString).Result;
                            break;
                        default:
                            response = client.GetAsync(uriActionString).Result;
                            break;
                    }



                    response.EnsureSuccessStatusCode();
                    returnValue = JsonConvert.DeserializeObject<T>(((HttpResponseMessage)response).Content.ReadAsStringAsync().Result);
                }
                return returnValue;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}