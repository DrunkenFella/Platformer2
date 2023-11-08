using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.Types;
using TMPro;

public class GregerController : MonoBehaviour
{


    [SerializeField]
    float speed = 5;

    [SerializeField]
    float hp = 69f;
    [SerializeField]
    float hpMax = 5f;

    [SerializeField]
    float jumpForce = 400;

    [SerializeField]
    float coins = 0;
    [SerializeField]
    TMP_Text healthText;
    [SerializeField]
    TMP_Text CoinsToGet;


    Rigidbody2D rBody;
    bool hasRelesedJumpedButton = true;

    [SerializeField]
    Transform feet;
    [SerializeField]
    float groundRadius = 0.2f;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float portalCoin = 5;

    [SerializeField]
    GameObject portal;

    void Awake()
    {
        hp = hpMax;
        rBody = GetComponent<Rigidbody2D>();
        updateHealthSlider();
        coins = 0;
        updateCoinsToGet();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector2(moveX, 0).normalized * speed * Time.deltaTime;

        transform.Translate(movement);

        bool isGorunded = Physics2D.OverlapCircle(feet.position, groundRadius, groundLayer);

        if (Input.GetAxisRaw("Jump") > 0 && hasRelesedJumpedButton == true && isGorunded)
        {
            rBody.AddForce(Vector2.up * jumpForce);
            hasRelesedJumpedButton = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasRelesedJumpedButton = true;
        }

        if (hp <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("hey");

        if (other.gameObject.tag == "Fire")
        {
            --hp;
            updateHealthSlider();
        }

        if (other.gameObject.tag == "Coin")
        {
            ++coins;
            updateCoinsToGet();
        }

        if (other.gameObject.tag == "Portal" && coins >= portalCoin)
        {
            print("Hello there");
            SceneManager.LoadScene(1);
        }
    }
    private void updateHealthSlider()
    {
        healthText.text = hp + "/" + hpMax + "HP";
    }

    private void updateCoinsToGet()
    {
        CoinsToGet.text = coins + "/" + portalCoin + "Coins";
    }



    private void OnDrawGizmos()
    {
        if (feet)
        {
            Gizmos.DrawWireSphere(feet.position, groundRadius);
        }
    }

}