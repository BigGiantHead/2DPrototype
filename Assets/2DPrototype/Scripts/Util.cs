using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utility methods
/// </summary>
public static class Util
{
    /// <summary>
    /// Reference to the UI canvas in the current scene.
    /// </summary>
    private static Canvas canvas = null;

    /// <summary>
    /// Reference to the UI canvas RectTransform in the current scene.
    /// </summary>
    private static RectTransform canvasRect = null;

    /// <summary>
    /// Gets the UI canvas in the current scene.
    /// Valid only for this game setup.
    /// REFACTOR.
    /// </summary>
    /// <returns>Returns the UI canvas.</returns>
    public static Canvas GetUICanvas()
    {
        if (canvas == null)
        {
            canvas = GameObject.FindObjectOfType<Canvas>();
        }

        return canvas;
    }

    /// <summary>
    /// Gets the UI canvas RectTransform from the current scene.
    /// Valid only for this game setup.
    /// REFACTOR.
    /// </summary>
    /// <returns>Returns the UI canvas RectTransform.</returns>
    public static RectTransform GetUICanvasRect()
    {
        if (canvasRect == null)
        {
            canvasRect = GetUICanvas().GetComponent<RectTransform>();
        }

        return canvasRect;
    }

    /// <summary>
    /// Position a RectTransform inside a canvas to follow a wold position.
    /// </summary>
    /// <param name="transform">Target RectTransform.</param>
    /// <param name="canvasRect">Reference to the RectTransform of the canvas.</param>
    /// <param name="worldPosition">World position to follow.</param>
    public static void PositionOnWorldPoint(this RectTransform transform, RectTransform canvasRect, Vector3 worldPosition)
    {
        Vector2 screenpoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPosition);
        transform.anchoredPosition = screenpoint - canvasRect.sizeDelta * 0.5f;
    }
}
