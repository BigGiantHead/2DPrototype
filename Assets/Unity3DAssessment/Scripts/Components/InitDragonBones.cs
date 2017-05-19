using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

namespace Com.Game2D.Ptotype
{
    /// <summary>
    /// Initializes the DragonBones factory.
    /// I am not sure if this good or not. Probably not.
    /// I've never used DragonBones before. :)
    /// </summary>
    public class InitDragonBones : MonoBehaviour
    {
        /// <summary>
        /// Paths to skeleton files.
        /// </summary>
        public string[] SkeletonPaths = null;

        /// <summary>
        /// Paths to skin files.
        /// </summary>
        public string[] SkinPaths = null;

        // Use this for initialization
        void Awake()
        {
            for (int i = 0; i < SkeletonPaths.Length; ++i)
            {
                // Load data.
                UnityFactory.factory.LoadDragonBonesData(SkeletonPaths[i]); // DragonBones file path (without suffix)
            }
            for (int i = 0; i < SkinPaths.Length; ++i)
            {
                // Load data.
                UnityFactory.factory.LoadTextureAtlasData(SkinPaths[i]); //Texture atlas file path (without suffix)
            }
        }
    }
}
