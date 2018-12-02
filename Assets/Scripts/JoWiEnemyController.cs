using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoWiEnemyController : MonoBehaviour
{
	public Transform bed;
	public float speed;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void FixedUpdate()
	{

		transform.position = Vector2.MoveTowards(transform.position, bed.position, speed * Time.deltaTime);
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("ZBullet") && JoWiGameController.enemieskilled < 5)
		{
			Destroy(gameObject);
			Destroy(collision.gameObject);
			GameLoader.AddScore(2);
			JoWiGameController.enemieskilled++;
		}
	}

}
