using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;

    [SerializeField]
    private int damage;

    [SerializeField]
    private string projectileType;

    [SerializeField]
    private float projectileSpeed;


    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
    }

    private Monster target;

    public Monster Target
    {
        get { return target; }
    }

    public int Damage 
    {
        get 
        {
            return damage;
        }
        
    }

    private Queue<Monster> monsters = new Queue<Monster>();

    private bool canAttack = true;

    private float attackTimer;

    [SerializeField]
    private float attackCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Debug.Log(target);
    }

    public void Select()
    {
        mySpriteRenderer.enabled = !mySpriteRenderer.enabled;
    }

    private void Attack()
    {
        if (!canAttack)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCoolDown)
            {
                canAttack = true;
                attackTimer = 0;
            }
        }

        if (target == null && monsters.Count > 0)
        {
            target = monsters.Dequeue();
        }

        if (target != null && target.IsActive)
        {
            if (canAttack)
            {
                Shoot();

                canAttack = false;

            }           
        }
    }

    private void Shoot()
    {
        Projectile projectile = GameManager.Instance.Pool.GetObject(projectileType).GetComponent<Projectile>();
        projectile.transform.position = transform.position;
        projectile.Initialize(this);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            monsters.Enqueue(collision.GetComponent<Monster>());
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            target = null;
        }
    }
}
