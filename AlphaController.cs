﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaController : MonoBehaviour
{

    public void setAlpha(float alpha)
    {
        SpriteRenderer[] childRenderers = GetComponentsInChildren<SpriteRenderer>();
        Color newColor;
        foreach (SpriteRenderer child in childRenderers)
        {
            newColor = child.color;
            newColor.a = alpha;
            child.color = newColor;
        }
    }

}
