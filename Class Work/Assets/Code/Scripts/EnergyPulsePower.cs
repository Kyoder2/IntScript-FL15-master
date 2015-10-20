using UnityEngine;
using System.Collections;

public class EnergyPulsePower : MonoBehaviour
 {
 	public float pulseDuration = 1f;

 	public Transform goodOrb;

 	void upadate()
 	{
 		pulseDuration -= Time.deltaTime;

 		if(pulseDuration <= 0)
 			Destroy(gameObject);
 	}

 	void OnTriggerEnter(Collider other)
 	{
 		if(other.gameObject.tag == "BadOrb")
 		{
 			Instantiate(goodOrb, other.transform.position, other.transform.rotaion);
 			gameObject.Find("GameManager").
 				GetComponent<GameDate>().playerLives += 1;
 			Destroy(other.gameObject);
 			Destroy(gameObject);
 		}
 	else 
 		Destroy(gameObject);
 	}
	
}
