﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressLocator
{
    /// <summary>
    /// Utility for formatting address strings
    /// </summary>
    interface IAddressFormatter
    {
        /// <summary>
        /// Given an unformatted address string, recreate it in a format
        /// that's suitable for further manipulation.
        /// </summary>
        /// <param name="address">The original raw address string.</param>
        /// <returns>A formatted address ready for further processing.</returns>
        string Format(string address);

        /// <summary>
        /// Remove the first part of a given address, effectively making
        /// it less specific.
        /// </summary>
        /// <param name="address">A formatted address string.</param>
        /// <returns>A less-specific address string with the first part
        /// removed.</returns>
        /// <remarks>Some address lookup services may have trouble finding
        /// an address. By making the address less specific (e.g. removing
        /// the house number, the street name, etc), it has a better chance
        /// of finding something, albeit with less accuracy.</remarks>
        string RemoveStart(string address);
    }
}
