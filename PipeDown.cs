using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDown : MonoBehaviour {
    private Character character;
	// Use this for initialization
	void Start () {
        character = FindObjectOfType<Character>();
	}
	
	// Update is called once per frame
	void Update () {
		if(character.transform.position.x-transform.position.x>30)
        {
            Destroy(gameObject);
        }
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            character.Death();
        }
    }
}
