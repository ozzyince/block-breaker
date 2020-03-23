using System.Linq;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float screenWidthInUnits;
    private float minx;
    private float maxx;

    // Start is called before the first frame update
    void Start()
    {
        var xs = GetComponent<PolygonCollider2D>().points.Select(p => p.x);
        var sprite = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().sprite;
        screenWidthInUnits = sprite.rect.max.x / sprite.pixelsPerUnit;
        minx = -xs.Min() * transform.localScale.x;
        maxx = screenWidthInUnits - xs.Max() * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minx, maxx), transform.position.y);
    }
}
