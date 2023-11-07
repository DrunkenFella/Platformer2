using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    float speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        float y = Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize);
        Vector2 pos = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, y);

        transform.position = pos;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.left * speed * Time.deltaTime;

        transform.Translate(movement);

        if (transform.position.x < -Camera.main.orthographicSize - 10)

        {
            GameObject.Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
