using PetBattleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBattleBackEnd
{
    public static class Singleton
    {
        public static string AccessToken { get; set; }

        public static Dictionary<Guid, World> Worlds { get; set; } = new Dictionary<Guid, World>();

        public static World GetWorldById(Guid worldId)
        {
            return Worlds[worldId];
        }

        public static Guid CreateWorld(string name, List<Pack> packs)
        {
            var id = Guid.NewGuid();
            Worlds.Add(id, new World { Name = name, Packs = packs });
            return id;
        }

        public static List<Pet> Pets { get; set; }
    }
}
