using IngressoMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Data
{
    public class InicializadorDeDados
    {
        public static void Inicializar(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IngressoDbContext>();

                context.Database.EnsureCreated();

                if(!context.Cinemas.Any())
                {
                    context.Cinemas.Add
                        (new Cinema("Cinemark", "https://logospng.org/download/cinemark/logo-cinemark-1024.png", "Texto desc..."));
                    context.SaveChanges();
                }

                if(!context.Atores.Any())
                {
                    context.Atores.AddRange(new List<Ator>()
                    {
                        new Ator("Robert Downey Jr.", "Bio desc...", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/5qHNjhtjMD4YWH3UP0rm4tKwxCL.jpg"),
                        new Ator("Benedict Cumberbatch", "Bio desc...", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/fBEucxECxGLKVHBznO0qHtCGiMO.jpg"),
                        new Ator("Scarlett Johansson", "Bio desc...", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/6NsMbJXRlDZuDzatN2akFdGuTvx.jpg")
                    });
                    context.SaveChanges();
                }

                if (!context.Produtores.Any())
                {
                    context.Produtores.AddRange(new List<Produtor>()
                    {
                        new Produtor("Christopher Nolan", "Bio desc...", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/xuAIuYSmsUzKlUMBFGVZaWsY3DZ.jpg"),
                        new Produtor("Martin Scorsese", "Bio desc...", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/9U9Y5GQuWX3EZy39B8nkk4NY01S.jpg"),
                        new Produtor("Tim Burton", "Bio desc...", "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/gRM4lGpiBINAyiXaxEeJFDKzmge.jpg")
                    });
                    context.SaveChanges();
                }

                if(!context.Categorias.Any())
                {
                    context.Categorias.AddRange(new List<Categoria>()
                    {
                        new Categoria("Ação"),
                        new Categoria("Terror"),
                        new Categoria("Aventura"),
                        new Categoria("Ficção"),
                        new Categoria("Romance")
                    });
                    context.SaveChanges();
                }

                if(!context.Filmes.Any())
                {
                    context.Filmes.AddRange(new List<Filme>()
                    {
                        new Filme("Vingadores: Ultimato", "Após os eventos devastadores de 'Vingadores: Guerra Infinita', o universo está em ruínas devido aos esforços do Titã Louco, Thanos.", 12, "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/q6725aR8Zs4IwGMXzZT8aC8lh41.jpg", 1, 1),
                        new Filme("Homem de Ferro 2", "desc...", 6, "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/vzROjQbgKWMVf2EldXipCcjpuBL.jpg", 1, 1)
                    });
                    context.SaveChanges();
                }

                if (!context.FilmesCategorias.Any())
                {
                    context.FilmesCategorias.AddRange(new List<FilmeCategoria>()
                    {
                        new FilmeCategoria(1, 1),
                        new FilmeCategoria(1, 4),
                        new FilmeCategoria(1, 3),
                        new FilmeCategoria(2, 1),
                        new FilmeCategoria(2, 4)
                    });
                    context.SaveChanges();
                }

                if (!context.AtoresFilmes.Any())
                {
                    context.AtoresFilmes.AddRange(new List<AtorFilme>()
                    {
                        new AtorFilme(1, 1),
                        new AtorFilme(1, 2),
                        new AtorFilme(2, 1),
                        new AtorFilme(3, 1),
                        new AtorFilme(3, 2)
                    });
                    context.SaveChanges();
                }
            }


        }
    }
}
