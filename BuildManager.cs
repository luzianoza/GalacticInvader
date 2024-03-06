using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    public TurretBluePrint basicTurretLV1BluePrint;
    public TurretBluePrint basicTurretLV2BluePrint;
    public TurretBluePrint basicTurretLV3BluePrint;
    public TurretBluePrint launcherTurretLV1BluePrint;
    public TurretBluePrint launcherTurretLV2BluePrint;
    public TurretBluePrint launcherTurretLV3BluePrint;
    public TurretBluePrint lazerTurretLV1BluePrint;
    public TurretBluePrint lazerTurretLV2BluePrint;
    public TurretBluePrint lazerTurretLV3BluePrint;




    private TurretBluePrint turretToBuild;
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void OnBasicTurretBtnClick(int level)
    {
        if (level == 1)
        {
            turretToBuild = basicTurretLV1BluePrint;

        }
        else if (level == 2)
        {
            turretToBuild = basicTurretLV2BluePrint;
        }
        else if (level == 3)
        {
            turretToBuild = basicTurretLV3BluePrint;
        }
    }

    public void OnLauncherTurretBtnClick(int level)
    {
        if (level == 1)
        {
            turretToBuild = launcherTurretLV1BluePrint;

        }
        else if (level == 2)
        {
            turretToBuild = launcherTurretLV2BluePrint;
        }
        else if (level == 3)
        {
            turretToBuild = launcherTurretLV3BluePrint;
        }
    }

    public void OnLazerTurretBtnClick(int level)
    {
        if (level == 1)
        {
            turretToBuild = lazerTurretLV1BluePrint;

        }
        if (level == 2)
        {
            turretToBuild = lazerTurretLV2BluePrint;

        }
        if (level == 3)
        {
            turretToBuild = lazerTurretLV3BluePrint;

        }
    }

    public void ClearTurretToBuild()
    {
        turretToBuild = null;
    }
}

[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefeb;
    public int price;

}
