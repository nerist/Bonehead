using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	//public AudioClip music;
	void Awake (){
		DontDestroyOnLoad(transform.gameObject);
	}
}