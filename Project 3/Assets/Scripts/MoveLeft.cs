using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private PlayerController playerControllerScript;
    private float leftBoundry = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Stop background and obstacles from moving when game over is true
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //Destroy obstacles that are out of bounds
        if (transform.position.x < leftBoundry && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
