using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update

    private void Awake()
    {
        PlayerController.GameOver += Stop;
    }

    private void OnDisable()
    {
        PlayerController.GameOver -= Stop;
    }

    private void OnDestroy()
    {
        PlayerController.GameOver -= Stop;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if(transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }

    private void Stop()
    {
        moveSpeed = 0;
    }
}
