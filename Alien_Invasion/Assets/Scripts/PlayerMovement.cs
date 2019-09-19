using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    private Animator anim;

    Vector2 moveAmount;
    Vector2 mousePos;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveAmount.x = Input.GetAxisRaw("Horizontal");
        moveAmount.y = Input.GetAxisRaw("Vertical");
        moveAmount = moveAmount.normalized * moveSpeed;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (moveAmount != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angleZ = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angleZ;
    }
}
