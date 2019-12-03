using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.instance.player.transform.position = transform.position;
    }
}
