using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    public Material material;
    public float xVel = 0.5f;
    Vector2 offset;
    public static bool EndGame = false;
    
    void Start()
    {
        material = GetComponent<Renderer>().material;
        EndGame = false;
    }

    void Update()
    {
        if (EndGame == false)
        {
            offset = new Vector2(xVel, 0);
            material.mainTextureOffset += offset * Time.deltaTime;
        }
    }
}
