using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Animator anim;
	public GameObject bullet;
	float input_x = 0;
	float input_y = -1f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		input_x = Input.GetAxisRaw ("Horizontal");
		input_y = Input.GetAxisRaw ("Vertical");

		bool isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;

		anim.SetBool ("isWalking", isWalking);
		if (isWalking) {
			anim.SetFloat ("x", input_x);
			anim.SetFloat ("y", input_y);

			transform.position += new Vector3 (input_x, input_y, 0).normalized * Time.deltaTime;
		}

		if (Input.GetKeyDown ("space")) {
			Attack ();
			anim.SetTrigger ("Attack");
		}
	}

	private void Attack(){
		if (anim.GetFloat("x") == 1 && anim.GetFloat("y") == 0) {
			GameObject b = Instantiate (bullet, new Vector3 (transform.position.x + 0.15f, transform.position.y, 0), transform.rotation);
			Bullet bb = b.GetComponent<Bullet> ();
			bb.x = 1f;
			bb.y = 0;
		}
		if (anim.GetFloat("x") == -1 && anim.GetFloat("y") == 0) {
			GameObject b = Instantiate (bullet, new Vector3 (transform.position.x - 0.15f, transform.position.y, 0), transform.rotation);
			Bullet bb = b.GetComponent<Bullet> ();
			bb.x = -1f;
			bb.y = 0;
		}
		if (anim.GetFloat("y") == 1 && anim.GetFloat("x") == 0) {
			GameObject b = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y + 0.15f, 0), transform.rotation);
			Bullet bb = b.GetComponent<Bullet> ();
			bb.x = 0;
			bb.y = 1f;
		}
		if (anim.GetFloat("y") == -1 && anim.GetFloat("x") == 0) {
			GameObject b = Instantiate (bullet, new Vector3 (transform.position.x, transform.position.y - 0.15f, 0), transform.rotation);	
			Bullet bb = b.GetComponent<Bullet> ();
			bb.x = 0;
			bb.y = -1f;
		}
	}

}
	
