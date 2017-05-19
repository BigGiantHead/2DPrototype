using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Represents an instance of the game.
    /// </summary>
	public class Game : IGame
	{
        /// <summary>
        /// The current context of the game.
        /// </summary>
		private IContext currentContext = null;

		#region IGame implementation
		public IContext CurrentContext
		{
			get
			{
				return currentContext;
			}
		}

		public void SetContext (IContext newContext)
		{
			currentContext = newContext;
			currentContext.Initialize ();
		}
		#endregion
	}
}
