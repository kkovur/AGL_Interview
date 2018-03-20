using AglInterviewTest.Models;
using Glass.Mapper.Sc.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AglInterviewTest.Controllers
{
    public class PersonInfoController : GlassController
    {
        // GET: PersonInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMaleOwnerCats()
        {
            var context = SitecoreContext.GetCurrentItem<IPageInfo>();

            RESTClient client = new RESTClient(context.ApiUrl.Url);
            List<Person> Persons = client.GetWSObject<List<Person>>("people.json");

            IEnumerable<IPetsResult> results = new PetsResultModel().GetPets("Male", "Cat", Persons);
            return View(results);
        }

        public ActionResult GetFemaleOwnerCats()
        {
            var context = SitecoreContext.GetCurrentItem<IPageInfo>();

            RESTClient client = new RESTClient(context.ApiUrl.Url);
            List<Person> Persons = client.GetWSObject<List<Person>>("people.json");

            IEnumerable<IPetsResult> results = new PetsResultModel(context.ApiUrl.Url).GetPets("Female", "Cat",Persons);
            return View(results);
        }
    }
}