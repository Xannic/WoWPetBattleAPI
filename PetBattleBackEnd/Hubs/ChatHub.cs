using Microsoft.AspNetCore.SignalR;
using PetBattleBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetBattleBackEnd.Hubs
{
    public class ChatHub : Hub
    {
        public async Task CreateWorld(string name, List<Pack> packs) {
            foreach (var pack in packs) {
                pack.Id = Guid.NewGuid();
            }
            var worldId = Singleton.CreateWorld(name, packs);
            await Clients.Caller.SendAsync("ReceiveWorld", worldId);
        }

        public async Task GetPets() {
            await Clients.Caller.SendAsync("ReceivePets", Singleton.Pets);
        }

        public async Task Join(Guid worldId, string name)
        {
            var world = Singleton.GetWorldById(worldId);
            var guid = Guid.NewGuid();
            var player = new Player { Id = guid, Name = name, Hand = new List<Pet>(), Client = Clients.Caller };
            world.Players.Add(player);

            await Clients.Caller.SendAsync("ReceiveUserId", player.Id);
            await SendToAllPlayersOfWorld("ReceivePlayers", world, world.Players);

            if (world.Players.Count == world.Packs.Count) {
                await DealPacks(worldId);
            }
        }

        public async Task ConnectToPlayer(Guid worldId, Guid playerId)
        {
            var world = Singleton.GetWorldById(worldId);
            var player = world.Players.FirstOrDefault(x => x.Id == playerId);
            player.Client = Clients.Caller;

            await SendToAllPlayersOfWorld("ReceivePlayers", world, world.Players);
        }

        public async Task PickCard(Guid worldId, Guid playerId, Guid packId, Pet card)
        {
            var world = Singleton.GetWorldById(worldId);
            var currentPlayer = world.Players.FirstOrDefault(x => x.Id == playerId);
            currentPlayer.Hand.Add(card);
            var pack = world.Packs.FirstOrDefault(x => x.Id == packId);
            var pickedCard = pack.Cards.SingleOrDefault(x => x.CreatureId == card.CreatureId);
            pack.Cards.Remove(pickedCard);

            if (world.Players.Where(x => x.Hand.Count != currentPlayer.Hand.Count).Count() == 0) {
                for (var i = 0; i < world.Players.Count; i++)
                {
                    var player = world.Players[i];
                    var index = (i + player.Hand.Count) % world.Players.Count;
                    player.Client.SendAsync("ReceivePack", world.Packs[index]);
                }
            }

            await SendToAllPlayersOfWorld("ReceivePlayers", world);
        }


        public async Task SetPacks(Guid worldId, List<Pack> packs)
        {
            var world = Singleton.GetWorldById(worldId);
            world.Packs = packs;
        }

        public async Task DealPacks(Guid worldId)
        {
            var world = Singleton.GetWorldById(worldId);
            if (world.Players.Count != world.Packs.Count) return;

            world.Players.Shuffle();
            for (var i = 0; i < world.Players.Count; i++) {
                var player = world.Players[i];
                player.Client.SendAsync("ReceivePack", world.Packs[i]);
            }
        }

        public async Task SendToAllPlayersOfWorld(string command, World world, Object content = null) {
            for (var i = 0; i < world.Players.Count; i++)
            {
                var player = world.Players[i];
                var index = (i + player.Hand.Count) % world.Players.Count;
                player.Client.SendAsync(command, content);
            }
        }
    }
}
