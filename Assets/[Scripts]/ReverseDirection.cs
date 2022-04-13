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
        var playerYAxis = player.transform.localEulerAngles.y;
        Debug.Log(playerYAxis);

        if (other.gameObject.CompareTag("Player"))
        {
            if (playerYAxis == 0.0f)
            {
                StartCoroutine(JumpRotToLeftDelay());
            }
            
            if(playerYAxis == 180.0f)
            {
                StartCoroutine(JumpRotToRightDelay());
            }
        }
    }

    IEnumerator JumpRotToLeftDelay()
    {
        yield return new WaitForSeconds(0.3f);

        var currentRotation_P = Quaternion.Euler(player.transform.localEulerAngles.x, player.transform.localEulerAngles.y, player.transform.localEulerAngles.z);
        var desiredRotation_P = Quaternion.Euler(player.transform.localEulerAngles.x, 180.0f, player.transform.localEulerAngles.z);
        player.rotation = Quaternion.Lerp(currentRotation_P, desiredRotation_P, 0.5f);

        var currentRotation_O = Quaternion.Euler(opponent.transform.localEulerAngles.x, opponent.transform.localEulerAngles.y, opponent.transform.localEulerAngles.z);
        var desiredRotation_O = Quaternion.Euler(opponent.transform.localEulerAngles.x, -180.0f, opponent.transform.localEulerAngles.z);
        opponent.rotation = Quaternion.Lerp(currentRotation_O, desiredRotation_O, 0.5f);
    }

    IEnumerator JumpRotToRightDelay()
    {
        yield return new WaitForSeconds(0.3f);

        player.rotation = Quaternion.Euler(player.transform.localEulerAngles.x, 90.0f, player.transform.localEulerAngles.z);
        opponent.rotation = Quaternion.Euler(opponent.transform.localEulerAngles.x, -90.0f, opponent.transform.localEulerAngles.z);
    }
}
