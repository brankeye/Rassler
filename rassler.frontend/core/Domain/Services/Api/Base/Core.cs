using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace rassler.frontend.core.Domain.Services.Api.Base
{
    public abstract class Core<TModel>
        where TModel : class
    {
        protected readonly string BaseUri;
        protected readonly string TargetApi;

        protected Core(string baseUri, string targetApi)
        {
            BaseUri = baseUri;
            TargetApi = targetApi;
        }

        public virtual async Task<HttpResponseMessage> GetAsync(object id, string token = null)
        {
            var restUrl = BaseUri + "{0}";
            var target = TargetApi + "/" + id;
            var uri = new Uri(string.Format(restUrl, target));
            HttpResponseMessage response = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    response = await httpClient.GetAsync(uri);
                    return response;
                }
                catch (WebException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return response;
        }

        public virtual async Task<HttpResponseMessage> GetAsync(string token = null)
        {
            var restUrl = BaseUri + "{0}";
            var uri = new Uri(string.Format(restUrl, TargetApi));
            HttpResponseMessage response = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try
                {
                    response = await httpClient.GetAsync(uri);
                    return response;
                }
                catch (WebException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return response;
        }

        public virtual async Task<HttpResponseMessage> PostAsync(TModel model, string token = null, string targetSection = "")
        {
            var restUrl = BaseUri + "{0}";
            var target = TargetApi;
            if (string.IsNullOrEmpty(targetSection) == false)
            {
                target += "/" + targetSection;
            }
            var uri = new Uri(string.Format(restUrl, target));

            var json = "";
            if (model != null)
            {
                json = JsonConvert.SerializeObject(model);
            }
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (token != null)
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                response = await httpClient.PostAsync(uri, content);
            }
            return response;
        }

        public virtual async Task<HttpResponseMessage> DeleteAsync(object id)
        {
            var restUrl = BaseUri + "{0}/{1}";
            var target = TargetApi + "/" + id;
            var uri = new Uri(string.Format(restUrl, target));

            HttpResponseMessage response = null;
            using (var httpClient = new HttpClient())
            {
                response = await httpClient.DeleteAsync(uri);
            }
            return response ?? new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
        }

        public virtual async Task<T> ParseResponseContent<T>(HttpResponseMessage httpResponse)
        {
            var resultString = await httpResponse.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<T>(resultString);
            return responseObject;
        }
    }
}
