using UnityEngine;

//public enum Color
//{
//    WHITE = 1,
//    CYAN,
//    YELLOW,
//    GREEN,
//    RED,
//    BLUE,
//    PURPLE,
//    BLACK
//}
//public enum Ability
//{
//    LARGESPLIT, // attached to leaf; does: splits into 2 sappling slimes
//    SMALLSPLIT, // attached to sappling; does: splits into 2 slime_3
//    BESERK, // attatched to viking; does: aoe speed and whatver tank does to lesser extent
//    SPEED, // attached to rabbit; does: make faster
//    TANK, //attached to helmet; does: take certain amount (2x?) of damage before losing helmet
//    KING, // attacthed to king; does: ??
//    DEFAULT // attached to base normal slime and slime_3; does: nothing
//}
public class EnemyScript : MonoBehaviour
{

    public float health;
    public AudioSource Death;
    // types of slimes 
    //public Enemy NormalSlime = new Enemy("Normal_slime", 3, Color.WHITE, Ability.DEFAULT);
    //public Enemy HelmetSlime = new Enemy("Helmet_slime", 3, Color.WHITE, Ability.DEFAULT);
    //public Enemy RabbitSlime = new Enemy("Rabbit_slime", 3, Color.WHITE, Ability.DEFAULT);
    //public Enemy LeafSlime = new Enemy("Leaf_slime", 3, Color.WHITE, Ability.DEFAULT);
    //public Enemy SapplingSlime = new Enemy("Sappling_slime", 3, Color.WHITE, Ability.DEFAULT);
    //public Enemy Slime3 = new Enemy("Slime_03", 3, Color.WHITE, Ability.DEFAULT);
    //public Enemy VikingSlime = new Enemy("Viking_slime", 3, Color.WHITE, Ability.DEFAULT);
    //public Enemy KingSlime = new Enemy("King_slime", 3, Color.WHITE, Ability.DEFAULT);

    // Used to set dead, so other enemies do not target if this enemy is about to die.
    public bool isDead = false;

    // Start is called before the first frame update
    void Awake()
    {
        Death = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Die();
    }

    // Made it a method, so in the future we can add animations here
    public void Die()
    {
        Destroy(gameObject);
        Death.Play();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    // Prevents die from being called twice which was a previous bug
    void OnDestroy()
    {
        GameManager.money += GameManager.moneyPerKill;
        --WaveManager.enemies;
        GameOver.EnemiesKilled++;
        
    }

}
//public class Enemy
//{
//    public float health, speed;
//    public string name;
//    public Ability ability;
//    public Color color;
//    public Enemy (string name, float speed, Color color, Ability ability)
//    {
//        health = 2 * (int)color;
//        this.name = name;
//        this.speed = speed;
//        this.ability = ability;
//        this.color = color;

//    }
//}
