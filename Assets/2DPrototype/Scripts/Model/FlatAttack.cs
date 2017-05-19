using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Calculates random damage based on the attack.MaxHit.
    /// Use for testing purposes.
    /// </summary>
    public class FlatAttack : IAttackResolver
    {
        public float CalculateHit(Fighter attacker, Fighter defender)
        {
            return attacker.MaxHit * (Random.value + 0.7f + 0.3f);
        }
    }
}