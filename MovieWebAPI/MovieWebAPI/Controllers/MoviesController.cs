using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Repository.Interfaces;
using Service;

namespace MovieWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _mRepoService;
        //private readonly IMovieRepository _mRepo;

        public MoviesController(IMovieService mRepo)
        {
            _mRepoService = mRepo;
        }

        [HttpGet]
        public IEnumerable<Movie> Get(String title)
        {
            return _mRepoService.GetAllMovies(title);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _mRepoService.GetById(id);
            if (movie != null)
            {
                return _mRepoService.GetById(id);
            }
            else return NotFound();

        }

        /////////////////////////////////////////////////////////////////////A VOIR COMMENT FAIRE ?
        /*
        public IEnumerable<Movie> Get([System.Web.Http.FromUri] string str)
        {
            var movie = _mRepo.GetByStringInName(str);
            if (movie != null)
            {
                return movie;
            }
            else return null;
        }
        */
        ///////////////////////////////////////////////////////////////////////////

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            var res = _mRepoService.Add(movie);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest("Erreur : ajout d'un film dans la bdd");
        }

        [HttpPut("{id}")]
        public Movie Update(int id, Movie movie)
        {
            return _mRepoService.Update(id, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = _mRepoService.Delete(id);
            if (res)
            {
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }
    }
}