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
using System.Windows.Forms;
namespace DbdSSUploader
{
    class FileWatcher
    {
        FileSystemWatcher watcher = new FileSystemWatcher(ConfigurationManager.AppSettings["default_location"]);
        ListBox currentSession;
        public FileWatcher(ListBox sessionLb)
        {
            currentSession = sessionLb;
            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;


            watcher.Created += OnCreated;
        }
        public void Start() 
        {
            watcher.EnableRaisingEvents = true;
        }
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }
        /// <summary>
        /// Listens for when a new image is created in the specified folder
        /// </summary>
        /// <param name="sender"> The event that triggered this</param>
        /// <param name="e">The newly created file</param>
        public void OnCreated(object sender, FileSystemEventArgs e)
        {
            
            string value = $"Created: {e.FullPath}";

            currentSession.Invoke((MethodInvoker)delegate {
                // Running on the UI thread
                currentSession.Items.Add(e.Name);
            });
            UploadImg(e.FullPath);
        }

        /// <summary>
        /// Convert the image file into bytes and send it to the nightlight api
        /// </summary>
        /// <param name="Img"></param>
        public async void UploadImg(String Img) 
        {
            try
            {
                //Create http client
                using var httpClient = new HttpClient();
                //Open the image and convert it into bytes
                byte[] image = System.IO.File.ReadAllBytes(Img);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + ConfigurationManager.AppSettings["api_key"]);
                MultipartFormDataContent form = new MultipartFormDataContent();
                string filename = Img.Replace(ConfigurationManager.AppSettings["default_location"], "");
                ByteArrayContent byteContent = new ByteArrayContent(image);
                form.Add(byteContent, "file", filename);
                
                HttpResponseMessage response = await httpClient.PostAsync("https://api.nightlight.gg/v1/upload", form);

                response.EnsureSuccessStatusCode();

                Task<string> responseBody = response.Content.ReadAsStringAsync();
                responseBody.Wait();
                var bdy = responseBody.Result.ToString();
                dynamic data = JObject.Parse(bdy);
                string url = data.data.url;

               
                //open the URL
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
            catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
