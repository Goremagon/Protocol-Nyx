using UnityEngine;

public class DefenseManager : MonoBehaviour
{
    // A link back to the main ship
    public Ship shipController; 

    [Header("Combat Strength")]
    public float defenseCorpsPower = 5f; 
    public float enemyBoarderPower = 4f; 

    void Start()
    {
        if (shipController == null)
        {
            shipController = GetComponent<Ship>();
        }
    }

    public void HandleBoardingAttack(int enemyCount)
    {
        Debug.Log($"Boarding Attack! Enemies: {enemyCount}");
    }
}