using Microsoft.AspNetCore.Mvc;
using System; 

namespace BaltaStore.Api.Controllers{
    public class HomeController: Controller{
        [HttpGet]
        [Route("")]
        public object Get(){
            return new {version = "version 0.0.1"};
        }

      
        [HttpGet]
        [Route("error")]
        public string Error(){
            throw new Exception("Algum erro ocorreu");
            return "erro";
        }

    }
}
