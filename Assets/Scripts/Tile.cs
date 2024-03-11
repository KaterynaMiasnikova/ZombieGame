using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Trigger event is generated as long as the zombie
        //collides with a tile
        gm.AddPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
