using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [DataContract]
    public class PlayerStats
    {
        [DataMember]
        public string PlayerName { get; set; }
        [DataMember]
        public int Points { get; set; }
    }
}
