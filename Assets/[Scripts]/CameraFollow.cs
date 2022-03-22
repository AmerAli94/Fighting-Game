using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Transform opponentTransform;

    public float minDist = -0.5f;
    public float maxDist = -10.0f;
    public float speed = 0.5f;
    public PlayerBehaviour player;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!player.inputIsBlocked)
        {
            float distance = Mathf.Abs(playerTransform.position.x - opponentTransform.position.x) * 2;
            float centrePoint = (playerTransform.position.x + opponentTransform.position.x) / 2;

            //Moves the camera in a smooth motion towards the centrepoint of the distance between player & opponent

            //transform.position = new Vector3(centrePoint, transform.position.y, distance * speed > minDist ? -distance   : -minDist) ;
            transform.position = Vector3.Lerp(transform.position, new Vector3(centrePoint, transform.position.y, distance * speed > minDist ? -distance : -minDist), speed * Time.deltaTime);

            //limiting the max camera movement


            if (transform.position.z < maxDist)
            {
                //transform.position = new Vector3(centrePoint, transform.position.y, distance * speed < maxDist ? distance : maxDist);
                transform.position = new Vector3(transform.position.x, transform.position.y, maxDist);
            }
        }

        //else
        //{
        //    float distance = Mathf.Abs(playerTransform.position.x - opponentTransform.position.x) * 2;
        //    float centrePoint = (playerTransform.position.x + opponentTransform.position.x) / 2;
        //    minDist = 0.0f;
        //    maxDist = -3.0f;

        //    transform.position = Vector3.Lerp(transform.position, new Vector3(centrePoint, transform.position.y - 5.0f, distance * speed > minDist ? -distance : -minDist), speed * Time.deltaTime);

        //}

    }

}
