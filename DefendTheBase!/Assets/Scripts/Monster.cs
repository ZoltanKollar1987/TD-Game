using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    public void Spawn()
    {
        transform.position = GameManager.Instance.portal.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Base")
        {
            Destroy(this.gameObject);
            GameManager.Instance.RemoveMonster(this);
        }
    }
}
