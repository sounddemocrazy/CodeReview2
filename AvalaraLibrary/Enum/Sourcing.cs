using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Sourcing
    /// </summary>
    public enum Sourcing
    {
        /// <summary>
        /// Mixed sourcing, for states that do both origin and destination calculation
        /// </summary>
        Mixed,

        /// <summary>
        /// Destination
        /// </summary>
        Destination,

        /// <summary>
        /// Origin
        /// </summary>
        Origin,

    }
}
