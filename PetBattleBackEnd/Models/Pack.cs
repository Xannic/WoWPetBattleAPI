using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBattleBackEnd.Models
{
    public class Pack
    {
        public Guid Id { get; set; }
        public List<Pet> Cards { get; set; }
    }
}
