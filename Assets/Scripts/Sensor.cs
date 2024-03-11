using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public GameManager gm;
    public List<GameObject> zombies, zombieStarters;
    public AudioSource fallScream;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Trigger event is generated as long as the zombie collides with a tile
    private void OnTriggerEnter(Collider other)
    {
        gm.DecreaseLives();
        fallScream.PlayOneShot(clip);
        if (gm.GetLives() > 0)
        {
            if (other.gameObject.tag == "YellowTag")
            {
                other.gameObject.transform.position = zombieStarters[0].transform.position;
            }
            else if (other.gameObject.tag == "BlueTag")
            {
                other.gameObject.transform.position = zombieStarters[1].transform.position;
            }
            else if (other.gameObject.tag == "GreenTag")
            {
                other.gameObject.transform.position = zombieStarters[2].transform.position;
            }
            else if (other.gameObject.tag == "RedTag")
            {
                other.gameObject.transform.position = zombieStarters[3].transform.position;
            }
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
