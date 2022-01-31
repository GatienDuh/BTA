using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    public int attackDamages = 1;

    public int Life;
    public int LifeMax;
    //public bool IsDead = false;

    public Image LifePercent;

    [SerializeField] private float attackRange = 5.0f;
    public Transform attackPoint;
    public bool isAttacking = false;
    public LayerMask enemyLayers;
    public LayerMask CaCEnemyLayers;

    private Animator anim;
    private float nextFireTime = 0f;
    private int noOfClicks = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.8f;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float percent = (float)Life / (float)LifeMax;
        LifePercent.fillAmount = percent;

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            anim.SetBool("hit1", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            anim.SetBool("hit2", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.5f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            anim.SetBool("hit3", false);
            noOfClicks = 0;
        }

        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
        
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        if (isAttacking == true)
        {
            characterController.Move(new Vector3(0, 0, 0));
        }

        if (noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            anim.SetBool("hit1", false);
            anim.SetBool("hit2", true);
            Attack2();
        }

        if (noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.4f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            anim.SetBool("hit2", false);
            anim.SetBool("hit3", true);
            Attack3();
        }

        if (Life <= 0)
        {
            characterController.Move(new Vector3(0, 0, 0));
            
            anim.SetBool("Dead", true);
            
            Destroy(gameObject, 1f);
        }
    }

    void OnClick()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        //Debug.Log(noOfClicks + "Clicks");

        if (noOfClicks == 1)
        {
            anim.SetBool("hit1", true);
            Attack1();
        }
    }

    void Attack1()
    {
        StartCoroutine(AttackAnimation1());
        StartCoroutine(CaCAttackAnimation1());
    }

    void Attack2()
    {
        StartCoroutine(AttackAnimation2());
        StartCoroutine(CaCAttackAnimation2());
    }

    void Attack3()
    {
        StartCoroutine(AttackAnimation3());
        StartCoroutine(CaCAttackAnimation3());
    }

    IEnumerator AttackAnimation1()
    {
        isAttacking = true;

        yield return new WaitForSeconds(0.7f);

        Collider[] Enemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        if (Enemies.Length != 0)
        {
            foreach (Collider enemy in Enemies)
            {
                //enemy.GetComponent<Animator>().SetTrigger("Hurt");
                enemy.GetComponent<Monster>().health -= attackDamages;
                Debug.Log("Attack1");
            }
        }
        
        yield return new WaitForSeconds(0.1f);

        isAttacking = false;
    }

    IEnumerator CaCAttackAnimation1()
    {
        yield return new WaitForSeconds(0.7f);

        Collider[] CacEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, CaCEnemyLayers);

        if (CacEnemies.Length != 0)
        {
            foreach (Collider enemy in CacEnemies)
            {
                //enemy.GetComponent<Animator>().SetTrigger("Hurt");
                enemy.GetComponent<CaCMonster>().health -= attackDamages;
                Debug.Log("Attack1Cac");
            }
        }
            

        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator AttackAnimation2()
    {
        isAttacking = true;

        yield return new WaitForSeconds(0.7f);

        Collider[] Enemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        if (Enemies.Length != 0)
        {
            foreach (Collider enemy in Enemies)
            {
                //enemy.GetComponent<Animator>().SetTrigger("Hurt");
                enemy.GetComponent<Monster>().health -= attackDamages;
                Debug.Log("Attack1");
            }
        }

        yield return new WaitForSeconds(0.1f);

        isAttacking = false;
    }

    IEnumerator CaCAttackAnimation2()
    {
        yield return new WaitForSeconds(0.7f);

        Collider[] CacEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, CaCEnemyLayers);

        if (CacEnemies.Length != 0)
        {
            foreach (Collider enemy in CacEnemies)
            {
                //enemy.GetComponent<Animator>().SetTrigger("Hurt");
                enemy.GetComponent<CaCMonster>().health -= attackDamages;
                Debug.Log("Attack1Cac");
            }
        }

        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator AttackAnimation3()
    {
        isAttacking = true;

        yield return new WaitForSeconds(1f);

        Collider[] Enemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        if (Enemies.Length != 0)
        {
            foreach (Collider enemy in Enemies)
            {
                //enemy.GetComponent<Animator>().SetTrigger("Hurt");
                enemy.GetComponent<Monster>().health -= attackDamages;
                Debug.Log("Attack1");
            }
        }

        yield return new WaitForSeconds(0.5f);

        isAttacking = false;
    }

    IEnumerator CaCAttackAnimation3()
    {
        yield return new WaitForSeconds(1f);

        Collider[] CacEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, CaCEnemyLayers);

        if (CacEnemies.Length != 0)
        {
            foreach (Collider enemy in CacEnemies)
            {
                //enemy.GetComponent<Animator>().SetTrigger("Hurt");
                enemy.GetComponent<CaCMonster>().health -= attackDamages;
                Debug.Log("Attack1Cac");
            }
        }

        yield return new WaitForSeconds(0.5f);
    }


    //#Gizmos Hitbox
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}