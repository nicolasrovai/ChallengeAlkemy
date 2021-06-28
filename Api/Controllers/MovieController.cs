using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs.MovieDTOs;
using Api.Entities;
using Api.Repositories.MovieRepo;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("movie")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepo _movieRepo;
        private readonly IMapper _movieMapper;

        public MovieController(IMovieRepo movieRepo, IMapper movieMapper)
        {
            _movieRepo = movieRepo;
            _movieMapper = movieMapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieReadDto>> Movies()
        {
            var movies = _movieRepo.GetMovie();
            return Ok(_movieMapper.Map<IEnumerable<MovieReadDto>>(movies));
        }

        [HttpGet("{id}", Name = "MovieById")]
        public ActionResult<Movie> MovieById(int id)
        {
            var movie = _movieRepo.GetMovieById(id);
            if (movie != null)
            {
                return Ok(_movieMapper.Map<MovieReadDto>(movie));
            }
            return NotFound();

        }

        [HttpPost]
        public ActionResult<MovieReadDto> MovieCreate(MovieCreateDto movieCreateDto)
        {
            var movie = _movieMapper.Map<Movie>(movieCreateDto);
            _movieRepo.CreateMovie(movie);
            _movieRepo.SaveChanges();

            var movieReadDto = _movieMapper.Map<MovieReadDto>(movie);

            return CreatedAtRoute(nameof(MovieById), new { Id = movie.Id }, movieReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult MovieUpdate(int id, MovieUpdateDto movieUpdateDto)
        {
            var movie = _movieRepo.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            _movieMapper.Map(movieUpdateDto, movie);

            _movieRepo.UpdateMovie(movie);

            _movieRepo.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult MoviePartialUpdate(int id, JsonPatchDocument<MovieUpdateDto> pactchDoc)
        {
            var movie = _movieRepo.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            var movieToPatch = _movieMapper.Map<MovieUpdateDto>(movie);
            pactchDoc.ApplyTo(movieToPatch, ModelState);
            if (!TryValidateModel(movieToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _movieMapper.Map(movieToPatch, movie);

            _movieRepo.UpdateMovie(movie);

            _movieRepo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult MovieDelete(int id)
        {
            var movie = _movieRepo.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }

            _movieRepo.DeleteMovie(movie);
            _movieRepo.SaveChanges();
            return NoContent();
        }
    }
}

