using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private void Awake()
    {
        The.gameLogic = this;
    }
}
