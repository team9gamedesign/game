using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClickerScript : MonoBehaviour
{
    public GameObject spaceStation;
    public GameObject ship;
    public GameObject planet1;
    public GameObject textBox;
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
        if(go.name.Equals(spaceStation.name))
        {
            infoBoxText.text = "Main base, here is your hub";
            textBox.SetActive(true);
            select = 0;
        }
        else if(go.name.Equals(planet1.name)) {
            infoBoxText.text = "Planet Dirt, your mission is to have fun and kill enemeis.";
            textBox.SetActive(true);
            select = 1;
        }
        else if(go.name.Equals(ship.name))
        {
            infoBoxText.text = "The proud spaceship, ready to take you anywhere in the galaxy in a matter of seconds.";
            textBox.SetActive(true);
            select = 2;
        }
    }

    public void onClick()
    {
        print("You clicked it");
    }
}
