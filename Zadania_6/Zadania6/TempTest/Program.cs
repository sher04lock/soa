﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MuseumContext db = new MuseumContext();
            var artists = db.Artists;
            Console.WriteLine(artists.Count());
            Console.ReadKey();
        }
    }
}
