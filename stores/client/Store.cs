using static CitizenFX.Core.Native.API;
using CitizenFX.Core;
using System;

namespace client
{
    public sealed class Store
    {
        /// <summary>
        /// The ID of the store.
        /// </summary>
        /// <value></value>
        public int StoreId { get; set; }
        /// <summary>
        /// The ID of the ped in the store.sealed (network)
        /// </summary>
        /// <value></value>
        public int PedId { get; set; }
        /// <summary>
        /// The location of where the ped should be.
        /// </summary>
        /// <value></value>
        public Vector3 PedLocation { get; set; }
        /// <summary>
        /// The location of the safe.
        /// </summary>
        /// <value></value>
        public Vector3 SafeLocation { get; set; }
        /// <summary>
        /// The heading of the ped.
        /// </summary>
        /// <value></value>
        public float PedHeading { get; set; }
        /// <summary>
        /// True if the store is being robbed.
        /// </summary>
        /// <value></value>
        public bool IsRobbing { get; set; }
        /// <summary>
        /// True if the store is cleared, (cannot be robbed.)
        /// </summary>
        /// <value></value>
        public bool IsCleared { get; set; }
        /// <summary>
        /// How much money was given out.
        /// </summary>
        /// <value></value>
        public int MoneyGiven { get; set; }
        /// <summary>
        /// The keyboard input to the safe.
        /// </summary>
        /// <value></value>
        public string SafeInput { get; set; }
        /// <summary>
        /// The code of the safe.
        /// </summary>
        /// <value></value>
        public string SafeCode { get; set; }
    }

}