using static CitizenFX.Core.Native.API;
using CitizenFX.Core;
using System;
using System.Linq;

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
namespace server
{
    public class ServerStores : BaseScript
    {
        /// <summary>
        /// All stores
        /// </summary>
        /// <typeparam name="int">the ID of the store</typeparam>
        /// <typeparam name="Store">the store</typeparam>
        /// <returns></returns>
        private readonly ConcurrentDictionary<int, Store> _allStores = new ConcurrentDictionary<int, Store>();
        /// <summary>
        /// Start of january 1970
        /// </summary>
        /// <returns></returns>
        private readonly DateTime _start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public ServerStores()
        {
            // add all stores
            _allStores.TryAdd(0, new Store() { StoreLocation = new Vector3(24.37F, -1347.26F, 29.5F) });
            _allStores.TryAdd(1, new Store() { StoreLocation = new Vector3(372.54F, 326.61F, 103.57F) });
            _allStores.TryAdd(2, new Store() { StoreLocation = new Vector3(-3242.79F, 1000.01F, 12.83F) });
            _allStores.TryAdd(3, new Store() { StoreLocation = new Vector3(-3039.14F, 584.47F, 7.91F) });
            _allStores.TryAdd(4, new Store() { StoreLocation = new Vector3(2556.68F, 380.85F, 108.62F) });
            _allStores.TryAdd(5, new Store() { StoreLocation = new Vector3(549.14F, 2671.3F, 42.16F) });
            _allStores.TryAdd(6, new Store() { StoreLocation = new Vector3(2677.73F, 3279.52F, 55.24F) });
            _allStores.TryAdd(7, new Store() { StoreLocation = new Vector3(1960.02F, 3740.08F, 32.34F) });
            _allStores.TryAdd(8, new Store() { StoreLocation = new Vector3(1727.9F, 6415.44F, 35.04F) });
            _allStores.TryAdd(9, new Store() { StoreLocation = new Vector3(-706.07F, -913.72F, 19.22F) });
            _allStores.TryAdd(10, new Store() { StoreLocation = new Vector3(-47.28F, -1758.66F, 29.42F) });
            _allStores.TryAdd(11, new Store() { StoreLocation = new Vector3(1164.74F, -322.66F, 69.21F) });
            _allStores.TryAdd(12, new Store() { StoreLocation = new Vector3(-1818.99F, 793.05F, 138.08F) });
            _allStores.TryAdd(13, new Store() { StoreLocation = new Vector3(1698.17F, 4922.77F, 42.06F) });
            _allStores.TryAdd(14, new Store() { StoreLocation = new Vector3(-1221.63F, -908.16F, 12.33F) });
            _allStores.TryAdd(15, new Store() { StoreLocation = new Vector3(-1485.98F, -378.25F, 40.16F) });
            _allStores.TryAdd(16, new Store() { StoreLocation = new Vector3(-2966.41F, 390.41F, 15.04F) });
            _allStores.TryAdd(17, new Store() { StoreLocation = new Vector3(1166.32F, 2710.57F, 38.16F) });
            _allStores.TryAdd(18, new Store() { StoreLocation = new Vector3(1134.12F, -982.1F, 46.42F) });

            // handles getting the ped
            EventHandlers["store:retreivePed"] += new Action<Player, int>(ClientRetrievePed);
            // handles removing a ped
            EventHandlers["store:removePed"] += new Action<int>(ClientRemovePed);
            // handles permission to create a ped
            EventHandlers["store:allowedToCreatePed"] += new Action<Player, List<object>, int>(ClientAllowedToCreatePed);
            // handles setting the ped network ID.
            EventHandlers["store:pedCreated"] += new Action<int, int>(ClientPedCreated);
            // handles syncing animations.
            EventHandlers["store:playPedAnim"] += new Action<List<object>, int, string, string>(ClientPlayAnimation);
            EventHandlers["store:stopPedAnim"] += new Action<List<object>, int, string, string>(ClientStopAnimation);
            // handles setting the store as cleared
            EventHandlers["store:setCleared"] += new Action<int>(ClientSetStoreCleared);
            EventHandlers["store:isCleared"] += new Action<Player, int>(ClientIsStoreCleared);
            Tick += ResetStores;
        }

        private async Task ResetStores()
        {
            // every 10 minutes.
            await Delay(600000);

            foreach (var store in _allStores.Values)
            {
                if (store.ClearedWhen == -1) continue;

                var now = CurrentTimeMillis();
                var diff = now - store.ClearedWhen;

                if (diff >= 1800000)
                {
                    Debug.WriteLine("Resetting store by ID: " + store.StoreId);
                    // its been 30 minutes, reset the store.
                    store.ClearedWhen = -1;
                    store.IsCleared = false;

                    _allStores[store.StoreId] = store;
                }

            }
        }

        /// <summary>
        /// Responds to the client with the ped network ID in that store.
        /// </summary>
        /// <param name="player">The player who triggered the event</param>
        /// <param name="storeId">The ID of the story</param>
        private void ClientRetrievePed([FromSource] Player player, int storeId)
        {
            TriggerClientEvent(player, "store:retreivePed", new object[] { _allStores[storeId].PedId });
        }

        /// <summary>
        /// Removes a ped from the store.
        /// </summary>
        /// <param name="storeId">the ID of the store</param>
        private void ClientRemovePed(int storeId)
        {
            // tell the client to remove the ped.
            TriggerClientEvent("store:removePed", new object[] { _allStores[storeId].PedId });
            _allStores[storeId].PedId = 0;
        }
        /// <summary>
        /// Responds to the client if they are allowed to create a ped or not
        /// </summary>
        /// <param name="player">Who triggered the event</param>
        /// <param name="players">The list of players around them</param>
        /// <param name="storeId">the ID of the store</param>
        private void ClientAllowedToCreatePed([FromSource] Player player, List<object> players, int storeId)
        {
            if (players.Count == 0)
            {
                // no players, we can create the ped.
                TriggerClientEvent(player, "store:allowedToCreatePed", new object[] { true });
            }
            else
            {
                var distances = new Dictionary<int, float>();
                var storeContext = _allStores[storeId];

                // add whoever triggered to the list as well
                var from = GetPlayerPed(player.Handle);
                distances.Add(int.Parse(player.Handle), storeContext.StoreLocation.DistanceToSquared2D(GetEntityCoords(from)));

                foreach (var obj in players)
                {
                    var p = Convert.ToInt32(obj);
                    var ped = GetPlayerPed(Convert.ToString(p));

                    var position = GetEntityCoords(ped);
                    var distance = storeContext.StoreLocation.DistanceToSquared2D(position);
                    distances.Add(p, distance);
                }
                // get the lowest distance.
                var minKey = distances.Aggregate((k, v) => k.Value < v.Value ? k : v).Key;
                // the player who is the closest is allowed to create the ped.
                TriggerClientEvent(Players[minKey], "store:allowedToCreatePed", new object[] { true });
                // everybody else, no.
                foreach (var key in distances.Keys)
                {
                    if (key == minKey) continue;
                    TriggerClientEvent(Players[key], "store:allowedToCreatePed", new object[] { false });
                }
            }
        }

        /// <summary>
        /// Sets the ped id of the store
        /// </summary>
        /// <param name="storeId">the ID of the store</param>
        /// <param name="ped">the ped</param>
        private void ClientPedCreated(int storeId, int ped)
        {
            _allStores[storeId].PedId = ped;
        }
        /// <summary>
        /// Plays a animation on the client
        /// </summary>
        /// <param name="players">A list of nearby players by whoever triggered it</param>
        /// <param name="ped">The ped</param>
        /// <param name="animDict">the anim dict</param>
        /// <param name="animName">the name of the animation</param>
        private void ClientPlayAnimation(List<object> players, int ped, string animDict, string animName)
        {
            foreach (var obj in players)
            {
                var player = Convert.ToInt32(obj);
                TriggerClientEvent(Players[player], "store:playPedAnim", new object[] { ped, animDict, animName });
            }
        }
        /// <summary>
        /// Stops an animation on the client
        /// </summary>
        /// <param name="players">A list of nearby players by whoever triggered it</param>
        /// <param name="ped">The ped</param>
        /// <param name="animDict">the anim dict</param>
        /// <param name="animName">the name of the animation</param>
        private void ClientStopAnimation(List<object> players, int ped, string animDict, string animName)
        {
            foreach (var obj in players)
            {
                var player = Convert.ToInt32(obj);
                TriggerClientEvent(Players[player], "store:stopPedAnim", new object[] { ped, animDict, animName });
            }
        }
        /// <summary>
        /// Sets the store as cleared.
        /// </summary>
        /// <param name="storeId">the ID of the store.</param>
        private void ClientSetStoreCleared(int storeId)
        {
            _allStores[storeId].IsCleared = true;
            _allStores[storeId].ClearedWhen = CurrentTimeMillis();
        }
        /// <summary>
        /// Reponds to the client if the store is cleared or not.
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="storeId">the ID of the store.</param>
        private void ClientIsStoreCleared([FromSource] Player player, int storeId)
        {
            TriggerClientEvent(player, "store:isCleared", new object[] { _allStores[storeId].IsCleared });
        }

        /// <summary>
        /// Current time in millis.
        /// </summary>
        /// <returns></returns>
        private long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - _start).TotalMilliseconds;
        }

    }
}