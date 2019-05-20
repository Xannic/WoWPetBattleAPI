using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBattleBackEnd.Models
{
    public class Pet
    {
        public string CreatureId { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public bool CanBattle { get; set; }
        public string Icon { get; set; }
        public int QualityId { get; set; }
        public Stats Stats { get; set; }
        public List<string> StrongAgainst { get; set; }
        public int TypeId { get; set; }
        public List<string> WeakAgainst { get; set; }
    }

    public class Stats {
        public string SpeciesId { get; set; }
        public int BreedId { get; set; }
        public int PetQualityId { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
    }
}