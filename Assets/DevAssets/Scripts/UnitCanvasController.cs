using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCanvasController : MonoBehaviour
{
    [SerializeField] Canvas unitCanvas = null;

    [SerializeField] Text notEnoughMoneyText = null;
    [SerializeField] Text upgradeCostText = null;

    private UnitUpgrade unitUpgrade = null;

    public void GetCurrentUnit (UnitUpgrade _unitUpgrade)
    {
        unitUpgrade = _unitUpgrade;
    }

    public void EnableUI(Vector3 currentUnitsPos)
    {
        upgradeCostText.text = unitUpgrade.unit.upgradeCost.ToString();
        notEnoughMoneyText.gameObject.SetActive(false);
        unitCanvas.gameObject.transform.position = new Vector3(currentUnitsPos.x, currentUnitsPos.y + 2f, currentUnitsPos.z);
        unitCanvas.gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        unitCanvas.gameObject.SetActive(false);
        notEnoughMoneyText.gameObject.SetActive(false);
    }

    public void TowerUpgrade ()
    {
        unitUpgrade.Upgrade();
    }

    public void DisplayNotEnoughMoney ()
    {
        notEnoughMoneyText.gameObject.SetActive(true);
    }

    private void Update()
    {
        unitCanvas.transform.LookAt(unitCanvas.transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
    }
}
