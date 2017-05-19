using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Component that manages the components of the health line.
    /// </summary>
    public class HealthLine : MonoBehaviour
    {
        /// <summary>
        /// Reference to the Text field that holds the hipoints number.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the Text field that holds the hipoints number.")]
        private Text healthNumber = null;

        /// <summary>
        /// Reference to the fill of the health line.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the fill of the health line.")]
        private Transform fill = null;

        /// <summary>
        /// Get or set the health number text.
        /// </summary>
        public string HealthNumber
        {
            get
            {
                return healthNumber.text;
            }
            set
            {
                healthNumber.text = value;
            }
        }

        /// <summary>
        /// Get or set the fill percentage.
        /// </summary>
        public float FillPercent
        {
            get
            {
                return fill.localScale.x;
            }
            set
            {
                fill.localScale = new Vector3(Mathf.Clamp01(value), 1, 1);
            }
        }
    }
}