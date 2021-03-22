using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

	private Transform bullet;
	public float speed = 0.05f;

	// Use this for initialization
	void Start()
	{
		bullet = GetComponent<Transform>();
	}

	void FixedUpdate()
	{
		bullet.position += Vector3.up * -speed;

		if (bullet.position.y <= -10)
			Destroy(bullet.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
			GameOver.isPlayerDead = true;
		}
		else if (other.tag == "Base")
		{
			GameObject playerBase = other.gameObject;
			Base baseHealth = playerBase.GetComponent<Base>();
			baseHealth.health -= 1;
			Destroy(gameObject);
		}
	}
}