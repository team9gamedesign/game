using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombShot : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    public float speed = 20f;
    public float damage = 1f;
    public float explodeTimer = 2f;
    private Animator anim;
    private bool shouldUpdate = true;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = PlayerManager.instance.player;
        playerPos = player.transform.position;
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldUpdate)
        {
            if(anim.GetBool("BlowUp"))
            {
                shouldUpdate = false;
                Destroy(gameObject, 1f);
            }
            else if(anim.GetBool("Ticking"))
            {
                explodeTimer -= Time.deltaTime;
                if(explodeTimer <= 0)
                {
                    anim.SetBool("BlowUp", true);
                }
            }
            else if(Vector3.Distance(transform.position, playerPos) < 1f)
            {
                anim.SetBool("Ticking", true);
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            } 
        }
    }

}
