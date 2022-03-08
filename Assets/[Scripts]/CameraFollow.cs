using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Transform opponentTransform;

    public float minDist;
    private float maxDist = -10.0f;


    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs(playerTransform.position.x - opponentTransform.position.x) * 2;
        float centrePoint = (playerTransform.position.x + opponentTransform.position.x) / 2;

        transform.position = new Vector3(centrePoint, transform.position.y, distance > minDist ? -distance : -minDist);

        if(transform.position.z < maxDist)
        {
            transform.position = new Vector3(centrePoint, transform.position.y, distance < maxDist ? distance : maxDist);
        }

    }
}
