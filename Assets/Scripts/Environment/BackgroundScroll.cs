using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackgroundLevel
{
    NULL = 0,
    FOREST = 1,
    LAKE = 2,
    CASTLE = 3
}

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.25f;
    private Renderer rend;
    public BackgroundLevel level;

    public Material[] materials;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
       switch (level)
        {
            case BackgroundLevel.NULL:
                break;
            case BackgroundLevel.FOREST:
                rend.material = materials[0];
                break;
            case BackgroundLevel.LAKE:
                rend.material = materials[1];
                break;
            case BackgroundLevel.CASTLE:
                rend.material = materials[2];
                break;
        }
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }

}
