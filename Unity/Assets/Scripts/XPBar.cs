using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
	//Insert xpBar
	public Image xpBar;

	float maxXP;
	float currentXP;

	private Stats stats;
	private int currentLevel;

	// Start is called before the first frame update
	void Start()
	{
		stats = GetComponent<Stats>();
	}

	// Update is called once per frame
	void Update()
	{
		if (currentLevel != stats.level)
		{
			currentLevel = stats.level;
            //Retrieve maxXP and currentXP to appropriately set xpBar filling
            maxXP = stats.xpToNextLevel;
			currentXP = stats.xp;
		}

		//Update xpBar filling
		currentXP = stats.xp;
		xpBar.fillAmount = currentXP / maxXP;
	}
}
