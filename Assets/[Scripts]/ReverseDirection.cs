using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseDirection : MonoBehaviour
{

    public Transform player;
    public Transform opponent;
    public float rotationSpeed;

    public Collider directionChangeCollider;


    // Start is called before the first frame update
    void Start()
    {
        directionChangeCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.rotation.eulerAngles.y == 90.0f)
            {
                //Vector3 currentRotation = player.rotation.eulerAngles;
                //Vector3 targetRotation = new Vector3(player.transform.localEulerAngles.x, -90.0f, player.transform.localEulerAngles.z);
                //player.rotation = Quaternion.Euler(player.transform.localEulerAngles.x, -90.0f, player.transform.localEulerAngles.z);
                var currentRotation_P = Quaternion.Euler(player.transform.localEulerAngles.x, player.transform.localEulerAngles.y, player.transform.localEulerAngles.z);
                var desiredRotation_P = Quaternion.Euler(player.transform.localEulerAngles.x, 180.0f, player.transform.localEulerAngles.z);
                player.rotation = Quaternion.Lerp(currentRotation_P, desiredRotation_P, 0.5f);

                var currentRotation_O = Quaternion.Euler(opponent.transform.localEulerAngles.x, opponent.transform.localEulerAngles.y, opponent.transform.localEulerAngles.z);
                var desiredRotation_O = Quaternion.Euler(opponent.transform.localEulerAngles.x, -180.0f, opponent.transform.localEulerAngles.z);
                opponent.rotation = Quaternion.Lerp(currentRotation_O, desiredRotation_O, 0.5f);
               // opponent.rotation = Quaternion.Euler(opponent.transform.localEulerAngles.x, 90.0f, opponent.transform.localEulerAngles.z);


            }

            else
            {
                //  var currentRotation_P = Quaternion.Euler(player.transform.localEulerAngles.x, player.transform.localEulerAngles.y, player.transform.localEulerAngles.z);
                ////  var desiredRotation_P = Quaternion.Euler(player.transform.localEulerAngles.x, 15.0f* 0.0f, player.transform.localEulerAngles.z);
                //  player.rotation = Quaternion.Lerp(currentRotation_P, init, 0.5f);

                //  var currentRotation_O = Quaternion.Euler(opponent.transform.localEulerAngles.x, opponent.transform.localEulerAngles.y, opponent.transform.localEulerAngles.z);
                //  var desiredRotation_O = Quaternion.Euler(opponent.transform.localEulerAngles.x, 0.0f * 0.0f, opponent.transform.localEulerAngles.z);
                //  opponent.rotation = Quaternion.Lerp(currentRotation_O, desiredRotation_O, 0.5f);

                player.rotation = Quaternion.Euler(player.transform.localEulerAngles.x, 90.0f, player.transform.localEulerAngles.z);
                opponent.rotation = Quaternion.Euler(opponent.transform.localEulerAngles.x, -90.0f, opponent.transform.localEulerAngles.z);
            }
        }

    }
}
