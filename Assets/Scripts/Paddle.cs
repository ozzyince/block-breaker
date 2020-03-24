using System.Linq;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private float screenWidthInUnits;
    private float minx;
    private float maxx;

    private GameSession session;
    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        session = FindObjectOfType<GameSession>();
        ball = FindObjectOfType<Ball>();
        var xs = GetComponent<PolygonCollider2D>().points.Select(p => p.x);
        var sprite = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().sprite;
        screenWidthInUnits = sprite.rect.max.x / sprite.pixelsPerUnit;
        minx = -xs.Min() * transform.localScale.x;
        maxx = screenWidthInUnits - xs.Max() * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(GetPosX(), minx, maxx), transform.position.y);
    }

    private float GetPosX()
    {
        if (session.isAutoPlay())
            return ball.transform.position.x;
        else
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
}
