using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Class that handles data and events for a battle between 2 fighters.
    /// </summary>
	[System.Serializable]
	public class Battle
	{
        /// <summary>
        /// Delegate for events that happen during the battle. For example ending of the battle.
        /// </summary>
        /// <param name="target">The target of this action.</param>
        public delegate void BattleAction(Fighter target);

        /// <summary>
        /// The left fighter. The name is just for reference.
        /// </summary>
		public Fighter Left { get; private set; }

        /// <summary>
        /// The right fighter. The name is just for reference.
        /// </summary>
		public Fighter Right { get; private set; }

        /// <summary>
        /// Event that happens when the battle is finished. The victor is send as a parameter.
        /// </summary>
        public BattleAction OnBattleFinished;

		public Battle(Fighter left, Fighter right)
		{
            this.Left = left;
            this.Right = right;

            left.OnHitpointsChanged += OnHitpointsChanged;
            right.OnHitpointsChanged += OnHitpointsChanged;
        }

        /// <summary>
        /// When the hitpoints of one of the fighters are changed, check if he died.
        /// </summary>
        /// <param name="origin">The origin fighter instance.</param>
        /// <param name="hitpointsPercent">How much hitpoints are left in percent.</param>
        private void OnHitpointsChanged(Fighter origin, float hitpointsPercent)
        {
            if (hitpointsPercent <= 0)
            {
                //if one fighter died the battle is finished.
                if (OnBattleFinished != null)
                {
                    OnBattleFinished(origin == Left ? Left : Right);
                }
            }
        }
    }

    /// <summary>
    /// Factory that creates battles between 2 fighters using a spacified Fighter factory.
    /// </summary>
	public class BattleFactory : IFactory<Battle>
	{
		private IFactory<Fighter> fighterFactory;

		public BattleFactory(IFactory<Fighter> factory)
		{
			this.fighterFactory = factory;
		}

		#region IFactory implementation
		public Battle Create ()
		{
			return new Battle (fighterFactory.Create (), fighterFactory.Create ());
		}
		#endregion
	}
}
