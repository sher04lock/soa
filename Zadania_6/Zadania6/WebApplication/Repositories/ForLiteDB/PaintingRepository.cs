using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Repositories.ForLiteDB
{
    public class PaintingRepository : CRUDRepository<Painting>, IPaintingRepository
    {
        public PaintingRepository() : base(@"D:\tmp\database2.db", "paintings") { }
    }
}