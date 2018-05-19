using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            var paintings = new List<Painting>
            {
                new Painting() {Title = "Fifty shades of C#", Year= 1990},
                new Painting() {Title = "Rodzynki", Year= 2011},
                new Painting() {Title = "Zurawina", Year= 140}
            };
            paintings.ForEach(i => context.Paintings.Add(i));
            context.SaveChanges();

            var artists = new List<Artist>()
            {
                new Artist() {ArtistName = "Jan", ArtistSurname = "Zbedny"},
                new Artist() {ArtistName = "Czeslaw", ArtistSurname = "Nowak"},
                new Artist() {ArtistName = "Jan", ArtistSurname = "Niezbedny"}
            };
            artists.ForEach(g => context.Artists.Add(g));
            context.SaveChanges();
        }
    }
}
