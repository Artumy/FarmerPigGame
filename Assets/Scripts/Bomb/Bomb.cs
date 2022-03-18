using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] public GameObject bomb;
    [SerializeField] public BombsPool pool;

    private GameObject b;

    public void Spawn(Transform pos)
    {
        if(pool.bombsCount < 1)
        {
            pool.bombsCount++;
            b = Instantiate(bomb, pos.position, Quaternion.identity);
            Invoke("DestroyBomb", 2f);
        }
    }

    private void DestroyBomb()
    {
        Destroy(b);
        pool.bombsCount--;
    }

    //private void OnTriggerEnter2D(Collider2D collider2D)
    //{
    //    if(collider2D.TryGetComponent(out Enemy enemy))
    //    {
    //        DestroyBomb();
    //    }
    //}
}
