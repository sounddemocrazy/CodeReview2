using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Types of jurisdiction referenced in a transaction
    /// </summary>
    public enum JurisTypeId
    {
        /// <summary>
        /// State
        /// </summary>
        STA,

        /// <summary>
        /// County
        /// </summary>
        CTY,

        /// <summary>
        /// City
        /// </summary>
        CIT,

        /// <summary>
        /// Special
        /// </summary>
        STJ,

        /// <summary>
        /// Country
        /// </summary>
        CNT,

    }
}
