using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    public int keyID;
    public bool found;

    private void Start()
    {
        found = false;
    }

    public override void Interact()
    {
        Globals.playerKeys[keyID] = true;
        gameObject.SetActive(false);
        dialog.SendThought(message);
        found = true;
    }
}
