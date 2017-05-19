using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Interface for a class that calculates that damage dealt by attacker to defender.
    /// </summary>
	public interface IAttackResolver 
	{
        /// <summary>
        /// Calculate the damage dealt from the attacker to the defender.
        /// </summary>
        /// <param name="attacker">Reference to the attacker</param>
        /// <param name="defender">Reference to the defender</param>
        /// <returns></returns>
		float CalculateHit (Fighter attacker, Fighter defender);
	}
}
