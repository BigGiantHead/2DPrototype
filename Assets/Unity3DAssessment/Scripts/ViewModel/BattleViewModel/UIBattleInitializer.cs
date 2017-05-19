using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// The initializer for the BattleViewModel in Unity.
    /// Loads the battle scene.
    /// </summary>
	public class UIBattleInitializer : IBattleInitializer
	{
		#region IInitializer implementation
		public void Initialize ()
		{
			SceneManager.LoadScene ("battle"); 
		}
		#endregion
	}
}
