using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// The initializer for the MenuViewModel that loads the menu scene.
    /// </summary>
	public class UIMenuInitializer : IMenuInitializer
	{
		#region IInitializer implementation
		public void Initialize ()
		{
			SceneManager.LoadScene ("menu");
		}
		#endregion
	}
}
