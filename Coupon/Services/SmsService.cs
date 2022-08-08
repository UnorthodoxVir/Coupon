using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Twilio;

namespace Coupon.Services
{
    public class SmsService
    {
        public async Task sendMsg(string name, string code, string phone, string center)
        {

            var body = @$"عملينا العزيز {name}
الرمز الخاص عند مركز {center} هو {code}
سارع باستعمال الكوبون قبل استعماله من شخص اخر";
            var baseAddress = new Uri("https://www.msegat.com");

            Dictionary<string, string> values = new();

            values.Add("userName", "omarharbi");
            values.Add("numbers", phone);
            values.Add("userSender", "Kafahh");
            values.Add("apiKey", "8e01b62fbeba876213250677cc7cbb05");
            values.Add("msg", body);


            using var httpClient = new HttpClient { BaseAddress = baseAddress };
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(values), UnicodeEncoding.UTF8, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("/gw/sendsms.php", content))
                    {
                        string responseHeaders = response.Headers.ToString();
                        string responseData = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("Status " + (int)response.StatusCode);
                        Console.WriteLine("Headers " + responseHeaders);
                        Console.WriteLine("Data " + responseData);
                    }
                }
            }


        }

        public async Task AuthenticatePhone(string code, string phone)
        {
s            var body = $@"رمز التحقق الخاص بك هو {code}
لاتشارك هذا الرمز مع احد";

            var baseAddress = new Uri("https://www.msegat.com");


            Dictionary<string, string> values = new();


            values.Add("userName", "omarharbi");
            values.Add("numbers", phone);
            values.Add("userSender", "Kafahh");
            values.Add("apiKey", "8e01b62fbeba876213250677cc7cbb05");
            values.Add("msg", body);

            using var httpClient = new HttpClient { BaseAddress = baseAddress };
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(values), UnicodeEncoding.UTF8, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("/gw/sendsms.php", content))
                    {
                        string responseHeaders = response.Headers.ToString();
                        string responseData = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("Status " + (int)response.StatusCode);
                        Console.WriteLine("Headers " + responseHeaders);
                        Console.WriteLine("Data " + responseData);
                    }
                }
            }



        }

    }
}