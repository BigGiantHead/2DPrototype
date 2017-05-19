using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.Events;

namespace Com.Game2D.Ptotype
{
    public class DamageView : TypedView<Fighter>
    {
        /// <summary>
        /// The prefab of the damage effect.
        /// </summary>
        [SerializeField]
        [Tooltip("The prefab of the damage effect.")]
        private GameObject effectPrefab = null;

        /// <summary>
        /// The offset radius of the damage effect.
        /// </summary>
        [Tooltip("The offset radius of the damage effect.")]
        public float EffectPositionRadius = 100;

        public override void BindToContext(Fighter context)
        {
            if (context != null)
            {
                context.OnReceivedDamage += (origin, damage) =>
                {
                    RectTransform canvasRect = Util.GetUICanvasRect();

                    GameObject effectGO = Instantiate(effectPrefab, canvasRect);

                    //position damageEffect
                    RectTransform effectRT = effectGO.transform as RectTransform;
                    effectRT.PositionOnWorldPoint(canvasRect, transform.position);
                    effectRT.anchoredPosition += Random.insideUnitCircle * EffectPositionRadius;

                    DamageEffect damageEffect = effectGO.GetComponent<DamageEffect>();
                    string format = damage > 0 ? "-{0:0}" : "{0:0}";
                    damageEffect.Text = string.Format(format, damage);
                };
            }
        }
    }
}
