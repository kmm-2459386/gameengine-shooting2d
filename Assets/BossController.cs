using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : EnemyController
{
    public Transform bossTransform;
    public GameObject miniBardPrefab;
    public GameObject miniHeavyPrefab;
    public GameObject miniRiderPrefab;
    float span = 5.0f;
    float delta = 0;
    public float spawnRadius = 5f;
    public int numberOfEnemies = 10;

    public int damage = 90; // �v���C���[�ɗ^����_���[�W��
    protected override void Start()
    {
        maxHP = 1700f; // Boss �̍ő�HP
        base.Start();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);  // �v���C���[�Ƀ_���[�W��^����
            }
            
        }
    }
    void Update()
    {
        
        MiniBardSpawn();
        MiniHeavySpawn();
        MiniRiderSpawn();

        // ��ʊO�ɏo����I�u�W�F�N�g��j�󂷂�
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }
    void MiniBardSpawn()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            int px = Random.Range(-2, 2);
            GameObject go = Instantiate(miniBardPrefab);
            go.transform.position = new Vector3(transform.position.x + px, transform.position.y, 0);
            maxHP = 10f;
        }
    }
    void MiniHeavySpawn()
    {
        
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            int px = Random.Range(-2, 2);
            GameObject go = Instantiate(miniHeavyPrefab);
            go.transform.position = new Vector3(transform.position.x + px, transform.position.y, 0);
            maxHP = 10f;
        }
    }
    void MiniRiderSpawn()
    {
        
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            int px = Random.Range(-2, 2);
            GameObject go = Instantiate(miniRiderPrefab);
            go.transform.position = new Vector3(transform.position.x + px, transform.position.y, 0);
            maxHP = 10f;
        }
    }
    protected override void Die()
    {

        // Boss �̎��S����
        Destroy(gameObject);
        SceneManager.LoadScene("GameClearScene");

    }
}
