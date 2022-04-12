using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public static bool HasGunOut = false;

    public Rigidbody2D rb;
    public Camera cam;
    Animator ani;
    SpriteRenderer sr;

    public Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = Input.mousePosition;
        mousePos -= new Vector2(Screen.width / 2, Screen.height / 2);
        print(mousePos.normalized);
        Debug.Log("`````````````X" + movement.x + "Y" + movement.y);
        ani.SetFloat("Horizontal", movement.x);
        ani.SetFloat("Vertical", movement.y);
        
        //if (transform.rotation.z > -45 && transform.rotation.z < 45)
        //{
        //    ani.SetBool("MovingUp", true);
        //} else
        //{
        //    ani.SetBool("MovingUp", false);
        //}

        if (movement != new Vector2())
        {
            ani.SetBool("Moving", true);
        }
        else
        {
            ani.SetBool("Moving", false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            ani.SetBool("HasGunOut", true);
            HasGunOut = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            ani.SetBool("HasGunOut", false);
            HasGunOut = false;
        }

        //Vector2 rmos = new Vector2(Mathf.Round(mousePos.normalized.x), Mathf.Round(mousePos.normalized.y));
        //Vector2 rmov = new Vector2(Mathf.Round(movement.normalized.x), Mathf.Round(movement.normalized.y));
        //float ang = Mathf.Abs(Mathf.Atan2(rmov.y, rmov.x) * Mathf.Rad2Deg - 90f) - Mathf.Abs(Mathf.Atan2(rmos.y, rmos.x) * Mathf.Rad2Deg - 90f);
        //print(ang);

        //if (rmos == rmov)
        //{
        //    ani.SetBool("MovingUp", true);
        //}
        //else
        //{
        //    ani.SetBool("MovingUp", false);
        //}
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos.normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
