using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create EnemyDataSO", fileName = "EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public List<EnemyData> enemyDatasList = new();
}