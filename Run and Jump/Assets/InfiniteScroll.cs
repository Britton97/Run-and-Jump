using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    public float speed = .5f;
    Renderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, 0);
        myRenderer.material.mainTextureOffset = offset;
    }

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

    private void Stop()
    {
        speed = 0;
    }
}
