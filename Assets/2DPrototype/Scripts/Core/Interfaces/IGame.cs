using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Interface for a game instance.
    /// </summary>
	public interface IGame 
	{
        /// <summary>
        /// The current data context of the game.
        /// </summary>
		IContext CurrentContext { get; }

        /// <summary>
        /// Assign new context to the game.
        /// This is usually followed by changing a scene.
        /// </summary>
        /// <param name="newContext">The context we want to assign to the game.</param>
		void SetContext (IContext newContext);
	}
}
