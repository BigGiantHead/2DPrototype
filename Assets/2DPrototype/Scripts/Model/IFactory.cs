using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Interface for factory for creating instances of type T.
    /// </summary>
    /// <typeparam name="T">The type of the instance created.</typeparam>
	public interface IFactory<T>
	{
        /// <summary>
        /// Create an instance of type T.
        /// </summary>
        /// <returns>The created instance.</returns>
		T Create ();
	}
}
