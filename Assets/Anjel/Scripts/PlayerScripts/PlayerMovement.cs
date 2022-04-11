using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float stamina = 10;
    public static bool HasGunOut = false;

    public Rigidbody2D rb;
    public Camera cam;
    Animator ani;
    SpriteRenderer sr;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.LeftShift) && stamina > 1)
        {
            moveSpeed *= 2;
            ani.speed *= 2;
            stamina -= 0.05f;

        } else if (Input.GetKey(KeyCode.LeftShift) != true && stamina <= 10)
        {
            stamina += 0.1f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || stamina <= 0.01f)
        {
            moveSpeed *= 0.5f;
            ani.speed *= 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu");

        mousePos = Input.mousePosition;
        mousePos -= new Vector2(Screen.width / 2, Screen.height / 2);
        //print(mousePos.normalized);

        ani.SetFloat("Horizontal", movement.x);
        ani.SetFloat("Vertical", movement.y);

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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos.normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
