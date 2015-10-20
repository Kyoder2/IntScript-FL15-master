﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	public float setupSpinSpeed = 50.0f;
	public float speed = 16.0f;
	public float rotationSpeed = .60f;
	public float hoverPower = 3.5f;
	public Rigidbody projectile;

	public Color red = Color.red;
	public Color blue = Color.blue;
	public Color green = Color.green;
	public Color yellow = Color.yellow;
	public Color white = Color.white;

	private GameData gameDataRef;
	// Use this for initialization
	void Start () 
	{
		gameDataRef = GameObject.Find("GameManager").
	GetComponent<GameData>();
	}
	
	void FixedUpdate()
	{
		float foreAndAft = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		GetComponent<Rigidbody>().AddRelativeForce (0, 0, foreAndAft);
		GetComponent<Rigidbody>().AddTorque (0, rotation, 0);
	}

	void OnTriggerStay(Collider other)
	{
		GetComponent<Rigidbody>().AddForce(Vector3.up *hoverPower);
	}
	public void PickedColor (Color playerColor)
	{
		GetComponent<Renderer>().material.color = playerColor;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "GoodOrb")
		{
			gameDataRef.score += 1;
			Destroy(other.gameObject);
		}
	}

	void OnCollisionEnter(Collision collidedWith)
	{
		if(collidedWith.gameObject.tag == "BadOrb")
		{
			gameDataRef.playerLives -= 1;
			Destroy(collidedWith.gameObject);
		}
	}

	public void FireEnergyPulse()
	{
		Rigidbody clone;
		clone = Instantiate(projectile, transform.position,
	 transform.rotation) as Rigidbody;
		clone.transform.Translate(0, .5f, 2.1f);
		clone.velocity = transform. 
	TransformDirection(Vector3.forward * 50);
	}
}