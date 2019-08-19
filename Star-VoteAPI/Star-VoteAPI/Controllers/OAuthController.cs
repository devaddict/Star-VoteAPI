using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Star_VoteAPI.Models;
using Utilities;

namespace Star_VoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private IDataRepository<ShowModel> _showRepo;
        public OAuthController(IDataRepository<ShowModel> showRepo)
        {
            _showRepo = showRepo;
        }
        public ActionResult<dynamic> Login(string userToken, string accessObj)
        {
            var retObj = new List<ExpandoObject>();
            return new CustomJson<dynamic>(retObj, JsonSTatus.Save);
        }

    }
    public class GoogleUserObject
    {
        public string email { get; set; }
        public string familyName { get; set; }
        public string givenName { get; set; }
        public string googleId { get; set; }
        public string ImageUrl { get; set; }
        public string name { get; set; }
    }
    public class GoogleAccessObject
    {
        public GoogleUserObject userbject { get; set; }
        public string id_token { get; set; }
    }
}