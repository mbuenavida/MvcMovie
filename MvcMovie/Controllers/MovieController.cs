using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Services.Repository;

namespace MvcMovie.Controllers
{
    public class MovieController : Controller
    {
        // Se declara variable privada que recoge el objeto MvcMovieContext
        private readonly IMovieRepository _context;
        // Contructor de la clase, al que se le inyecta el contexto
        public MovieController(IMovieRepository context)
        {
            _context = context;
        }

        // GET: Movie
        // Muestra tabla con listado de películas incluidas en la DB.
        // Filtra listado por nombre o género de la película      
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Se utiliza LINQ para conseguir la lista de Generos.
            //IQueryable<string> genreQuery = await _context.GetGenreList();

            //IQueryable<string>genreQuery = from m in _movieRepository.MovieModel
            //orderby m.Genre
            //select m.Genre;

      

            // Se generan los datos para enviar al ViewModel
            var movieGenreVM = new MovieGenreViewModel
            {
                //Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Genres = new SelectList(_context.GetGenreList()),
                Movies = await _context.GetAllFilterable(movieGenre, searchString)
            };

            return View(movieGenreVM);
        }


        // GET: Movie/Details/5
        // Muestra detalles de una Movie.
        public async Task<IActionResult> Details(int id)
        {   
            var movie = await _context.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        // GET: Movie/Create
        // Añadir nueva Movie a la DB
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MovieModel movieModel)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(movieModel);
                return RedirectToAction(nameof(Index));
            }
            return View(movieModel);
        }


        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var movieModel = await _context.GetById((int) id);

            if (movieModel == null)
            {
                return NotFound();
            }
            return View(movieModel);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MovieModel movieModel)
        {
            if (id != movieModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {          
                await _context.Update(movieModel);         
                return RedirectToAction(nameof(Index));
            }
            return View(movieModel);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var movieModel = await _context.GetById((int)id);

            if (movieModel == null)
            {
                return NotFound();
            }

            return View(movieModel);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context == null)
            {
                return Problem("Entity set 'MvcMovieContext.MovieModel'  is null.");
            }
            var movieModel = await _context.GetById(id);

            if (movieModel != null)
            {
                await _context.DeleteById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        //private bool MovieModelExists(int id)
        //{
        //  return _context.MovieModel.Any(e => e.Id == id);
        //}
    }
}
