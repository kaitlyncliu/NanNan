using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxChapter2 : MonoBehaviour
{
    private float length, startpos;
    private float startposY;
    public GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = cam.transform.position.x * (1 - parallaxEffect);
        float dist = cam.transform.position.x * parallaxEffect;
        float distY = cam.transform.position.y * parallaxEffect;
        transform.position = new Vector3(startpos + dist,
                                         startposY + distY,
                                         transform.position.z);

        //infinite scrolling
        /*if (temp > startpos + length){
            startpos += length;
        } else if (temp < startpos - length) {
            startpos -= length;
        }*/
    }
}
