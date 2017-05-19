using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// The context of the menu.
    /// </summary>
	public class MenuViewModel : Context
	{
		public MenuViewModel (IGame game, IServiceLocator container, IMenuInitializer initializer) : base (game, container, initializer)
		{
		}

        /// <summary>
        /// Go to the battle. Load the battle context.
        /// </summary>
		public void GoToBattle()
		{
			game.SetContext (container.Resolve<IContext>("battle"));
		}
	}
}
