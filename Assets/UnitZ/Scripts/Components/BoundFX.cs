//----------------------------------------------
//      UnitZ : FPS Sandbox Starter Kit
//    Copyright © Hardworker studio 2015 
// by Rachan Neamprasert www.hardworkerstudio.com
//----------------------------------------------

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class BoundFX : MonoBehaviour
{

	private AudioSource Audiosource;
	public AudioClip[] Sounds;
	
	void Start ()
	{
		Audiosource = this.GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (Sounds.Length > 0)
			Audiosource.PlayOneShot (Sounds [Random.Range (0, Sounds.Length)]);
        
	}
}
