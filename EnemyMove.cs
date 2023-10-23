using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 2f;

    private Vector3 currentTarget;

    private void Start()
    {
        currentTarget = endPoint.position;
    }

    private void Update()
    {
        // Перемещение врага к текущей целевой точке
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Если враг достиг текущей целевой точки, меняем цель
        if (transform.position == currentTarget)
        {
            if (currentTarget == startPoint.position)
            {
                currentTarget = endPoint.position;
            }
            else
            {
                currentTarget = startPoint.position;
            }

            // Проверяем, достиг ли враг startPoint, и если достиг, меняем масштаб по оси X
            if (currentTarget == startPoint.position)
            {
                ChangeScaleX(1f);
            }
            else
            {
                ChangeScaleX(-1f);
            }
        }
    }

    private void ChangeScaleX(float scaleX)
    {
        Vector3 newScale = transform.localScale;
        newScale.x = scaleX;
        transform.localScale = newScale;
    }
}
