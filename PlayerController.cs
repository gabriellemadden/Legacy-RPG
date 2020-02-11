using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    Rigidbody2D rigidbody2D;
    Vector2 lookDirection = new Vector2(0, 1); // this could be pointing up or down, not sure
    Animator animator;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody2D.position;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(horizontal, vertical);
        position = position + move * speed * Time.deltaTime;
        rigidbody2D.MovePosition(position);


        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.up * 1.0f,
                lookDirection, 1.0f, LayerMask.GetMask("Interactables"));
            if (hit.collider != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }
}