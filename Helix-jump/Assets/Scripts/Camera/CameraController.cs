using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	[SerializeField] private Transform player;

	private Vector3 defaultPos;
	private Vector3 tempPos;
	private float deltaY;

	private void Awake()
	{
		defaultPos = transform.position;
		tempPos = transform.position;
		deltaY = player.position.y - tempPos.y;
	}

	private void LateUpdate()
	{
		float playerY = player.position.y;

		if (transform.position.y + deltaY > playerY)
		{
			tempPos.y = playerY - deltaY;
			transform.position = tempPos;
		} 
	}

	// Should be used in the GameManager to reset the level.
	public void ResetCameraPosition()
	{
		transform.position = defaultPos;
	}
}
