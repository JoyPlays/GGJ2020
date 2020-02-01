using UnityEngine;
using Ugitty.Variables;
using Ugitty.Events;
using Ugitty.Components;

public class UnitUpgrade : MonoBehaviour
{
    public IntVariable payerFunds;
    public Unit unit;

    public GameAction successfulAction;
    public GameAction failedAction;

    [SerializeField] UnitCanvasController uCC = null;

    public void Upgrade()
    {
        if (payerFunds == null || unit == null)
        {
            Debug.LogError("Cannot upgrade " + this.name + " missing UnitUpgrade configuration.");
            uCC.DisplayNotEnoughMoney();
            return;
        }

        if (payerFunds.Value > unit.upgradeCost)
        {
            payerFunds.ApplyChange(-unit.upgradeCost);
            
            if (successfulAction == null)
            {
                Debug.LogWarning("Upgrade for " + this.name + " was successful but action did not fire. Forgot to add action?");
                return;
            }

            GameObjectReplace.Replace(gameObject, unit.upgrade);

            successfulAction.Raise();

            uCC.DisableUI();

            return;
        }

        if (failedAction == null)
        {
            Debug.LogWarning("Upgrade for " + this.name + " was successful but events did not fire. Forgot to add actions?");
            return;
        }

        failedAction.Raise();
        return;
    }
}
