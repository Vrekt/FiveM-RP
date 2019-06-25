using CitizenFX.Core;

namespace server
{
    public class Store
    {
        /// <summary>
        /// The ID of this store.
        /// </summary>
        /// <value></value>
        public int StoreId { get; set; }
        /// <summary>
        /// The ped network ID for this store.
        /// </summary>
        /// <value></value>
        public int PedId { get; set; }
        /// <summary>
        /// The location of this store, (where the ped should spawn.)
        /// </summary>
        /// <value></value>
        public Vector3 StoreLocation { get; set; }

        /// <summary>
        /// If this store has been cleared.
        /// </summary>
        /// <value></value>
        public bool IsCleared { get; set; }

        /// <summary>
        /// When this store was cleared.
        /// </summary>
        /// <value></value>
        public long ClearedWhen { get; set; } = -1;

    }
}