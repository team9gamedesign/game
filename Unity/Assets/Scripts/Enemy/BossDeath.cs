using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    public void OnDestroy()
    {
        if(GetComponent<Stats>().health <= 0)
        {
            SceneManager.LoadSceneAsync(0);
            Destroy(PlayerManager.instance.player);
            PlayerManager.instance.player = null;
        }
    }
}
