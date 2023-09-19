using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using BookShop.Application.Products;
using BookShop.Domain.Enums;
using System;

namespace BookShop.UI.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        [BindProperty]
       public GetProducts.IndexViewModel PageInfo { get; set; }
        [BindProperty]
        public string Genre { get; set; }
        [BindProperty]
        public string Search { get; set; }

        public IActionResult OnGet(string genre, [FromServices] GetProducts getProducts, int p = 1)
        {
            if (genre==null) {
                Genre = null;
                PageInfo = getProducts.GetAll(p);
            }
            else
            {
                Genre = genre;
                PageInfo = getProducts.GetByGenre(p, genre);
            }

            return Page();
        }
        public void OnGetForAll([FromServices] GetProducts getProducts, int p = 1)
        {
            PageInfo = getProducts.GetAll(p);
        }
        public void OnGetForGenre(string genre, [FromServices] GetProducts getProducts, int p = 1)
        {
            Genre = genre;
            PageInfo = getProducts.GetByGenre(p,genre);
        }

        public IActionResult OnPost(string search,[FromServices] GetProducts getProducts, int p = 1)
        {
            
            if (search != null) { 
            PageInfo = getProducts.GetBySearch(p, search);
            }
            else
            {
                PageInfo = getProducts.GetAll(p);
            }
            return Page();
        }

    }
}
