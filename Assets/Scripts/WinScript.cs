using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {    
    
    //Ef player kemst í nánd við kistuna þá vinnur hann, á eftir að útfæra win textann.

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }   
    }
}
