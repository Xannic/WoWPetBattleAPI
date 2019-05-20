using Microsoft.AspNetCore.SignalR;
using PetBattleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBattleBackEnd
{
    public class World
    {
        public string Name { get; set; }

        public List<Pack> Packs { get; set; }
            
            //= new List<Pack>() {
            //new Pack{
            //    Id = Guid.NewGuid(),
            //    Cards = new List<string>{ "Molten Corgi", "Felpup", "Snowpup", "Cinderpup", "Aquapup", "Pizzapup", "Pupper", "Doggo" }
            //},
            //new Pack{
            //    Id = Guid.NewGuid(),
            //    Cards = new List<string>{ "Bird 1", "Bird 2", "Bird 3", "Bird 4", "Bird 5", "Bird 6", "Bird 7", "Bird 8"}
            //},
            //new Pack{
            //    Id = Guid.NewGuid(),
            //    Cards = new List<string>{ "Drake 1", "Drake 2", "Drake 3", "Drake 4", "Drake 5", "Drake 6", "Drake 7", "Drake 8"}
            //},
            //new Pack{
            //    Id = Guid.NewGuid(),
            //    Cards = new List<string>{ "Lizard 1", "Lizard 2", "Lizard 3", "Lizard 4", "Lizard 5", "Lizard 6", "Lizard 7", "Lizard 8"}
            //},
            //new Pack{
            //    Id = Guid.NewGuid(),
            //    Cards = new List<string>{ "Fish 1", "Fish 2", "Fish 3", "Fish 4", "Fish 5", "Fish 6", "Fish 7", "Fish 8"}
            //},
            //new Pack{
            //    Id = Guid.NewGuid(),
            //    Cards = new List<string>{ "Human 1", "Human 2", "Human 3", "Human 4", "Human 5", "Human 6", "Human 7", "Human 8"}
            //},
            //new Pack{
            //    Id = Guid.NewGuid(),
            //    Cards = new List<string>{ "Demon 1", "Demon 2", "Demon 3", "Demon 4", "Demon 5", "Demon 6", "Demon 7", "Demon 8"}
            //},
            //new Pack{
            //    Id = Guid.NewGuid(),
            //    Cards = new List<string>{ "Myra 1", "Myra 2", "Myra 3", "Myra 4", "Myra 5", "Myra 6", "Myra 7", "Myra 8"}
            //}
            //};
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
