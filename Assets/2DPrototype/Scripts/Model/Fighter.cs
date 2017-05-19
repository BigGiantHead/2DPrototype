using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// The class that represents that Fighter data and events.
    /// </summary>
    [System.Serializable]
	public class Fighter
    {
        /// <summary>
        /// Delegate for the actions that happen when the Hitpoints change.
        /// </summary>
        /// <param name="origin">The target Fighter instance.</param>
        /// <param name="currentHitpointsPercentage">Percentage of hipoints left.</param>
        public delegate void HitpointsAction(Fighter origin, float currentHitpointsPercentage);

        /// <summary>
        /// Delegate for the actions when the fighter receives or deals damage.
        /// </summary>
        /// <param name="origin">The target Fighter instance.</param>
        /// <param name="damage">The damage dealt/received</param>
        public delegate void DamageAction(Fighter origin, float damage);

        /// <summary>
        /// The attack resolver for this fighter.
        /// </summary>
        private IAttackResolver attackResolver = null;

        /// <summary>
        /// The current hitpoints of the fighter.
        /// </summary>
        private float currentHitpoints = 0;

        /// <summary>
        /// The name of the fighter.
        /// </summary>
		public string Name
		{
			get;
			private set;
		}

        /// <summary>
        /// The maximum damage that the fighter deals.
        /// </summary>
		public float MaxHit
		{
			get;
			private set;
		}

        /// <summary>
        /// The accuracy of the fighter.
        /// </summary>
		public float Accuracy
		{
			get;
			private set;
		}

        /// <summary>
        /// The defence of the fighter.
        /// </summary>
		public float Defence
		{
			get;
			private set;
		}

        /// <summary>
        /// The hitpoints of the fighter.
        /// </summary>
		public float Hitpoints 
		{
			get;
			private set;
		}

        /// <summary>
        /// Gets the current hipoints of the fighter.
        /// </summary>
		public float CurrentHitpoints
		{
			get 
			{
				return currentHitpoints;
			}
		}

        #region Events
        /// <summary>
        /// Event when the hitpoints are reset to maximum.
        /// </summary>
        public HitpointsAction OnHitpointsReset;

        /// <summary>
        /// Event when the fighter receives damage.
        /// </summary>
        public DamageAction OnReceivedDamage;

        /// <summary>
        /// Event when the hipoints change.
        /// </summary>
        public HitpointsAction OnHitpointsChanged;

        /// <summary>
        /// Event when the fighter attacks.
        /// </summary>
        public DamageAction OnAttack;
        #endregion

        public Fighter(string name, float maxHit, float accuracy, float defence, float hitpoints, IAttackResolver attackResolver)
		{
			this.Name = name;
			this.MaxHit = maxHit;
			this.Accuracy = accuracy;
			this.Defence = defence;
			this.Hitpoints = hitpoints;
			this.currentHitpoints = hitpoints;
            this.attackResolver = attackResolver;
		}

        /// <summary>
        /// Reset the fighter instance.
        /// </summary>
		public void Reset()
		{
			currentHitpoints = Hitpoints;
            if (OnHitpointsChanged != null)
            {
                OnHitpointsChanged(this, currentHitpoints / Hitpoints);
            }

            if (OnHitpointsReset != null)
            {
                OnHitpointsReset(this, currentHitpoints / Hitpoints);
            }
        }

        /// <summary>
        /// Damage this fighter.
        /// </summary>
        /// <param name="damage">The ammount of damage received.</param>
		public void Damage(float damage)
		{
			currentHitpoints = Mathf.Max(currentHitpoints - damage, 0);

            if (OnHitpointsChanged != null)
            {
                OnHitpointsChanged(this, currentHitpoints / Hitpoints);
            }

            if (OnReceivedDamage != null)
            {
                OnReceivedDamage(this, damage);
            }
        }

        /// <summary>
        /// This fighter attacked for some ammount of damage.
        /// </summary>
        /// <param name="target">The target of the attack.</param>
        public void Attack(Fighter target)
        {
            float damage = attackResolver.CalculateHit(this, target);

            target.Damage(damage);

            //maybe lose stamina or whatever
            //in this case just invoke event
            if (OnAttack != null)
            {
                OnAttack(this, damage);
            }
        }
    }

    /// <summary>
    /// Factory that creates random fighter instances.
    /// </summary>
	public class RandomFighterFactory : IFactory<Fighter>
	{
        /// <summary>
        /// The dependency injection service locator.
        /// </summary>
        private IServiceLocator serviceLocator;

        public RandomFighterFactory(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        #region IFactory implementation
        public Fighter Create ()
		{
			return new Fighter (
                "Fighter" + Random.Range (0, 100), 
                Random.Range (10, 20), 
                Random.Range (1, 5), 
                Random.Range (1, 5), 
                Random.Range (70, 100),
                serviceLocator.Resolve<IAttackResolver>());
		}

		#endregion
	}
}
