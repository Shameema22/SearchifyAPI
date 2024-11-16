using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchifyAPI.Data;
using SearchifyAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SearchifyAPI.Controllers
{
    [Route("Searchify")]
    [ApiController]
    public class SearchResultsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SearchResultsController(AppDbContext context)
        {
            _context = context;
        }        

        // POST: api/SearchResults
        [Route("GetSearchResults")]
        [HttpPost]
        public async Task<ActionResult<SearchResult>> GetSearchResult(SearchRequest request)
        {
            Console.WriteLine("Controller");

            string query = request.Query;

            if (request == null || string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Search query cannot be empty.");
            }

            var results = _context.SearchResults.AsQueryable();


            if (!string.IsNullOrWhiteSpace(request.Query))
            {
                results = results.Where(r =>
                    (r.Title != null && EF.Functions.Like(r.Title, $"%{query}%")) ||
                    (r.Description != null && EF.Functions.Like(r.Description, $"%{query}%")) ||
                    (r.SearchKeys != null && EF.Functions.Like(r.SearchKeys, $"%{query}%")));
            }

            var search_results = await results.ToListAsync();

            Console.WriteLine("Result");

            return Ok(new
            {
                Results = results.Select(r => new
                {
                    r.Id,
                    r.Title,
                    r.Description,
                    r.SearchKeys,
                    r.ImageUrl
                }),
                TotalRecords = results.Count()
            });

        }

    }
}
