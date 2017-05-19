using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.Events;

namespace Com.Game2D.Ptotype
{
    public class FighterView : TypedView<Fighter>
    {
        private Coroutine doWatchAnimation = null;

        private UnityArmatureComponent fighterArmature = null;

        [SerializeField]
        private string armatureName = null;

        [SerializeField]
        private HealthView healthView = null;

        [SerializeField]
        private DamageView damageView = null;

        public override void BindToContext(Fighter context)
        {
            if (context != null)
            {
                // Create armature.
                fighterArmature = UnityFactory.factory.BuildArmatureComponent(armatureName); // Input armature name
                fighterArmature.transform.SetParent(transform, false);

#if UNITY_EDITOR
                foreach(string name in fighterArmature.animation.animationNames)
                {
                    Debug.Log(name);
                }
#endif

                PlayAnimation("Idle");

                // Change armature position.
                fighterArmature.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

                context.OnHitpointsReset += (origin, percent) =>
                {
                    PlayAnimation("Idle");
                };

                context.OnReceivedDamage += (origin, percent) =>
                {
                    if (origin.CurrentHitpoints <= 0)
                    {
                        PlayAnimation("Dead", 1);
                    }
                    else
                    {
                        PlayAnimation("Damage", 1, () =>
                        {
                            PlayAnimation("Idle");
                        });
                    }
                };

                context.OnAttack += (origin, damage) =>
                {
                    PlayAnimation("Attack", 1, () => {
                        PlayAnimation("Idle");
                    });
                };

                healthView.BindToContext(context);
                damageView.BindToContext(context);
            }
        }

        private void PlayAnimation(string name, int repeat = -1, UnityAction onComplete = null)
        {
            if (doWatchAnimation != null)
            {
                StopCoroutine(doWatchAnimation);
                doWatchAnimation = null;
            }

            fighterArmature.animation.Play(name, repeat);

            if (onComplete != null)
            {
                doWatchAnimation = StartCoroutine(DoWatchAnimation(fighterArmature.animation, onComplete));
            }
        }

        private IEnumerator DoWatchAnimation(DragonBones.Animation animation, UnityAction onComplete)
        {
            while (!animation.isCompleted)
            {
                yield return null;
            }

            if (onComplete != null)
            {
                onComplete();
            }

            yield break;
        }
    }
}
