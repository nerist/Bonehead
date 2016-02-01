using UnityEngine;
using System.Collections;

public class skull_controller : MonoBehaviour {
	public int speed;
	Rigidbody2D rb2d;
	Collider2D other;
	public AudioClip blade;
	void Start () {

		rb2d = GetComponent <Rigidbody2D> ();
		rb2d.AddForce (Vector2.right * 105f);
	}

	// Update is called once per frame
	void Update () {

			
			if (Input.GetMouseButton (0)) {			
				
			rb2d.AddForce (Vector2.up * 10f);
			
			}
			if (Input.GetKeyDown ("space")) {
			rb2d.AddForce (Vector2.up * 10f);
		}

		}
	IEnumerator giveforce(){
		yield return new WaitForSeconds (0.2f);
		//rb2d.AddForce (Vector2.right * 5f);
	}

	IEnumerator speedme(){

		yield return new WaitForSeconds (0.2f);
		rb2d.AddForce (Vector2.right * 10f);
		yield return new WaitForSeconds (3f);
		rb2d.AddForce (Vector2.left * 12f);
	}

	
	void OnBecameInvisible() {
		Application.LoadLevel (3);
	}

	void OnCollisionEnter2D (Collision2D otherObject){
		if (otherObject.gameObject.tag == "silu") {
			StartCoroutine ("giveforce");
}

		if (otherObject.gameObject.tag == "blade") {
			other = otherObject.collider;
			Application.LoadLevel (3);
			GetComponent<Animation>().Play("opac");

		}
		if (otherObject.gameObject.tag == "complete") {
			other = otherObject.collider;
			Application.LoadLevel (0);
		}
		
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<Collider2D>().tag == "speed") {
			StartCoroutine ("speedme");
		}
		if (other.GetComponent<Collider2D>().tag == "sound") {
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play(); 
			Debug.Log ("PLAYMOFO");
		}

	}
}
