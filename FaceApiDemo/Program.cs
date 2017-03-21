using System;
using System.Net.Http;
using System.Text;
using System.Web;

namespace FaceApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeRequest();
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }

        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "1ffaca29031f4a36b9ec00e063e12d9d");//face api key

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            queryString["returnFaceAttributes"] = "age";
            var uri = "https://api.cognitive.azure.cn/face/v1.0/detect?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"url\":\"http://imgsrc.baidu.com/baike/pic/item/4034970a304e251ff1e3819aa486c9177f3e53bf.jpg\"}");//the url of picture

            using (var content = new ByteArrayContent(byteData))
            {
                response = await client.PostAsync(uri, content);
            }

            //response result
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("response:" + result);
        }
    }
}
