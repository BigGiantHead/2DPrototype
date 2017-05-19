using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// This class represents the context when 2 fighters fight.
    /// </summary>
	[System.Serializable]
	public class BattleViewModel : Context
	{
        /// <summary>
        /// The battle factory that generates the battle.
        /// </summary>
		private IFactory<Battle> battleFactory;

        /// <summary>
        /// The battle instance for this context.
        /// </summary>
		public Battle Battle 
		{ 
			get;
			private set;
		}

		public BattleViewModel (IFactory<Battle> battleFactory, IGame game, IServiceLocator container, IBattleInitializer initializer) : base (game, container, initializer)
		{
			this.battleFactory = battleFactory;

            Battle = this.battleFactory.Create();
        }

        /// <summary>
        /// The left fighter attacks the right fighter.
        /// </summary>
		public void LeftAttack()
        {
            Battle.Left.Attack(Battle.Right);
		}

        /// <summary>
        /// The right fighter attacks the left fighter.
        /// </summary>
		public void RightAttack()
        {
            Battle.Right.Attack(Battle.Left);
		}

        /// <summary>
        /// Reset the battle.
        /// </summary>
		public void ResetBattle()
		{
			Battle.Left.Reset ();
			Battle.Right.Reset ();
		}
		public override void Initialize ()
		{
			base.Initialize ();

            //create a battle when context is initialized.
			Battle = battleFactory.Create ();
		}

        /// <summary>
        /// Load the menu context.
        /// </summary>
		public void BackToMenu()
		{
			game.SetContext(container.Resolve<IContext>("menu"));
		}
	}
}
