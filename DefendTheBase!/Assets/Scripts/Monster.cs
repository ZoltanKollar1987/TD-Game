using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private Stat healt;

    public bool IsActive;

    private void Awake()
    {
        healt.Initialize();
    }

    public void Spawn(int healt)
    {
        

        this.healt.MaxVal = healt;
        this.healt.CurrentValue = this.healt.MaxVal;
        IsActive = true;
        transform.position = GameManager.Instance.portal.transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Base")
        {
            Destroy(this.gameObject);
            IsActive = false;
            GameManager.Instance.RemoveMonster(this);
            GameManager.Instance.Healt--;
            
        }
    }

    public void TakeDamage(int damage)
    {
        if (IsActive)
        {
            healt.CurrentValue -= damage;

            if (healt.CurrentValue <=0)
            {
                GameManager.Instance.RemoveMonster(this);
                GameManager.Instance.Currency += 2;
                Destroy(this.gameObject);                
                               
            }

            
        }       
    }
}
