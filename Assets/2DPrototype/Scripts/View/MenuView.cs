using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// A typed view that is bound to the MenuViewModel.
    /// </summary>
    public class MenuView : TypedView<MenuViewModel>
    {
        /// <summary>
        /// That that starts the battle.
        /// </summary>
        [SerializeField]
        private Button playButton;

        public override void BindToContext(MenuViewModel context)
        {
            if (context != null)
            {
                //when the playButton is clicked load the battle context.
                playButton.onClick.AddListener(() =>
                {
                    context.GoToBattle();
                });
            }
        }
    }
}
