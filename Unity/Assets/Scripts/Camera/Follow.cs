using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Vector3 offset;

    GameObject player;

    public bool shake;
    public float shakeTimer = 0.5f;
    public float shakeAmount = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        transform.position = playerPosition + offset;
        transform.rotation = Quaternion.LookRotation(playerPosition - transform.position);

        if(shake)
        {
            shakeTimer = Mathf.Max(0, shakeTimer - Time.deltaTime);
            if(shakeTimer <= 0)
            {
                shake = false;
            } else
            {
                transform.position += Random.insideUnitSphere * shakeAmount;
            }
        }
    }
}
