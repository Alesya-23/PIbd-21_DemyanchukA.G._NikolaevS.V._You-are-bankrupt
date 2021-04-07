using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class Crediting
    {
        [DataMember]
        public int? Id { get; set; }
    }
}
