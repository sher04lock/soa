using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Repositories.ForLiteDB
{
    public class ArtistRepository : CRUDRepository<Artist>
    {
        public ArtistRepository() : base(@"D:\tmp\database2.db", "artists") { }
    }
}