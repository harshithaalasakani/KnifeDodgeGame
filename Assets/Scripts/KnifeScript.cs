using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    public bool moveRight;
    private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateAfterTime", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 temp = transform.position;

        if (moveRight)
        {
            temp.x += speed * Time.deltaTime;
        } else
        {
            temp.x -= speed * Time.deltaTime;
        }
        transform.position = temp;
    }

    void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
    }
}
