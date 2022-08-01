using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform cubeTransform;

    private Vector3 offset;

    private Vector3 newPosition;

    [SerializeField] [Range(0,3)] private float LerpValue;
    void Start()
    {
        offset = transform.position - cubeTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SetCameraFollow();
    }

    private void SetCameraFollow()
    {
        newPosition = Vector3.Lerp(transform.position,cubeTransform.position + offset, LerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
