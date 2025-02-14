using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovementExample : MonoBehaviour
{
    public Sprite N;
    public Sprite R;
    private float speed = 25f;
    private bool BattlePhase = false;
    public GameObject target;
    public float distance;

    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Input.GetKeyDown("space"))
        {
            BattlePhase = true;
        }
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (BattlePhase)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = R;
        }
        if (distance < 10f)
        {
            speed = 0.1f;
        }
        if (distance < 3f)
        {
            speed = 0f;
        }
    }
}
