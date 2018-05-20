using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Bank
{
    [ServiceContract]
    public interface ITreasureService
    {
        [OperationContract]
        Treasure GetLoot();
    }
}
