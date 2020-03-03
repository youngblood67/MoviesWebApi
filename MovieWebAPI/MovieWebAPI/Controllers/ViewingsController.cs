using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interfaces;

namespace MovieWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewingsController : Controller
    {
        private readonly IViewingRepository _vRepo;

        public ViewingsController(IViewingRepository vRepo)
        {
            _vRepo = vRepo;
        }

        [HttpGet]
        public IEnumerable<Viewing> Get()
        {
            return _vRepo.GetAllViewing();
        }

        [HttpGet("{id}")]
        public ActionResult<Viewing> Get(int id)
        {
            var viewing = _vRepo.GetById(id);
            if (viewing != null)
            {
                return _vRepo.GetById(id);
            }
            else return NotFound();

        }

        [HttpPost]
        public IActionResult Create(Viewing viewing)
        {
            var res = _vRepo.Add(viewing);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("Erreur : ajout d'une visualisation dans la bdd");
        }

        [HttpPut("{id}")]
        public Viewing Update(int id, Viewing viewing)
        {
            return _vRepo.Update(id, viewing);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var viewing = _vRepo.GetById(id);
            return _vRepo.Delete(id);
        }

    }


}