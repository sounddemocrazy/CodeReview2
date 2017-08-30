using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Jurisdiction boundary precision level found for address. This depends on the accuracy of the address
    ///  as well as the precision level of the state provided jurisdiction boundaries.
    /// </summary>
    public enum BoundaryLevel
    {
        /// <summary>
        /// Street address precision
        /// </summary>
        Address,

        /// <summary>
        /// 9-digit zip precision
        /// </summary>
        Zip9,

        /// <summary>
        /// 5-digit zip precision
        /// </summary>
        Zip5,

    }
}
