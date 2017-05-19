using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Interface that is used for class that are used to initialized a Context.
    /// </summary>
	public interface IInitializer
	{
        /// <summary>
        /// Initialize the context.
        /// For example load scene or instantiate something.
        /// </summary>
		void Initialize();
	}
}
