using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBattleBackEnd.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Hand { get; set; }
        public IClientProxy Client { get; set; }
    }
}
