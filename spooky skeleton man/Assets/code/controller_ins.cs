using UnityEngine;
using System.Collections;

public class controller_ins : MonoBehaviour {

	public int speed;
	Rigidbody2D rb2d;
	Collider2D other;
	void Start () {
		
		rb2d = GetComponent <Rigidbody2D> ();
		rb2d.AddForce (Vector2.right * 105f);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Input.GetMouseButton (0)) {			
			
			rb2d.AddForce (Vector2.up * 10f);
			
		}
		
	}
	IEnumerator giveforce(){
		yield return new WaitForSeconds (0.2f);
		rb2d.AddForce (Vector2.right * 30f);

	}
	
	IEnumerator speedme(){
		
		yield return new WaitForSeconds (0.2f);
		rb2d.AddForce (Vector2.right * 15f);
		yield return new WaitForSeconds (3f);
		rb2d.AddForce (Vector2.left * 12f);
	}

	
	void OnCollisionEnter2D (Collision2D otherObject){
		if (otherObject.gameObject.tag == "silu") {
			StartCoroutine ("giveforce");
		}
		
		if (otherObject.gameObject.tag == "blade") {
			other = otherObject.collider;
			Application.LoadLevel (3);

			
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
		
	}
}
