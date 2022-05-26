using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Windows;
using System.Diagnostics;
using System.Configuration;
namespace DbdSSUploader
{
    class FileWatcher
    {
        public FileWatcher()
        {
            using var watcher = new FileSystemWatcher(ConfigurationManager.AppSettings["default_location"]);
           
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

           
            watcher.Created += OnCreated;
           

            
           
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

       
        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            UploadImg(e.FullPath);
        }
        
        public static async void UploadImg(String Img) 
        {
            using (var httpClient = new HttpClient())
            {
                byte[] image = System.IO.File.ReadAllBytes(Img);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer "+ ConfigurationManager.AppSettings["api_key"]);
                MultipartFormDataContent form = new MultipartFormDataContent();
                String filename = Img.Replace(ConfigurationManager.AppSettings["default_location"], "");
                ByteArrayContent byteContent = new ByteArrayContent(image);
                form.Add(byteContent, "file", filename);
                Console.WriteLine(form.ToString());
                HttpResponseMessage response = await httpClient.PostAsync("https://api.nightlight.gg/v1/upload", form);

                response.EnsureSuccessStatusCode();

                Task<string> responseBody = response.Content.ReadAsStringAsync();
                responseBody.Wait();
                var bdy = responseBody.Result.ToString();
                dynamic data = JObject.Parse(bdy);
                String url = data.data.url;
                Console.WriteLine(response.StatusCode.ToString());
                Console.WriteLine(url);
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
                
                if (response.StatusCode.ToString() != "OK")
                {
                    //return "ERROR: " + response.StatusCode.ToString();
                }
                else
                {
                    File.Delete(Img);
                    //return "SUCCES: " + responseBody.Result.ToString();
                }
            }
        }
        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                PrintException(ex.InnerException);
            }
        }
    }
}
