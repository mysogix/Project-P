using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ArcLayoutGroup : MonoBehaviour
{
    public float radius = 100f;
    public float startAngle = 0f;
    public float endAngle = 180f;

    void OnValidate()
    {
        ArrangeChildren();
    }

   void ArrangeChildren()
   {
    int childCount = transform.childCount;
    if (childCount == 0) return;

    // Verhindere Division durch 0, wenn nur ein Item existiert
    float angleStep = (childCount > 1) ? (endAngle - startAngle) / (childCount - 1) : 0;

    for (int i = 0; i < childCount; i++)
    {
        float angle = startAngle + (angleStep * i);
        float rad = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(rad) * radius;
        float y = Mathf.Sin(rad) * radius;

            // Wenn nur ein Element vorhanden ist, wird es in der Mitte platziert
            if (childCount == 1)
            {
                x = 0;
                y = 500;
            }

            // Setze die Position für jedes Kind
            transform.GetChild(i).localPosition = new Vector3(x, y, 0);
    }
   }

}

