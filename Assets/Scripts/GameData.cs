using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string EnemyHP;
    public string PlayerHP;

    public GameData(string enemy, string player)
    {
        this.EnemyHP = enemy;
        this.PlayerHP = player;
    }
}
