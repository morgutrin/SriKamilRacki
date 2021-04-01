using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebCrm2.Models;

namespace WebCrm2.Controllers
{
    public class ValuesController : ApiController
    {
        
        public ValuesController()
        {                    
        }
        // GET api/values
        public HttpResponseMessage Get()
        {
          
            var ret = JsonConvert.SerializeObject(UserContainer.lista);
            return Request.CreateResponse(HttpStatusCode.OK,ret);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var ret = JsonConvert.SerializeObject(UserContainer.lista.FirstOrDefault(x=>x.Id==id));
            return Request.CreateResponse(HttpStatusCode.OK, ret);
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] string value)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<User>(value);
                UserContainer.lista.Add(user);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,"niepoprawny json");
            }
          
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] string value)
        {
            try
            {
                UserContainer.UpdateUser(id, value);                               
                    return Request.CreateResponse(HttpStatusCode.OK);                         
            }catch(Exception e)
            {
             return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
           
           
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var userToDelete = UserContainer.lista.FirstOrDefault(x => x.Id == id);
            if (userToDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            UserContainer.lista.Remove(userToDelete);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
