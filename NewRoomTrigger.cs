using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NewRoomTrigger : MonoBehaviour
{
    public Room thisRoom;
    public Room otherRoom;
    SpriteRenderer sprite;
    public bool invisible;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        if (!thisRoom.inRoom)
        {
            Color newColor = sprite.color;
            newColor.a = 0.0f;
            sprite.color = newColor;
        }
    }

    void Update()
    {
        if (!invisible)
        {
            Color newColor = sprite.color;
            newColor.a = thisRoom.tiles.color.a;
            sprite.color = newColor;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            if (!thisRoom.inRoom)
            {
                thisRoom.FadeIn();
                otherRoom.FadeOut();
            }
        }
    }

} 
