using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintCraftingPanel : MonoBehaviour {

    [SerializeField]
    private Blueprint blueprint;

    [SerializeField]
    private Text title;

    [SerializeField]
    private Text description;

    [SerializeField]
    private GameObject neededIngredientsList;

    private void Start()
    {
        SetBlueprint(blueprint);
    }

    private void SetBlueprint(Blueprint bp)
    {
        this.blueprint = bp;
        title.text = bp.createsItem.GetName();
        description.text = bp.createsItem.GetDescription();
    }

}

