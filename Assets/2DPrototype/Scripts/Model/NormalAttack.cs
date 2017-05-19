using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Calculates normal attack defined by the game designer.
    /// </summary>
	public class NormalAttack : IAttackResolver
	{
		#region IAttackResolver implementation
		public float CalculateHit (Fighter attacker, Fighter defender)
		{
			float attack = attacker.MaxHit;
			float accuracy = attacker.Accuracy;
			float defense = defender.Defence;

			float accDefDif = defense - accuracy,

			hitChance = (Random.value * 100) + 1f;

			hitChance = Mathf.Floor(hitChance);

			float breakout = Mathf.Floor((Random.value * 100) + 1f);

			// check if we actually can deal any damage to defender
			if (accDefDif < 10) 
			{
				if (breakout < 6) 
				{
					return 0;
				}
			}

			if (accDefDif >= 10 & accDefDif < 21) 
			{

				if (breakout < 36) 
				{
					return 0;
				}
			} 
			else if (accDefDif >= 20 & accDefDif < 31) 
			{
				if (breakout < 46)
				{
					return 0;
				}

			}
			else if (accDefDif >= 30 & accDefDif < 41) 
			{
				if (breakout < 61) 
				{
					return 0;
				}
			} 
			else if (accDefDif >= 40 & accDefDif < 51) 
			{
				if (breakout < 71)
				{
					return 0;
				}
			} 
			else if (accDefDif >= 50 & accDefDif < 61) 
			{
				if (breakout < 81) 
				{
					return 0;
				}
			}

			// calculate actual hit
			if (hitChance < 6) 
			{
				return attack;

			} 
			else if (hitChance > 5 & hitChance < 16) 
			{
				return attack * 0.8f;
			} 
			else if (hitChance > 15 & hitChance < 36)
			{
				return attack * Random.value;
			} 

			return attack * 0.6f;
		}
		#endregion
		
	}
}
