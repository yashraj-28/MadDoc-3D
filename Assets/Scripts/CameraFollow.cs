using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;
    [SerializeField] private float smoothSpeed = 2f;
    [SerializeField] private float playerBoundMin_Y = -1f, playerBoundMin_X = -65f, playerBoundMax_X = 65f;

    [SerializeField] private float Y_Gap = 2f;
    private Vector3 tempPosition;

    private void Start() 
    {
        playerTarget = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void Update() 
    {
        if(!playerTarget)
            return;

        tempPosition = transform.position;

        if(playerTarget.position.y <= playerBoundMin_Y)
        {
            tempPosition = Vector3.Lerp(transform.position, new Vector3(playerTarget.position.x, playerTarget.position.y, -10f),
                                        Time.deltaTime * smoothSpeed);
        }
        else 
        {
            tempPosition = Vector3.Lerp(transform.position, new Vector3(playerTarget.position.x, playerTarget.position.y + Y_Gap, -10f),
                                        Time.deltaTime * smoothSpeed);
        }

        if(tempPosition.x > playerBoundMax_X)
            tempPosition.x = playerBoundMax_X;

        if(tempPosition.x < playerBoundMin_X)
            tempPosition.x = playerBoundMin_X;
            
        transform.position = tempPosition;
    }
}
