using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GryffindorScore
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RankingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RankingService.svc or RankingService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RankingService : IRankingService
    {
        private readonly CRUDRepository repo = new CRUDRepository(@"ranking.db", "rankings");
        public List<Position> GetRanks()
        {
            return this.repo.GetAll().OrderByDescending(r => r.Gold).ToList();
        }

        public void SetPlayerRank(string name, int gold)
        {
            this.repo.Add(new Position() { Name = name, Gold = gold });
        }
    }
}
