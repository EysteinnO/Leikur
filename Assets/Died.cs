using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Skrifta fyrir dauða, ef player kemst í nánd við tagið "Enemy" þá er drepið gameobjectið

public class Died : MonoBehaviour {
    public ScoreScript score;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {           
            Destroy(gameObject);
            Application.LoadLevel(Application.loadedLevel);
            ScoreScript.scoreValue = 0;
        }
    }
}
