﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExpress.Core
{
    /// <summary>
    /// Represents an column enum item object.
    /// </summary>
    public interface IEnumItem : IValueTextEntry
    {
        /// <summary>
        /// Get the name (key) of enum item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Get the value of enum item.
        /// </summary>
        int Value { get; }

        /// <summary>
        /// Display text
        /// </summary>
        string Text { get; set; }

    }
}
