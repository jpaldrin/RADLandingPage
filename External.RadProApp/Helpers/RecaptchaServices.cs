﻿namespace External.RadProApp.Helpers
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;


    public class RecaptchaServices
    {
        //ActionFilterAttribute has no async for MVC 5 therefore not using as an actionfilter attribute - needs revisiting in MVC 6
        internal static async Task<bool> Validate(HttpRequestBase request)
        {
            string recaptchaResponse = request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(recaptchaResponse))
            {
                return false;
            }
            using (var client = new HttpClient { BaseAddress = new Uri("https://www.google.com") })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("secret", ConfigurationManager.AppSettings["RecaptchaSecretKey"]),
                    new KeyValuePair<string, string>("response", recaptchaResponse),
                    new KeyValuePair<string, string>("remoteip", request.UserHostAddress)
                });
                var result = await client.PostAsync("/recaptcha/api/siteverify", content);
                result.EnsureSuccessStatusCode();
                string jsonString = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<RecaptchaResponse>(jsonString);
                return response.Success;
            }
        }

        [DataContract]
        internal class RecaptchaResponse
        {
            [DataMember(Name = "success")]
            public bool Success { get; set; }
            [DataMember(Name = "challenge_ts")]
            public DateTime ChallengeTimeStamp { get; set; }
            [DataMember(Name = "hostname")]
            public string Hostname { get; set; }
            [DataMember(Name = "error-codes")]
            public IEnumerable<string> ErrorCodes { get; set; }
        }
    }
}
 

