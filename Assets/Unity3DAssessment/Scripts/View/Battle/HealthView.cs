using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.Events;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// View that displays the health of the fighter.
    /// </summary>
    public class HealthView : TypedView<Fighter>
    {
        /// <summary>
        /// The health line instance.
        /// </summary>
        private HealthLine healthLine = null;

        /// <summary>
        /// Prefab for the healthline.
        /// </summary>
        [SerializeField]
        [Tooltip("Prefab for the healthline.")]
        private GameObject healthLinePrefab = null;

        /// <summary>
        /// The vertical offset of the healthline.
        /// </summary>
        [Tooltip("The vertical offset of the healthline.")]
        public float VerticalOffset = 0;

        public override void BindToContext(Fighter context)
        {
            if (context != null)
            {
                RectTransform canvasRect = Util.GetUICanvasRect();

                GameObject healthLineGO = Instantiate(healthLinePrefab, canvasRect);

                //position health line
                RectTransform healtLineRT = healthLineGO.transform as RectTransform;
                healtLineRT.PositionOnWorldPoint(canvasRect, transform.position);
                healtLineRT.anchoredPosition += Vector2.up * VerticalOffset;

                healthLine = healthLineGO.GetComponent<HealthLine>();

                healthLine.HealthNumber = string.Format("{0}/{1}", context.CurrentHitpoints, context.Hitpoints);

                context.OnHitpointsChanged += (origin, percent) =>
                {
                    healthLine.FillPercent = percent;
                    healthLine.HealthNumber = string.Format("{0:00}/{1:00}", Mathf.Ceil(origin.CurrentHitpoints), Mathf.Ceil(origin.Hitpoints));
                };
            }
        }
    }
}
