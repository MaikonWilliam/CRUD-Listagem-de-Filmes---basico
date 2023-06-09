﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFilmes.Data;
using RazorPagesFilmes.Model;

namespace RazorPagesFilmes.Pages.Films
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFilmes.Data.RazorPagesFilmesContext _context;

        public IndexModel(RazorPagesFilmes.Data.RazorPagesFilmesContext context)
        {
            _context = context;
        }

        public IList<Filme> Filme { get;set; } = default!;
        
        [BindProperty(SupportsGet = true)]
        public string TermoBusca { get; set; }
        

        [BindProperty(SupportsGet = true)]
        public string FilmeGenero { get; set; }
       

        public SelectList Generos { get; set; }

        public async Task OnGetAsync()
        {

            var filmes = from m in _context.Filme
                         select m;
            if (!string.IsNullOrEmpty(TermoBusca))
            {
                filmes = filmes.Where(f => f.Title.Contains(TermoBusca));
            }
            if (!string.IsNullOrEmpty(FilmeGenero))
            {
                filmes = filmes.Where(f => f.Genero == FilmeGenero);
            }
            Generos = new SelectList(await _context.Filme.Select(g => g.Genero).Distinct().ToListAsync());
            Filme = await filmes.ToListAsync();
        }
    }
}
