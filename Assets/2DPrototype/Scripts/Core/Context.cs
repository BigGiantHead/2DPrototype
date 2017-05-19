using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
	public abstract class Context : IContext
	{
        /// <summary>
        /// Initializer for the data context.
        /// When we change the context the scene is loaded usually.
        /// </summary>
		private IInitializer initializer;

        /// <summary>
        /// Service locator for dependency injection.
        /// </summary>
		protected IServiceLocator container;

        /// <summary>
        /// The game instance that is playing.
        /// </summary>
		protected IGame game;

		public Context(IGame game, IServiceLocator container, IInitializer initializer)
		{
			this.game = game;
			this.container = container;
			this.initializer = initializer;
		}

		public virtual void Initialize()
		{
			initializer.Initialize ();
		}
	}
}
