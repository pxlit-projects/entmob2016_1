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
    public class CommentRepository
    {
        public HttpClient Client { get; set; }

        public CommentRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            var url = "/comments/all";
            HttpResponseMessage response = await Client.GetAsync(url);
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
            HttpResponseMessage response = await Client.GetAsync(url);
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
            var content = new StringContent(jsonString);
            await Client.PostAsync(url, content);
        }

        public async void UpdateComment(Comment comment)
        {
            var url = "/comments/update/" + comment.Comment_id;
            var jsonString = JsonConvert.SerializeObject(comment);
            var content = new StringContent(jsonString);
            await Client.PutAsync(url, content);
        }

        public async void DeleteComment(int id)
        {
            var url = "/comments/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}
