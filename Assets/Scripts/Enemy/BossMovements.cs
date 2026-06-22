using System.Collections;
using System.Reflection;
using UnityEngine;

public class BossMovements : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int frecuenceAttack;
    [SerializeField] private int attackToChoose;
    [SerializeField] private Transform[] posiciones = new Transform[3];
    //Ataque spawn rocas
    [SerializeField] private Transform[] posicionesSpawnRocas = new Transform[8];
    [SerializeField] private GameObject roca;
    [SerializeField] public Vector2 dir;
    [SerializeField] private bool turn;
    [SerializeField] private Rigidbody2D rB;
    [SerializeField] private ManageBossAnimations animations;
    public bool muerto;
    [SerializeField] private EnemyStats stats;


    public bool atacando;

    void FixedUpdate()
    {
        if(stats.currentHealth > 0)
        {
            Move();
        }
        if(stats.currentHealth <= 0)
        {
            Die();
        }
    }

    void Awake()
    {
        dir.x = 1;
        atacando = false;
        muerto = false;
    }

    void Move()
    {
        rB.AddForce(dir * speed);
        int posibilidad = Random.Range(0, 101);
        if(posibilidad == 100 && atacando == false)
        {
            Attack();
        }
        else
        {
            atacando = false;
        }
    }

    void Update()
    {
        CheckDir();
    }

    void Attack()
    {
        attackToChoose = Random.Range(1, 21);
        if(attackToChoose <= 19)
        {
            StartCoroutine(Punetazo());
        }
        else
        {
            StartCoroutine(AtaqueRocas());
        }
    }

    IEnumerator Punetazo()
    {
        atacando = true;
        yield return new WaitForSeconds(2f);
    }

    IEnumerator AtaqueRocas()
    {
        int numeroRocas = Random.Range(1, 11);
        for(int i = 0; i <= numeroRocas; i++)
        {
            int posRoca = Random.Range(0, posicionesSpawnRocas.Length);
            Instantiate(roca, posicionesSpawnRocas[posRoca].position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Walls")
        {
            dir.x *= -1;
            Teleport();
        }
    }

    void Die()
    {
        muerto = true;
        Animator anim = this.gameObject.GetComponent<Animator>();
        Destroy(anim);
        Destroy(this);
    }

    private void CheckDir()
    {
        if(dir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Teleport()
    {
        int posibilidad = Random.Range(0, 26);
        if(posibilidad == 25)
        {
            int position = Random.Range(0, 3);
            this.transform.position = posiciones[position].position;
        }
    }
}
