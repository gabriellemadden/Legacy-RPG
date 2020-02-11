using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour
{
    public bool startRoom;
    public bool inRoom;
    public Tilemap tiles;
    readonly float fadeTime = 0.4f;
    float fadeTimer;
    float alphaGoal;
    AlphaController alphaController;

    void Start()
    {
        alphaController = gameObject.GetComponent<AlphaController>();
        if (!inRoom)
        {
            // initialize to be invisible
            alphaController.setAlpha(0.0f);
            gameObject.SetActive(false);
            Color newColor = tiles.color;
            newColor.a = 0.0f;
            tiles.color = newColor;
        }
    }

    void Update()
    {
        if (fadeTimer <= 0) { return; }

        float newRoomAlpha = 0;
        if (alphaGoal == 0.0f) // fade out
        {
            newRoomAlpha = fadeTimer / fadeTime;
        }
        else if (alphaGoal == 1.0f) // fade in
        {
            newRoomAlpha = 1 - fadeTimer / fadeTime;
        }
        if (newRoomAlpha < 0) newRoomAlpha = 0;
        else if (newRoomAlpha > 1) newRoomAlpha = 1;

        Color newColor = tiles.color;
        newColor.a = newRoomAlpha;
        tiles.color = newColor;
        alphaController.setAlpha(newRoomAlpha);
        fadeTimer -= Time.deltaTime;

        if (fadeTimer < 0)
        {
            if (!inRoom) { gameObject.SetActive(false); }
            alphaController.setAlpha(alphaGoal);
            newColor = tiles.color;
            newColor.a = alphaGoal;
            tiles.color = newColor;
        }
    }

    public void FadeOut()
    {
        fadeTimer = fadeTime;
        alphaGoal = 0.0f;
        inRoom = false;
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        fadeTimer = fadeTime;
        alphaGoal = 1.0f;
        inRoom = true;
    }
}
