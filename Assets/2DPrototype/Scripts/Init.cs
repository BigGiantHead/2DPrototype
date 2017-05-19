using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Bootstrapper for the IoCContainer in Unity.
    /// Entry point for the game.
    /// </summary>
	public class Init : AbstractBootstrapper 
	{
		#region implemented abstract members of AbstractBootstrapper
		public override void Configure (IIoCContainer container)
		{
			DontDestroyOnLoad (this.gameObject);

			Game game = new Game ();

			container.RegisterSingleton<IGame> (game);
			container.Register<IContext, MenuViewModel> ("menu");
			container.Register<IContext, BattleViewModel> ("battle");
			container.RegisterSingleton<IFactory<Battle>, BattleFactory> ();
			container.RegisterSingleton<IFactory<Fighter>, RandomFighterFactory> ();
			container.RegisterSingleton<IBattleInitializer, UIBattleInitializer> ();
			container.RegisterSingleton<IMenuInitializer, UIMenuInitializer> ();
			container.RegisterSingleton<IAttackResolver, NormalAttack> ();

			IServiceLocator locator = container as IServiceLocator;
			game.SetContext(locator.Resolve<IContext>("menu"));
		}
		#endregion
	}
}
