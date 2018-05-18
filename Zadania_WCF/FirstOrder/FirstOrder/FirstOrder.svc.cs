using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FirstOrder
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class FirstOrder : IFirstOrder
    {
        public int GetMoneyFromImperium()
        {
            Random r = new Random();
            return r.Next(3 * 1000, 5 * 1000);
        }
    }
}
