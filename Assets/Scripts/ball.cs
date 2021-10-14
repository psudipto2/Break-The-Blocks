using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] BallSounds;
    Vector2 PaddleToBallVector;
    bool GameOn = false;
    AudioSource myAudioSource;
    [SerializeField] float RandomFactor = 0.5f;
    [SerializeField] Rigidbody2D myrigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        PaddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource= GetComponent<AudioSource>();
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOn == false)
        {
            LockBall();
            LaunchBall();
        }
    }
    private void LockBall()
    {
        Vector2 Paddlepos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = Paddlepos + PaddleToBallVector;
    }
    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameOn = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 RandomTweak = new Vector2(Random.Range(0f,RandomFactor),Random.Range(0f,RandomFactor));
        if (GameOn)
        {
            AudioClip clip = BallSounds[UnityEngine.Random.Range(0, BallSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myrigidbody2D.velocity = myrigidbody2D.velocity + RandomTweak;
        }
    }

}
