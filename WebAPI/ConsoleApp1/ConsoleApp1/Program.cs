using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            //Program program = new Program();
            //await program.GetTodoList();

            const string url = "https://jsonplaceholder.typicode.com/";

            //"https://jsonplaceholder.typicode.com/posts/1";
            //"https://jsonplaceholder.typicode.com/";
            //"https://jsonplaceholder.typicode.com/todos";
            //https://jsonplaceholder.typicode.com/comments?postId=1
            //https://jsonplaceholder.typicode.com/posts/1

            string urlParameters = $"posts/1"; //$"comments?postId=1";
            var response = APICall.RunAsync<Post>(url, urlParameters).GetAwaiter().GetResult();
           

            //return response;
        }

        private async Task GetTodoList()
        {
            string response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            //Console.WriteLine(response);

            List<Todo> todo = JsonConvert.DeserializeObject<List<Todo>>(response);
            foreach(var item in todo)
            {
                Console.WriteLine(item.title);
            }
        }
    }

    class Todo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

    }

    class Post
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public string email { get; set; }

        public string body { get; set; }
    }
}
