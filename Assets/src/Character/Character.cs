using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]private string characterName = string.Empty;
    [SerializeField]private float health = 1.0f;
    [SerializeField]private float maxHealth = 1.0f;
    [SerializeField]private int age;
    [SerializeField]private Inventory inventory;
    [SerializeField]private int InventorySize = 10;
    [SerializeField]bool isAlive = true;

    Vector2 currentTile;
    Vector2 targetTile;

    void Start()
    {
        characterName = "Character Name";
        age = 0;
        health = 100;
        maxHealth = 100;
        isAlive = true;
    }

    void Update()
    {
        transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
    }
}
