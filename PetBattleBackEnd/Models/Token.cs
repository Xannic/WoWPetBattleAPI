using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBattleBackEnd.Models
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_typ { get; set; }
        public int expires_in { get; set; }
    }
}
