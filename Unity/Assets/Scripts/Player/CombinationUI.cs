using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationUI : MonoBehaviour
{
	public Image Combination1;
	public Image Combination2;

    public Color active;
    public Color inActive;

	private CombinationHandler combinationHandler;

    void Start()
	{
		combinationHandler = GetComponent<CombinationHandler>();
	}

    // Update is called once per frame
    void Update()
    {
        Combination1.color = combinationHandler.QKeyCombination != null ? active : inActive;
        Combination2.color = combinationHandler.EKeyCombination != null ? active : inActive;
    }
}
