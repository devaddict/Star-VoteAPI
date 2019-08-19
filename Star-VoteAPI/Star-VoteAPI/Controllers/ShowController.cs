using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Star_VoteAPI.Models;
using Utilities;

namespace Star_VoteAPI.Controllers
{
    [Route("api/{userToken}/[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowMyOrigin")]
    public class ShowController : ControllerBase
    {
        private IDataRepository<ShowModel> _showRepo;
        public ShowController(IDataRepository<ShowModel> showRepo)
        {
            _showRepo = showRepo;
        }
        public ActionResult<dynamic> GetShowsFake(string userToken, int pageNumb=1, int numOfRect=5)
        {
            var retObj = new List<ExpandoObject>();
            dynamic oneRec = new ExpandoObject();
            oneRec.Id = 1;
            oneRec.Name = "Game of Thrones";
            oneRec.Image = "https://i.ytimg.com/sh/ow8-ZftRoZelY710tvO45Q/market.jpg";
            oneRec.Desc = "Some description";
            retObj.Add(oneRec);
            dynamic oneRec2 = new ExpandoObject();
            oneRec2.Id = 2;
            oneRec2.Name = "Ray Donova";
            oneRec2.Image = "https://m.media-amazon.com/images/M/MV5BNWMwMjUyYmMtODYyOS00YjYwLWE0NjQtMGJiYzVmOGVjOGQ0XkEyXkFqcGdeQXVyOTA3MTMyOTk@._V1_.jpg";
            oneRec2.Desc = "Some description fro ray";
            retObj.Add(oneRec2);
            dynamic oneRec3 = new ExpandoObject();
           oneRec3.Id = 3;
           oneRec3.Name = "Game of Thrones2";
           oneRec3.Image = "https://i.ytimg.com/sh/ow8-ZftRoZelY710tvO45Q/market.jpg";
            oneRec3.Desc = "Some description";
            retObj.Add(oneRec3);

            var json = new CustomJson<dynamic>(retObj, JsonSTatus.Load);

            return json;

        }
        public ActionResult<dynamic> GetShows(string userToken, int pageNumb = 1, int numOfRect = 5)
        {
            //TODO page numbering to be implemented
            var retObj = new List<ExpandoObject>();

            dynamic oneRec; ;

            var showList = _showRepo.GetAll();
            foreach (var item in showList)
            {
                oneRec = new ExpandoObject();
                oneRec.Id = item.Id;
                oneRec.Name = item.Name;
                oneRec.Image = item.ImagePath;
                oneRec.Desc = item.Discription;
                retObj.Add(oneRec);
            }
            var json = new CustomJson<dynamic>(retObj, JsonSTatus.Load);

            return json;

        }
    }
}