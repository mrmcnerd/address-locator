﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AddressLocator.AddressFormatters
{
    public class Generic : BaseFormatter
    {
        /// <summary>
        /// A generic address formatter:
        /// {0}: address.Address1,
        /// {1}: address.Address2,
        /// {2}: address.City,
        /// {3}: address.Region,
        /// {4}: address.Postcode,
        /// {5}: address.Country
        /// </summary>
        protected override string formatString { get => "{0},{1},{2},{3},{4},{5}"; }
    }
}
