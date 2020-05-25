using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float ParallaxEffect;
    public GameObject Camera;

    private float speed;
    private const float CAMERA_SIZE = 50f;
    private float length;

    private void Start()
    {
        speed = 5f;
        length = transform.Find("Middle").GetComponent<SpriteRenderer>().bounds.size.x;
        Bird.GetInstance().OnStartedPlaying += Bird_OnStartedPlaying;
        Bird.GetInstance().OnDied += Bird_OnDied;
    }

    private void Bird_OnStartedPlaying(object sender, System.EventArgs e)
    {
        speed = 25f;
    }

    private void Bird_OnDied(object sender, System.EventArgs e)
    {
        speed = 0f;
    }

    private void Update()
    {
        transform.Translate(-speed * ParallaxEffect * Time.deltaTime, 0, 0);
        if (transform.position.x < -length)
        {
            Vector2 pos = new Vector2(transform.position.x + length, 0f);
            transform.position = pos;
        }
    }
}
