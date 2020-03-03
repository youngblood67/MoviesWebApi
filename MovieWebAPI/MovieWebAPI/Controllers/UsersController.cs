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
    public class UsersController : Controller
    {
        private readonly IUserRepository _uRepo;

        public UsersController(IUserRepository uRepo)
        {
            _uRepo = uRepo;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _uRepo.GetAllUsers();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _uRepo.GetById(id);
            if (user != null)
            {
                return _uRepo.GetById(id);
            }
            else return NotFound();

        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var res = _uRepo.Add(user);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("Erreur : ajout d'un utilisateur dans la bdd");
        }

        [HttpPut("{id}")]
        public User Update(int id, User user)
        {
            return _uRepo.Update(id, user);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var user = _uRepo.GetById(id);
            return _uRepo.Delete(id);
        }

    }
}