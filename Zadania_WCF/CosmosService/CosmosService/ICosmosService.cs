using SpaceYDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CosmosService
{
    [ServiceContract]
    public interface ICosmosService
    {

        [OperationContract]
        void InitializeGame();

        [OperationContract]
        Starship SendStarship(Starship starship, string systemName);

        [OperationContract]
        SpaceSystem GetSystem();

        [OperationContract]
        Starship GetStarship(int money);
    }
}
