using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour {
    //Projectile sem kallinn skýtur.

    public float speed;
    private Rigidbody2D rb;
    public PlayerController player;
    public AudioSource audioData;
    public PlayerController direction;

	// Use this for initialization
	void Start () {

        audioData = GetComponent<AudioSource> ();    
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        

        if (player.facingRight == false)
        {
            speed = -speed;
        }
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(speed, rb.velocity.y);

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);            
        }
        Destroy(gameObject);
    }
}
