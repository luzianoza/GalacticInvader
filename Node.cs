using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject currentTurret;
    public Color hoverColor;
    private Color startColor;
    private Renderer renColor;

    void Start()
    {
        renColor = GetComponent<Renderer>();
        startColor = renColor.material.color;
    }

    private void OnMouseEnter()
    {
        renColor.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        renColor.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (currentTurret != null)
        {
            MainGameController.instance.nodeUI.ShowNodeUI(this);
            //Debug.Log("Can't build on this node");
            return;
        }
        MainGameController.instance.nodeUI.HideNodeUI();

        if (BuildManager.instance.GetTurretToBuild() == null)
        {
            return;
        }

        if (BuildManager.instance.GetTurretToBuild().price > MainGameController.instance.gold)
        {
            Debug.Log("more gold require to build turret");
            return;
        }
        currentTurret = Instantiate(BuildManager.instance.GetTurretToBuild().prefeb, transform.position, Quaternion.identity);
        MainGameController.instance.gold -= BuildManager.instance.GetTurretToBuild().price;

        BuildManager.instance.ClearTurretToBuild();
    }
}
