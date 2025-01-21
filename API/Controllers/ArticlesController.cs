using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        private readonly RestClientHelper _client;

        public ArticlesController()
        {
            _client = new RestClientHelper("https://www.c-sharpcorner.com/articles/");
        }



        // GET: api/<ArticlesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArticlesController>/5
        [HttpGet(nameof(RestSharpGetRequest))]
        public Article RestSharpGetRequest(Guid articleId)
        {

            var request = new RestRequest($"/articles/{articleId}", Method.Get);

            return _client.Execute<Article>(request);
        }


        [HttpPatch(nameof(RestSharpPatchRequest))]
        public void RestSharpPatchRequest(Article article)
        {

            var request = new RestRequest($"/articles/{article.Id}", Method.Patch);
            request.AddJsonBody(new { article.Title, article.Content });

            _client.Execute(request);
        }

        // POST api/<ArticlesController>
        [HttpPost("RestSharpPost")]
        public void Post([FromBody] Article value)
        {
            var request = new RestRequest("/article", Method.Post);

            request.AddJsonBody(value);

            _client.Execute(request);
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public void Put(Article article)
        {
            var request = new RestRequest($"/article/{article.Id}", Method.Put);

            request.AddJsonBody(article);
            _client.Execute(request);
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var request = new RestRequest($"/article/{id}", Method.Delete);

            _client.Execute(request);
        }
    }
}
