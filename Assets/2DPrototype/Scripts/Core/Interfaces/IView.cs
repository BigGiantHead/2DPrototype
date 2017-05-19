using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Interface for a view that binds to some context.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Bind to some context data.
        /// </summary>
        /// <param name="context">Context that we bind to.</param>
        void BindToContext(object context);
    }
}
