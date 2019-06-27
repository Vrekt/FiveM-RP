using static CitizenFX.Core.Native.API;
using CitizenFX.Core.UI;
using CitizenFX.Core;
using System;

using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace client
{

    public class ClientStores : BaseScript
    {
        /// <summary>
        /// Contains all stores
        /// </summary>
        /// <typeparam name="int">The ID of the store.</typeparam>
        /// <typeparam name="Store">The store.</typeparam>
        /// <returns>None</returns>
        private readonly ConcurrentDictionary<int, Store> _allStores = new ConcurrentDictionary<int, Store>();
        /// <summary>
        /// The start epoch
        /// </summary>
        /// <returns></returns>
        private readonly DateTime _start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        /// <summary>
        /// The random instance used for chances
        /// </summary>
        /// <returns>None</returns>
        private readonly Random _random = new Random();
        /// <summary>
        /// The store we are in.
        /// </summary>
        private Store _storeIn;
        /// <summary>
        /// True if the input is active
        /// </summary>
        private bool _inputActive;

        public ClientStores()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            // add all stores.
            _allStores.TryAdd(0, new Store() { StoreId = 0, PedLocation = new Vector3(24.37F, -1347.26F, 29.5F), SafeLocation = new Vector3(28.29F, -1339.23F, 29.0F), PedHeading = 267.61F });
            _allStores.TryAdd(1, new Store() { StoreId = 1, PedLocation = new Vector3(372.54F, 326.61F, 103.57F), SafeLocation = new Vector3(378.22F, 333.35F, 103.57F), PedHeading = 257.87F });
            _allStores.TryAdd(2, new Store() { StoreId = 2, PedLocation = new Vector3(-3242.79F, 1000.01F, 12.83F), SafeLocation = new Vector3(-3250.0F, 1004.0F, 12.83F), PedHeading = 354.22F });
            _allStores.TryAdd(3, new Store() { StoreId = 3, PedLocation = new Vector3(-3039.14F, 584.47F, 7.91F), SafeLocation = new Vector3(-3047.85F, 585.61F, 7.91F), PedHeading = 19.42F });
            _allStores.TryAdd(4, new Store() { StoreId = 4, PedLocation = new Vector3(2556.68F, 380.85F, 108.62F), SafeLocation = new Vector3(2549.27F, 384.81F, 108.62F), PedHeading = 355.52F });
            _allStores.TryAdd(5, new Store() { StoreId = 5, PedLocation = new Vector3(549.14F, 2671.3F, 42.16F), SafeLocation = new Vector3(546.35F, 2662.8F, 42.16F), PedHeading = 94.05F });
            _allStores.TryAdd(6, new Store() { StoreId = 6, PedLocation = new Vector3(2677.73F, 3279.52F, 55.24F), SafeLocation = new Vector3(2672.76F, 3286.62F, 55.24F), PedHeading = 329.32F });
            _allStores.TryAdd(7, new Store() { StoreId = 7, PedLocation = new Vector3(1960.02F, 3740.08F, 32.34F), SafeLocation = new Vector3(1959.3F, 3748.91F, 32.34F), PedHeading = 296.96F });
            _allStores.TryAdd(8, new Store() { StoreId = 8, PedLocation = new Vector3(1727.9F, 6415.44F, 35.04F), SafeLocation = new Vector3(1734.81F, 6420.83F, 35.04F), PedHeading = 240.27F });
            _allStores.TryAdd(9, new Store() { StoreId = 9, PedLocation = new Vector3(-706.07F, -913.72F, 19.22F), SafeLocation = new Vector3(-709.71F, -904.28F, 19.22F), PedHeading = 86.75F });
            _allStores.TryAdd(10, new Store() { StoreId = 10, PedLocation = new Vector3(-47.28F, -1758.66F, 29.42F), SafeLocation = new Vector3(-43.36F, -1748.36F, 29.42F), PedHeading = 49.16F });
            _allStores.TryAdd(11, new Store() { StoreId = 11, PedLocation = new Vector3(1164.74F, -322.66F, 69.21F), SafeLocation = new Vector3(1159.56F, -314.06F, 69.21F), PedHeading = 97.45F });
            _allStores.TryAdd(12, new Store() { StoreId = 12, PedLocation = new Vector3(-1818.99F, 793.05F, 138.08F), SafeLocation = new Vector3(-1829.24F, 798.84F, 138.19F), PedHeading = 130.89F });
            _allStores.TryAdd(13, new Store() { StoreId = 13, PedLocation = new Vector3(1698.17F, 4922.77F, 42.06F), SafeLocation = new Vector3(1707.95F, 4920.33F, 42.06F), PedHeading = 322.69F });
            _allStores.TryAdd(14, new Store() { StoreId = 14, PedLocation = new Vector3(-1221.63F, -908.16F, 12.33F), SafeLocation = new Vector3(-1220.87F, -915.87F, 11.33F), PedHeading = 33.97F });
            _allStores.TryAdd(15, new Store() { StoreId = 15, PedLocation = new Vector3(-1485.98F, -378.25F, 40.16F), SafeLocation = new Vector3(-1479.07F, -375.51F, 39.16F), PedHeading = 131.4F });
            _allStores.TryAdd(16, new Store() { StoreId = 16, PedLocation = new Vector3(-2966.41F, 390.41F, 15.04F), SafeLocation = new Vector3(-2959.55F, 387.05F, 14.04F), PedHeading = 85.67F });
            _allStores.TryAdd(17, new Store() { StoreId = 17, PedLocation = new Vector3(1166.32F, 2710.57F, 38.16F), SafeLocation = new Vector3(1169.24F, 2717.65F, 37.16F), PedHeading = 177.47F });
            _allStores.TryAdd(18, new Store() { StoreId = 18, PedLocation = new Vector3(1134.12F, -982.1F, 46.42F), SafeLocation = new Vector3(1126.63F, -980.18F, 45.42F), PedHeading = 277.62F });

            foreach (var store in _allStores)
            {
                var blip = World.CreateBlip(store.Value.PedLocation);
                blip.Sprite = BlipSprite.Store;
                blip.Name = "Convenience Store";
                blip.Color = BlipColor.Green;
            }

            // handles deleting a ped.
            EventHandlers["store:removePed"] += new Action<int>(NetworkRemovePed);
            // handles syncing animations
            EventHandlers["store:playPedAnim"] += new Action<int, string, string>(NetworkPlayAnimation);
            EventHandlers["store:stopPedAnim"] += new Action<int, string, string>(NetworkStopAnimation);
            Tick += OnTick;
        }

        private async Task OnTick()
        {
            await Delay(2000);
            var position = Game.PlayerPed.Position;

            if (_storeIn != null)
            {
                // we are in a store, check if we are still in that store.
                var distanceTo = Vdist2(position.X, position.Y, 0.0F, _storeIn.PedLocation.X, _storeIn.PedLocation.Y, 0.0F);
                if (distanceTo > 250)
                {
                    // set we are not robbing anymore.
                    _storeIn.IsRobbing = false;

                    // we are not near this store anymore.
                    _storeIn = null;
                }
                else
                {
                    // check the ped status
                    // if we killed the entity, respawn it.
                    var entity = NetToPed(_storeIn.PedId);
                    if (IsEntityDead(entity) && GetPedKiller(entity) == Game.PlayerPed.Handle)
                    {
                        // tell the server to remove the ped.
                        TriggerServerEvent("store:removePed", new object[] { _storeIn.StoreId });
                        CreateNetworkedPed(_storeIn, false); // we do not need permission since we are the killer.
                        return;
                    }

                    // check if we are aiming at the ped.
                    var entityAimingAt = 0;
                    var aimingAt = GetEntityPlayerIsFreeAimingAt(PlayerId(), ref entityAimingAt);
                    var ped = NetToPed(_storeIn.PedId);

                    // if we are aiming at the clerk and we are not already robbing + we have a gun.
                    if (aimingAt
                    && entityAimingAt == ped
                    && _storeIn.IsRobbing == false
                    && Game.PlayerPed.Weapons.Current.DisplayName != "WT_INVALID")
                    {
                        if (IsEntityDead(ped)) return; // dead entity, return

                        // wait for server response about the cleared status.
                        await ServerResponse("store:isCleared", new object[] { _storeIn.StoreId }, new Action<bool>((result) =>
                        {
                            _storeIn.IsCleared = result;
                        }));

                        // if cleared return, also check the safe code, if its empty then continue.
                        // we check if its empty because it won't be while we are opening the safe 
                        // and we don't want to spam notifications.
                        if (_storeIn.IsCleared && _storeIn.SafeCode == "")
                        {
                            Screen.ShowNotification("The clerk yells \"There's no more money here, I'm sorry!\"");
                            return;
                        }

                        // load the mugging dict.
                        RequestAnimDict("random@mugging3");
                        while (!HasAnimDictLoaded("random@mugging3"))
                        {
                            await Delay(10);
                        }

                        // if we are not playing either animation, then play it
                        if (!IsEntityPlayingAnim(entityAimingAt, "random@mugging3", "handsup_standing_base", 3)
                        && !IsEntityPlayingAnim(entityAimingAt, "gestures@f@standing@casual", "gesture_nod_yes_hard", 3))
                        {
                            TaskPlayAnim(entityAimingAt, "random@mugging3", "handsup_standing_base", 8.0F, -8F, -1, 49, 0, false, false, false);

                            // now, sync ped animation to all nearby players
                            TriggerServerEvent("store:playPedAnim", new object[] { GetNearbyPlayers(), _storeIn.PedId, "random@mugging3", "handsup_standing_base" });
                        }

                        // set we are robbing
                        _storeIn.IsRobbing = true;
                        Tick += RobberyTick; // assign the tick that handles the robbery,
                    }
                    // handle we are not robbing anymore.
                    else if (_storeIn.IsRobbing && !aimingAt || entityAimingAt != ped)
                    {
                        // set we are not robbing anymore.
                        _storeIn.IsRobbing = false;
                        // stop animation
                        StopAnimTask(ped, "random@mugging3", "handsup_standing_base", 3);
                        // update clients
                        TriggerServerEvent("store:stopPedAnim", new object[] { GetNearbyPlayers(), _storeIn.PedId, "random@mugging3", "handsup_standing_base" });

                        Tick -= RobberyTick;
                    }
                }
            }
            else
            {
                // we are not in a store, continue scanning.
                // loop through all stores and calculate the distance to the store.
                foreach (var store in _allStores.Values)
                {
                    // get the distance
                    var distanceTo = Vdist2(position.X, position.Y, 0.0F, store.PedLocation.X, store.PedLocation.Y, 0.0F);
                    if (distanceTo <= 200)
                    {
                        _storeIn = store;
                        // we are pretty close.
                        if (store.PedId == 0)
                        {
                            // ask the server for the ped.
                            await ServerResponse("store:retreivePed", new object[] { store.StoreId }, new Action<int>((ped) =>
                            {
                                if (ped == 0)
                                {
                                    // ped hasn't been created yet.
                                    CreateNetworkedPed(store, true); // we do need permission
                                }
                                else
                                {
                                    var entity = NetToPed(ped); // retrieve the net entity
                                    if (!DoesEntityExist(entity))
                                    {
                                        // tell the server to remove the ped.
                                        TriggerServerEvent("store:removePed", new object[] { store.StoreId });
                                        CreateNetworkedPed(store, true); // we do need permission
                                    }
                                }
                            }));
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Handles the ped being robbed.
        /// </summary>
        /// <returns>None</returns>
        private async Task RobberyTick()
        {
            var randomDelay = _random.Next(10000, 20000);
            // it will take awhile to get some money
            await Delay(randomDelay);

            // if we are not robbing anymore, return;
            if (_storeIn == null || _storeIn.IsRobbing == false) return;
            var entity = NetToPed(_storeIn.PedId); // retrieve the net entity

            // play a sort of "handing over/yes" animation.
            RequestAnimDict("gestures@f@standing@casual");
            while (!HasAnimDictLoaded("gestures@f@standing@casual"))
            {
                await Delay(50);
            }

            // play the animation
            TriggerServerEvent("store:playPedAnim", new object[] { GetNearbyPlayers(), _storeIn.PedId, "gestures@f@standing@casual", "gesture_nod_yes_hard" });
            TaskPlayAnim(entity, "gestures@f@standing@casual", "gesture_nod_yes_hard", 8.0F, -8F, -1, 49, 0, false, false, false);

            // wait 1 second then play hands up animation again
            await Delay(1000);
            TaskPlayAnim(entity, "random@mugging3", "handsup_standing_base", 8.0F, -8F, -1, 49, 0, false, false, false);
            TriggerServerEvent("store:playPedAnim", new object[] { GetNearbyPlayers(), _storeIn.PedId, "random@mugging3", "handsup_standing_base" });

            // give the player a random amount of cash
            var cash = _random.Next(100, 650);
            SetPlayerCashChange(cash, 0);
            _storeIn.MoneyGiven += cash;

            var randomMax = _random.Next(1000, 2300); // random max amount to get unlucky
            if (_storeIn.MoneyGiven >= randomMax)
            {
                // set the store is cleared server
                _storeIn.IsCleared = true;
                TriggerServerEvent("store:setCleared", new object[] { _storeIn.StoreId });

                // random chance to retrieve a safe code.
                var chance = _random.Next(1, 100);
                if (chance >= 85)
                {
                    // assign a random safe code.
                    var code = _random.Next(2345, 8713);
                    _storeIn.SafeCode = Convert.ToString(code);

                    Screen.ShowNotification("The clerk yells \"There is no money in the registers but the safe code is " + code + "\"");

                    Tick += SafeTick;
                }

                // set we are not robbing anymore.
                _storeIn.IsRobbing = false;
                Tick -= RobberyTick; // remove this tick
            }
        }

        /// <summary>
        /// Handles the safe part of the robbery
        /// </summary>
        /// <returns>None</returns>
        private async Task SafeTick()
        {
            if (_inputActive)
            {
                // input is active, hide hud.
                HideHudAndRadarThisFrame();
                var result = UpdateOnscreenKeyboard();
                if (result == 3)
                {
                    _inputActive = false;
                }
                else if (result == 2)
                {
                    _inputActive = false;
                }
                else if (result == 1)
                {
                    // get the text
                    var text = GetOnscreenKeyboardResult();
                    if (text.Length > 0)
                    {
                        if (text.Length == 4)
                        {
                            // see if we entered the correct code.
                            var correct = text == _storeIn.SafeCode;
                            if (correct)
                            {
                                // we entered the correct code.
                                Screen.ShowNotification("Safe opened!");
                                // give random amount of cash.  
                                var cash = _random.Next(1500, 3000);
                                SetPlayerCashChange(cash, 0);
                            }
                            else
                            {
                                Screen.ShowNotification("The safe reads 'ERR', it looks like the safe is now hard-locked and will require a key.");
                            }

                            // update.
                            _inputActive = false;
                            _storeIn.SafeInput = "";
                            _storeIn.SafeCode = "";
                            Tick -= SafeTick;
                        }
                        Renderer.RenderText(text, _storeIn.SafeLocation, 0.36F);
                    }
                    else
                    {
                        // display keyboard
                        DisplayOnscreenKeyboard(0, "FMMC_KEY_TIP8", "", "", "", "", "", 4);
                    }
                }
            }
            else
            {
                // input is not active yet.
                // input is not active yet.
                var position = Game.PlayerPed.Position;
                var safeLocation = _storeIn.SafeLocation;

                if (Vdist2(position.X, position.Y, 0.0F, safeLocation.X, safeLocation.Y, 0.0F) >= 280.0F)
                {
                    // we are too far away.
                    Screen.ShowNotification("The safe was reset remotely and cannot be open anymore");

                    // update
                    _inputActive = false;
                    _storeIn.SafeInput = "";
                    _storeIn.SafeCode = "";
                    Tick -= SafeTick; // remove tick
                }

                // render
                Renderer.RenderText("~g~E~w~ To open the safe", _storeIn.SafeLocation, 0.3F);
            }

            // check for E key input.
            if (IsControlJustReleased(1, 38) && !_inputActive)
            {
                // check how close we are.
                var position = Game.PlayerPed.Position;
                var safeLocation = _storeIn.SafeLocation;

                if (Vdist2(position.X, position.Y, position.Z, safeLocation.X, safeLocation.Y, safeLocation.Z) >= 5.0F) return; // too far away.

                // E key just pressed, display keyboard.
                DisplayOnscreenKeyboard(0, "FMMC_KEY_TIP8", "", "", "", "", "", 4);
                _inputActive = true;
            }
        }

        /// <summary>
        /// Waits for a server response.
        /// </summary>
        /// <param name="eventName">The name of the event to trigger</param>
        /// <param name="arguments">the arguments to pass in</param>
        /// <param name="action">the response action</param>
        /// <typeparam name="T">the type</typeparam>
        /// <returns>Task</returns>
        private async Task ServerResponse<T>(string eventName, object[] arguments, Action<T> action)
        {
            // the invoke action
            Action<T> invokeAction = null;

            // the response action.
            Action<T> receiveAction = source =>
            {
                // this action receives the event, and then invokes the action
                // which will remove the event handler and invoke the passed in action.
                invokeAction(source);
            };

            invokeAction = source =>
            {
                // remove event and invoke passed in action
                EventHandlers[eventName] -= receiveAction;
                action(source);
            };

            // assign the event handler
            EventHandlers[eventName] += receiveAction;
            TriggerServerEvent(eventName, arguments); // trigger the server event.
            return;
        }

        /// <summary>
        /// Deletes the entity ped
        /// </summary>
        /// <param name="ped">the ped</param>
        private void NetworkRemovePed(int ped)
        {
            var entity = NetToPed(ped);
            if (DoesEntityExist(entity))
            {
                DeleteEntity(ref entity);
            }
        }

        /// <summary>
        /// Plays an animation on the ped
        /// </summary>
        /// <param name="ped">the ped network ID.</param>
        /// <param name="animDict">the anim dict</param>
        /// <param name="animName">the anim name</param>
        /// <returns></returns>
        private async void NetworkPlayAnimation(int ped, string animDict, string animName)
        {
            // load the animation
            RequestAnimDict(animDict);
            while (!HasAnimDictLoaded(animDict))
            {
                await Delay(10);
            }

            var entity = NetToPed(ped);
            if (DoesEntityExist(entity))
            {
                TaskPlayAnim(entity, animDict, animName, 8.0F, -8F, -1, 49, 0, false, false, false);
            }
        }
        /// <summary>
        /// Stops an animation on the ped
        /// </summary>
        /// <param name="ped">the ped network ID.</param>
        /// <param name="animDict">the anim dict</param>
        /// <param name="animName">the anim name</param>
        /// <returns></returns>
        private async void NetworkStopAnimation(int ped, string animDict, string animName)
        {
            // load the animation
            RequestAnimDict(animDict);
            while (!HasAnimDictLoaded(animDict))
            {
                await Delay(10);
            }

            var entity = NetToPed(ped);
            if (DoesEntityExist(entity))
            {
                StopAnimTask(entity, animDict, animName, 3);
            }
        }

        /// <summary>
        /// Creates a networked ped.
        /// /// </summary>
        /// <param name="store">The store</param>
        /// <param name="askPermission">True if permission should be asked before creating.</param>
        private async void CreateNetworkedPed(Store store, bool askPermission)
        {
            // first ask permission.
            await ServerResponse("store:allowedToCreatePed", new object[] { GetNearbyPlayers(), store.StoreId }, new Action<bool>(async (hasPermission) =>
            {
                if (!askPermission || hasPermission)
                {
                    // if we have permission create the ped
                    var ped = await World.CreatePed(new Model(PedHash.ShopKeep01), store.PedLocation, store.PedHeading);
                    // make the ped basically ignore everything.
                    SetBlockingOfNonTemporaryEvents(ped.Handle, true);
                    SetPedFleeAttributes(ped.Handle, 0, false);
                    SetPedCombatAttributes(ped.Handle, 17, true);

                    // network the entity
                    var networkId = PedToNet(ped.Handle);
                    NetworkRegisterEntityAsNetworked(networkId);
                    SetNetworkIdExistsOnAllMachines(networkId, true);
                    NetworkSetNetworkIdDynamic(networkId, false);

                    _allStores[store.StoreId].PedId = networkId; // update
                    store.PedId = networkId; // update
                    TriggerServerEvent("store:pedCreated", new object[] { store.StoreId, networkId }); // tell the server the ped was created
                }
            }));
        }

        /// <summary>
        /// Get nearby players by a distance of 200
        /// </summary>
        /// <returns></returns>
        private List<int> GetNearbyPlayers()
        {
            var position = Game.PlayerPed.Position;
            var players = new List<int>();
            var self = GetPlayerPed(-1);

            for (int i = 1; i < 32; i++)
            {
                // loop through all IDs.
                var player = GetPlayerPed(GetPlayerFromServerId(i));
                if (player == self) continue; // ignore ourselves.

                var coords = GetEntityCoords(player, false);
                var distance = Vdist2(coords.X, coords.Y, 0.0F, position.X, position.Y, 0.0F);
                if (distance <= 200)
                {
                    // we are close, add them to the list.
                    players.Add(i);
                }

            }
            return players;
        }
        /// <summary>
        /// The current time in milliseconds
        /// </summary>
        /// <returns>Current time in milliseconds</returns>
        private long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - _start).TotalMilliseconds;
        }

    }

}
