
using App.Shared.Models;
using System.Collections.Immutable;
using System.Collections.Specialized;
using System.Web;

namespace App.Shared
{
    [ApiController]
    public abstract class BaseController<IN,OUT>:ControllerBase,IControllerBase
    {
        [HttpGet]
        public abstract Task<JsonResponse> Get();
        [HttpGet("{id}")]
        public abstract  Task<JsonResponse> Get(string id);
        [HttpDelete("{id}")]
        public abstract  Task<JsonResponse> Delete(string id);
        [HttpPost]
        [Consumes("application/json")]
        public abstract  Task<JsonResponse> Post(IN obj );
        [HttpPut]
        [Consumes("application/json")]
        public abstract Task<JsonResponse> Patch( IN obj);

        private KeyValuePair<string, string> GetAllQueryString()
        {
           var list = HttpUtility.ParseQueryString(Request.QueryString.Value);
            return list.Cast<string>().ToImmutableDictionary(k => k, k => (string)list[k]).FirstOrDefault();
        }
        public bool HasQueryString
        {
            get
            {
                return Request.QueryString.HasValue;
            }
        }
         
    }

    public interface IControllerBase
    {
    }
}
