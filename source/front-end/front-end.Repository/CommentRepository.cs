using front_end.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace front_end.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public HttpClient Client { get; set; }

        public CommentRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:8080/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            var url = "/comments/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var comments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(jsonString);
            return comments;
        }

        public async Task<Comment> GetCommentById(int id)
        {
            var url = "/comment/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var comment = JsonConvert.DeserializeObject<Comment>(jsonString);
            return comment;
        }

        public async void AddComment(Comment comment)
        {
            var url = "/comments/add";
            var jsonString = JsonConvert.SerializeObject(comment);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateComment(Comment comment)
        {
            var url = "/comments/update/" + comment.comment_id;
            var jsonString = JsonConvert.SerializeObject(comment);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteComment(int id)
        {
            var url = "/comments/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
