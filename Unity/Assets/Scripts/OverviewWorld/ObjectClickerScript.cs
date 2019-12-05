using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectClickerScript : MonoBehaviour
{
    public GameObject spaceStation;
    public GameObject ship;
    public GameObject planet1;
    public GameObject textBox;
    public GameObject button;
    public Text infoBoxText;

    private int select;

    private void Start()
    {
        select = -1;
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Create a ray from mouse with camera as the reference
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform)
                {
                    OverViewInfo(hit.transform.gameObject);
                }
            }
            //Clicked nowhere clickable, remove info box
            else
            {
                textBox.SetActive(false);
            }
        }
    }

    void OverViewInfo(GameObject go)
    {
        Vector2 textBoxPosition = Camera.main.WorldToScreenPoint(go.transform.position);
        if(go.name.Equals(spaceStation.name))
        {
            infoBoxText.text = "The City in Space, a technological marvel and your home.";
            textBox.SetActive(true);
            button.SetActive(false);
            textBox.GetComponent<RectTransform>().anchoredPosition = textBoxPosition;
            select = 0;
        }
        else if(go.name.Equals(planet1.name)) {
            infoBoxText.text = "Coranus, a planet filled with valuable resources. You're tasked with killing the planet leader, King Bjor XI.";
            textBox.SetActive(true);
            button.SetActive(true);
            textBox.GetComponent<RectTransform>().anchoredPosition = textBoxPosition;
            select = 1;
        }
        else if(go.name.Equals(ship.name))
        {
            infoBoxText.text = "Your spaceship, ready to take you anywhere in the galaxy in a matter of seconds.";
            textBox.SetActive(true);
            button.SetActive(false);
            textBox.GetComponent<RectTransform>().anchoredPosition = textBoxPosition;
            select = 2;
        }
    }

    public void onClick()
    {
        ship.GetComponent<Animation>().Play();
        StartCoroutine(WaitUntilAnimationIsDone());
    }

    IEnumerator WaitUntilAnimationIsDone()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("CrashSite");
    }
}
