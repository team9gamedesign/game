using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitSewer : MonoBehaviour
{
    public Camera camera;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            camera.GetComponent<SewerGlobalVars>().exitInfo();
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("BossPart");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            camera.GetComponent<SewerGlobalVars>().hideInfoBox();
        }
    }
}
