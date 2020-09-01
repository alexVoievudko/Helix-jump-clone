using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixRotation : MonoBehaviour
{
    private Vector2 lastTapPos;

    private Vector3 startRotation;
    
    void Awake()
    {
        startRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            Vector2 curPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = curPos;
            }

            float delta = lastTapPos.x - curPos.x;
            lastTapPos = curPos;

            transform.Rotate(Vector3.up * delta);

        }
        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
    }
}
