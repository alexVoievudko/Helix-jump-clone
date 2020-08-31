using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
	[Header("Impulse Settings")]
	[SerializeField] private Rigidbody rb;
	[SerializeField] private float impulseForce = 5f;

	[Header("Audio Settings")]
	[SerializeField] private AudioSource playAudio;
	[SerializeField] private AudioClip hitSound;
	[SerializeField] private AudioClip deadSound;


	private bool ignoreNextCollision;
	private Vector3 startPosition;

	private void Awake()
	{
		startPosition = transform.position;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (ignoreNextCollision)
			return;

		if (collision.gameObject.CompareTag("Good Part"))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
			playAudio.PlayOneShot(hitSound);
		}

		if (collision.gameObject.CompareTag("Dead Part"))
		{
			// Call the GameManager method to reset the level.
			playAudio.PlayOneShot(deadSound);
		}
		
		ignoreNextCollision = true;
		Invoke("AllowCollision", 0.2f);
	}

	// Used to exclude the effect of multiple collisions.
	private void AllowCollision()
	{
		ignoreNextCollision = false;
	}

	// Should be used in the GameManager to reset the level.
	public void ResetBallPosition()
	{
		transform.position = startPosition;
	}
}
