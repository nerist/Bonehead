﻿using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent <Rigidbody2D> ();
		rb2d.AddForce (Vector2.right * 100f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
