using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyRandomMove : MonoBehaviour
{
    [SerializeField]
    float moveChance = 0.1f;

    [SerializeField]
    float minSpeed = 0.5f;

    [SerializeField]
    float maxSpeed = 1.5f;

    [SerializeField]
    int maxSingleDestinationDistance = 30;
    Vector2 destination;

    SpriteRenderer sr;

    Coroutine restoreDefaultColorCoroutine;


    private void Start()
    {
        destination = (Vector2)transform.position;
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        return;
        if ((Vector2)transform.position != destination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, Random.Range(minSpeed, maxSpeed) * Time.deltaTime);
        }
        else if (Random.value > (1 - moveChance))
        {
            destination = GetTargetDestination();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.tag == "Enemy")
        {
            if (restoreDefaultColorCoroutine != null)
            {
                StopCoroutine(restoreDefaultColorCoroutine);
            }
            destination = GetTargetDestination();
            if (sr != null)
            {

            }
            SetColor(new Color32(255, 0, 0, 255));
            restoreDefaultColorCoroutine = StartCoroutine(RestoreDefaultColor());
        }
    }

    private void SetColor(Color32 color)
    {
        if (sr != null)
        {
            sr.color = color;
        }
    }

    IEnumerator RestoreDefaultColor()
    {
        yield return new WaitForSeconds(1f);
        SetColor(new Color32(50, 150, 150, 255));
    }



    Vector2 GetTargetDestination()
    {
        Vector2 newDestination = new Vector2(transform.position.x + Random.Range(-maxSingleDestinationDistance, maxSingleDestinationDistance),
        transform.position.y + Random.Range(-maxSingleDestinationDistance, maxSingleDestinationDistance));
        return newDestination;
    }
}
