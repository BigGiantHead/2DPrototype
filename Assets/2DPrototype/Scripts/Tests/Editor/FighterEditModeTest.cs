using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace Com.Game2D.Ptotype.Tests
{
    public class FighterEditModeTest
    {
        [Test]
        public void ConstructorTest()
        {
            string name = "Petko";
            float maxHit = 10;
            float accuracy = 150;
            float defence = 200;
            float hitpoints = 20;

            Fighter fighter = new Fighter(name, maxHit, accuracy, defence, hitpoints, null);

            Assert.AreEqual(name, fighter.Name);
            Assert.AreEqual(maxHit, fighter.MaxHit);
            Assert.AreEqual(accuracy, fighter.Accuracy);
            Assert.AreEqual(defence, fighter.Defence);
            Assert.AreEqual(hitpoints, fighter.Hitpoints);
            Assert.AreEqual(hitpoints, fighter.CurrentHitpoints);
        }
        
        [Test]
        public void DamageTest()
        {
            string name = "Petko";
            float maxHit = 10;
            float accuracy = 150;
            float defence = 200;
            float hitpoints = 150;

            Fighter fighter = new Fighter(name, maxHit, accuracy, defence, hitpoints, null);

            float damageToDo = 5;

            fighter.Damage(damageToDo);
            float difference = fighter.Hitpoints - fighter.CurrentHitpoints;
            Debug.Log(difference);

            Assert.IsTrue(difference == damageToDo);
        }

        [Test]
        public void AttackTest()
        {
            FlatAttack attackResolver = new FlatAttack();

            string name = "Petko";
            float maxHit = 10;
            float accuracy = 150;
            float defence = 200;
            float hitpoints = 150;

            Fighter fighter1 = new Fighter(name, maxHit, accuracy, defence, hitpoints, attackResolver);

            name = "Sestko";

            Fighter fighter2 = new Fighter(name, maxHit, accuracy, defence, hitpoints, attackResolver);

            fighter1.Attack(fighter2);

            Assert.Greater(fighter2.Hitpoints, fighter2.CurrentHitpoints);

            fighter2.Attack(fighter1);

            Assert.Greater(fighter1.Hitpoints, fighter1.CurrentHitpoints);
        }
    }
}
