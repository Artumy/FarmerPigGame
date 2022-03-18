using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] public List<Enemy> enemyList = new List<Enemy>();
    [SerializeField] public GameObject win;

    void Update()
    {
        foreach (Enemy enemy in enemyList)
        {
            if (enemy == null) enemyList.Remove(enemy);
        }
        if(enemyList.Count == 0) win.SetActive(true);
    }
}
