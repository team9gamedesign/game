using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassSelectionHandler : MonoBehaviour
{
    public Light pointLight;
    public GameObject berserkerInformation;
    public GameObject gunMageInformation;

    // Start is called before the first frame update
    void Start()
    {
        pointLight.transform.position = new Vector3(-2, 8, 0);
        berserkerInformation.SetActive(true);
        gunMageInformation.SetActive(false);
    }

    public void OnBerserkerClick()
    {
        pointLight.transform.position = new Vector3(-2, 8, 0);
        berserkerInformation.SetActive(true);
        gunMageInformation.SetActive(false);
    }

    public void OnGunMageClick()
    {
        pointLight.transform.position = new Vector3(2, 8, 0);
        berserkerInformation.SetActive(false);
        gunMageInformation.SetActive(true);
    }

    public void OnChooseClick(bool berserker)
    {
        ClassStorage.instance.usingBerserker = berserker;
        SceneManager.LoadScene("HubOverview");
    }
}
