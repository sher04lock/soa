using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LiteDB;
using Models;

namespace Bank
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TreasureService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TreasureService.svc or TreasureService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TreasureService : ITreasureService
    {
        private readonly string database = @"treasure.db";
        private string[] itemNames = { "szata", "bron", "czapka" };
        public Treasure GetLoot()
        {
            using (var db = new LiteDatabase(database))
            {
                Random r = new Random();
                var treasure = new Treasure() { Gold = r.Next(0, 100), Item = itemNames[r.Next(0, 2)], Id = r.Next(4560, 9876) };
                var collection = db.GetCollection<Treasure>("tresures");
                collection.Insert(treasure);
                return treasure;
            }
        }
    }
}
