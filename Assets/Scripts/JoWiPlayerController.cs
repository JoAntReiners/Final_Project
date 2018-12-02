using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoWiPlayerController : MonoBehaviour
{
	public float speed;
	public KeyCode fire;
	public GameObject z;
	public Transform shotSpawn;
	public float fireRate;
	public AudioClip snoring;

	private Rigidbody2D rb2d;
	private float nextFire = 0.0f;
	private AudioSource source;
	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(fire) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(z, shotSpawn.position, shotSpawn.rotation);
			source.PlayOneShot(snoring);
		}
	}

	private void FixedUpdate()
	{
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(new Vector3(0, 0, -120) * Time.deltaTime);
		}
		else if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(new Vector3(0, 0, 120) * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			rb2d.AddForce(transform.up * speed);
		}
		
		if(Input.GetKey(KeyCode.DownArrow))
		{
			rb2d.AddForce(transform.up * -1 * speed);
		}

		rb2d.position = new Vector2(Mathf.Clamp(rb2d.position.x, -14f, 7f), Mathf.Clamp(rb2d.position.y, -5, 6));

		/*float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rb2d.AddForce(movement * speed);*/
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Enemy"))
		{
			gameObject.SetActive(false);
			JoWiGameController.playerkilled = true;
		}
	}
}
