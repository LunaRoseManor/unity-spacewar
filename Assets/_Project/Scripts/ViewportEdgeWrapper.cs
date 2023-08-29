using UnityEngine;

public class ViewportEdgeWrapper : MonoBehaviour
{
    private void Update()
    {
        // Horizontal wrapping
        if (transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 0.0f)).x)
        {
            transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector2(0.0f, 0.0f)).x, transform.position.y);
        }
        else if (transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(0.0f, 0.0f)).x) // Viewport works on a 0.0f to 1.0f scale
        {
            transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector2(1.0f, 0.0f)).x, transform.position.y);
        }
        
        // Vertical wrapping
        if (transform.position.y > Camera.main.ViewportToWorldPoint(new Vector2(0.0f, 1.0f)).y)
        {
            transform.position = new Vector2(transform.position.x, Camera.main.ViewportToWorldPoint(new Vector2(0.0f, 0.0f)).y);
        }
        else if (transform.position.y < Camera.main.ViewportToWorldPoint(new (0.0f, 0.0f)).y)
        {
            transform.position = new Vector2(transform.position.x, Camera.main.ViewportToWorldPoint(new Vector2(0.0f, 1.0f)).y);
        }
    }
}
