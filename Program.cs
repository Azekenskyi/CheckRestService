using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CheckRestService
{
    class Program
    {
        static PersonInfo p1 = new PersonInfo(961226300060, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p2 = new PersonInfo(961226300040, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p3 = new PersonInfo(961226300033, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p4 = new PersonInfo(961226300026, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p5 = new PersonInfo(961226300087, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p6 = new PersonInfo(961226300069, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p7 = new PersonInfo(961226300046, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p8 = new PersonInfo(961226300017, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p9 = new PersonInfo(961226300, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static PersonInfo p10 = new PersonInfo(9612263000, "Amaniyazov", "Azamat", "Amangeldiuli", Convert.ToDateTime("26.12.1996"));
        static void Main(string[] args)
        {

            CheckRequest("Astana Almaty Atyrau Arkalik Pavlodar"); 
            CheckRequestData(); 
            PostDataPerson(loadPeople()); 
            Console.ReadKey();
        }
        public static PersonInfo[] loadPeople()
        {
            PersonInfo[] peopleInfo = new PersonInfo[10] ;
            peopleInfo[0] = p1;
            peopleInfo[1] = p2;
            peopleInfo[2] = p3;
            peopleInfo[3] = p4;
            peopleInfo[4] = p5;
            peopleInfo[5] = p6;
            peopleInfo[6] = p7;
            peopleInfo[7] = p8;
            peopleInfo[8] = p9;
            peopleInfo[9] = p10;
            
            return peopleInfo;
        } 
        public static async void CheckRequest(string text)
        {
            WebRequest request = WebRequest.Create("https://localhost:44350/Api/Request/Get?text="+text);
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd() + "\r\n");
                }
            }
            response.Close();
        }
        public static async void CheckRequestData()
        {
            WebRequest request = WebRequest.Create("https://localhost:44350/Api/Request/");
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadLine();
                    List<string> value = JsonSerializer.Deserialize<List<string>>(result);
                   foreach(var c in value)
                    {
                        Console.WriteLine(c);
                    }
                    Console.WriteLine("\r\n");
                    
                }
            }
            response.Close();
        }
        public static async void PostDataPerson(PersonInfo [] personInfo)
        {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44350");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.ExpectContinue = false;

                    MediaTypeFormatter jsonFormatter = new JsonMediaTypeFormatter();
                    foreach (PersonInfo c in personInfo)
                        {
                            HttpResponseMessage response = await client.PostAsync("api/Request/POST/", c, jsonFormatter);
                            HttpContent responseContent;
                            responseContent = response.Content;
                            string value = await responseContent.ReadAsStringAsync();
                            Console.WriteLine(value);
                        }
                        
                }
        }
    }
}
