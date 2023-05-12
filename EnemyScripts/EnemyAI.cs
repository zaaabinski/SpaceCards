using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask Ground, IsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange, closeRange;
    public bool playerInSightRange, playerInAttackRange, playerCloseEnough;

    //atack
    public float attackSpeed=10;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public int dmg=10;

    //need to be set
    public GameObject playerObj;
    public GameObject canvasObj;
    public GameObject gameController;
    public GameObject healthBarObj;
    public PlayerHealth playerHealth;
    public CardsBuffs cardsBuffs;
    public ScoreScript scoreScript;
    public HealthBar healthBar;
    public SpawnEnemy spawnEnemy;
    bool atkp = true, isDead=false;
   
    public void Awake()
    {
        
        player = GameObject.Find("PlayerObject").transform;
        agent = GetComponent<NavMeshAgent>();
        
        playerObj = GameObject.Find("PlayerObject");
        playerHealth = playerObj.GetComponent<PlayerHealth>();
       
        canvasObj = GameObject.Find("PlayerUI");
        scoreScript = canvasObj.GetComponent<ScoreScript>();

        healthBarObj = GameObject.Find("HealthBar");
        healthBar = healthBarObj.GetComponent<HealthBar>();

        gameController = GameObject.Find("GameController");
        cardsBuffs = gameController.GetComponent<CardsBuffs>();
        spawnEnemy = gameController.GetComponent<SpawnEnemy>();
        


    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, IsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, IsPlayer);
        playerCloseEnough = Physics.CheckSphere(transform.position, closeRange, IsPlayer);
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if ((health <= 0) && (!isDead)) DestroyEnemy();//Invoke(nameof(DestroyEnemy), 0.05f);
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, Ground))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(player.position);
        //Make sure enemy doesn't move
        if (playerCloseEnough)
        {
        agent.SetDestination(transform.position);
        }
          
        Vector3 targetPoint;
        targetPoint = player.position;
        targetPoint.y += 0.5f;
        

        if ((!alreadyAttacked) && (atkp))
        {
            agent.SetDestination(transform.position);
            Vector3 bulletDirection = targetPoint - attackPoint1.position;
                GameObject enemyBullet = Instantiate(projectile, attackPoint1.position, Quaternion.identity);
                enemyBullet.GetComponent<Rigidbody>().AddForce(bulletDirection.normalized *attackSpeed, ForceMode.Impulse);
                atkp = false;
           
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

         if ((!alreadyAttacked)&&(!atkp))
        {
            agent.SetDestination(transform.position);
            Vector3 bulletDirection = targetPoint - attackPoint2.position;
                GameObject enemyBullet = Instantiate(projectile, attackPoint2.position, Quaternion.identity);
                enemyBullet.GetComponent<Rigidbody>().AddForce(bulletDirection.normalized * 10f, ForceMode.Impulse);
                atkp = true;
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if(cardsBuffs.DMG2)
            {
                TakeDamage(dmg*4);
            }
            else
            {
                TakeDamage(dmg);
            }
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void DestroyEnemy()
    {
        isDead = true;
        spawnEnemy.nrOfEn -= 1;
        if(cardsBuffs.canHeal2)
        {
            playerHealth.currentHealth += 2;
            healthBar.SetHealth(playerHealth.currentHealth);
            scoreScript.score += 100;
            Destroy(gameObject);
        }
        else
        {
            scoreScript.score += 100;
        Destroy(gameObject);
        }

    }

   
}
