using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Component that manages the components and animation of the damage effect.
    /// Can be pooled, but not now... sorry.:)
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class DamageEffect : MonoBehaviour
    {
        /// <summary>
        /// Reference to the canvas group component.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the CanvasGroup component.")]
        private CanvasGroup canvasGroup = null;

        /// <summary>
        /// Reference to the Text component.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the Text component.")]
        private Text textField = null;

        /// <summary>
        /// The speed at which the effect fades out.
        /// </summary>
        [Tooltip("The speed at which the effect fades out.")]
        public float FadeOutSpeedModifier = 10;
        
        /// <summary>
        /// The time before tha effect starts fading out.
        /// </summary>
        [Tooltip("The time before tha effect starts fading out.")]
        public float DurationBeforeFadeOut = 3;

        /// <summary>
        /// The upward movement speed of the damage effect.
        /// </summary>
        [Tooltip("The upward movement speed of the damage effect.")]
        public float UpwardMovementSpeed = 100;

        /// <summary>
        /// Get and set the text of the damage effect.
        /// </summary>
        public string Text
        {
            get
            {
                return textField.text;
            }
            set
            {
                textField.text = value;
            }
        }

        // Use this for initialization
        void Start()
        {
            StartCoroutine(DoAnimate());
        }

        void Reset()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        /// <summary>
        /// Animates the damage effect.
        /// Can be done in an animation, by I'm a programmer. :)
        /// </summary>
        /// <returns></returns>
        private IEnumerator DoAnimate()
        {
            yield return new WaitForSeconds(DurationBeforeFadeOut);

            while(canvasGroup.alpha > 0.05f)
            {
                canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 0, Time.deltaTime * FadeOutSpeedModifier);
                transform.localPosition += Vector3.up * Time.deltaTime * UpwardMovementSpeed;

                yield return null;
            }

            canvasGroup.alpha = 0;

            Destroy(gameObject);
        }
    }
}
