using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject deadEffectObj;
    public GameObject itemEffectObj;

    Rigidbody2D rb;
    float angle = 0;

    int xSpeed = 3;
    int ySpeed = 30;

    GameManager gameManager;

    bool isDead = false;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true) return;

        MovePlayer();
        GetInput();
    }

    void MovePlayer()
    {
        //создание движения шарика под определённым углом 
        //относительно его движения по плоскости x

        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 3;
        //pos.y = 0;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }

    void GetInput()
    {
        if (Input.GetMouseButton(0))
        {
            
            //Debug.Log("GetMouseButton");
            rb.AddForce(new Vector2(0, ySpeed));
            //Debug.Log("rb.velocity : " + rb.velocity);
            
        } else
        {
            if (rb.velocity.y > 0)
            {
                //Debug.Log("NOT GetMouseButton");
                rb.AddForce(new Vector2(0, -ySpeed));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Dead();
        } 
        else if(other.gameObject.tag == "item")
        {
            Debug.Log("Score + 1");
            GetItem(other);
            //gameManager.AddScore();
        }
       
    }

    void GetItem(Collider2D other)
    {
        Destroy(Instantiate(itemEffectObj, other.gameObject.transform.position, Quaternion.identity), 0.5f);
        Destroy(other.gameObject.transform.parent.gameObject); 
        gameManager.AddScore();
    }

    void Dead()
    {
        isDead = true;

        //Instantiate позволяет создавать объекты в определённом месте при помощи скрипта
        Destroy(Instantiate(deadEffectObj, transform.position, Quaternion.identity), 0.3f);
        //Quaternion(кватерионы) использую для хаотичного вращения частиц 

        StopPlayer();

        gameManager.CallGameOver();
    }

    void StopPlayer()
    {
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
    }
}

