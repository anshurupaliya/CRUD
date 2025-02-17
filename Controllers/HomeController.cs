using CRUD.DbContext;
using CRUD.Filters.ActionFilters;
using CRUD.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rotativa;
using Rotativa.AspNetCore;
using static CRUD.Services.PersonService;

namespace CRUD.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICountryService _country;
        private readonly IPersonService _person;
        public HomeController(ICountryService country, IPersonService person)
        {
            _country = country;
            _person = person;
        }

        [Route("/")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Route("/person")]
        [TypeFilter(typeof(PersonActionFilter), Arguments=new Object[]{"name","anshu"})]
        public IActionResult Person(string searchBy,string? query,string? column,string sortBy)
        {
            //Searching
            ViewBag.SearchData=new Dictionary<string, string>()
            {
                { "Id","Id" },
                {"FirstName","First Name"},
                {"LastName","Last Name"},
                {"Email","Email"},
                {"CountryObject","Country"},
            };
            ViewBag.Data = _person.GetFilteredPerson(searchBy,query);
            //ViewBag.SearchBy=searchBy;
            //ViewBag.Query=query;
            //ViewBag.SortBy=sortBy.ToString();

            if (!string.IsNullOrEmpty(column))
            {
                ViewBag.Data=_person.GetSortedPerson(column,sortBy);
            } 
            return View();
        }

        [Route("/person/create")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Country=_country.GetAll();
            return View();
        }

        [Route("/person/create")]
        [HttpPost]
        public IActionResult Create(string FirstName,string LastName,string Email,Guid CountryId)
        {
            Person p = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                CountryId = CountryId
            };
            _person.AddPerson(p);
            return RedirectToAction("Index","Home");
        }

        [Route("/person/edit/{Id}")]
        [HttpGet]
        public IActionResult Edit([FromRoute] Guid Id)
        {
            ViewBag.Country = _country.GetAll();
            Person p = _person.GetPersons().FirstOrDefault(x => x.Id == Id);
            if (p == null)
            {
                return RedirectToAction("Person", "Home");
            }
            return View(p);
        }

        [Route("/person/edit/{Id}")]
        [HttpPost]
        public IActionResult Edit([FromRoute]Guid Id, string FirstName, string LastName, string Email,Guid CountryId)
        {
            Person p=_person.GetPersons().FirstOrDefault(x => x.Id==Id);
            if(p==null)
            {
                return RedirectToAction("Person","Home");
            }
            else
            {
                
                p.FirstName = FirstName;
                p.LastName = LastName;
                p.Email = Email;
                p.CountryId = CountryId;
                _person.UpdatePerson(p);
            }

            return RedirectToAction("Person","Home");
        }

        [Route("/person/delete/{Id}")]
        public IActionResult Delete(Guid Id)
        {
            Person p= _person.GetPersons().FirstOrDefault(y => y.Id==Id);
            if (null == p)
            {
                return RedirectToAction("Person", "Home");
            }
            else
            {
                _person.RemovePerson(p);
                return RedirectToAction("Person", "Home");
            }
        }

        [Route("/person/PersonsPdf")]
        public IActionResult PersonsPdf()
        {
            var Data=_person.GetPersons();
            return new ViewAsPdf("PersonsPdf",Data)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins(20,20,20,20),
                PageOrientation=Rotativa.AspNetCore.Options.Orientation.Portrait
            };
        }

        [Route("/country/create")]
        [HttpGet]
        public IActionResult CreateCountry()
        {
            return View();
        }


        [Route("/country/create")]
        [HttpPost]
        public IActionResult CreateCountry(string Name)
        {
            Country country = new Country()
            {
                Id=Guid.NewGuid(),
                Name=Name
            };
            _country.Add(country);
            return RedirectToAction("Index");
        }
    }
}
