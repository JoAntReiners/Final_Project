using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoWiGameController : MonoBehaviour
{
	public static int enemieskilled;
	public static bool playerkilled;
	public GameObject clouds;

	private float timer;
	// Use this for initialization
	void Start ()
	{
		enemieskilled = 0;
		playerkilled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log(enemieskilled);
		if(enemieskilled == 5)
		{
			Debug.Log("Victory");
			StartCoroutine(Victory(2));
		}
		else if(playerkilled == true && enemieskilled != 5)
		{
			Debug.Log("Defeat");
			StartCoroutine(Defeat(2));
		}
	}

	private void FixedUpdate()
	{
		timer = timer + Time.deltaTime;
		if (timer >= 10)
		{
			Debug.Log("Time UP");
			StartCoroutine(Defeat(2));
		}
	}


	IEnumerator Victory(float time)
	{
		clouds.SetActive(true);
		yield return new WaitForSeconds(time);
		clouds.SetActive(false);
		GameLoader.gameOn = false;
	}

	IEnumerator Defeat(float time)
	{
		yield return new WaitForSeconds(time);
		GameLoader.gameOn = false;
	}
}
