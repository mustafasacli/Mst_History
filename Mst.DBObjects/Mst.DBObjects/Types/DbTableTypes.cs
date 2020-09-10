
namespace Mst.DBObjects.Types
{
    public enum DbTableTypes : byte
    {
        /// <summary>
        /// Table used for Record data.
        /// </summary>
        DataTable = 1,

        /// <summary>
        /// Table used for any Record types.
        /// </summary>
        LookupTable = 2,

        /// <summary>
        /// Table used for Many-To-Many, Many-To-One,
        /// One-To-One,One-To-Many relations between two or more table.
        /// </summary>
        CrossTable = 3

    };
}
