using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 1f;
	Rigidbody2D RB;
	public float x, y;
	Animator anim;

	// Use this for initialization
	void Start () {
		RB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (x, y, 0)* Time.deltaTime * speed;
	}

	private void OnCollosionEnter2D(Collision2D col){
		anim.SetBool ("Hit", true);
		Destroy (gameObject);
	}
}
