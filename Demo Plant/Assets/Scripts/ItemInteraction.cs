using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public Vector3 offset;
    public GameObject player;
    //public GameObject field;
    //[SerializeField] PlayerInteract Player;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject g = GameObject.FindGameObjectWithTag(Camera);
        //Player = GetComponent<PlayerInteract>();
        //Player.inventory = Player.inventory;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && transform.parent != null) //&& Player.inventory == false)
        {
            transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Collider>().isTrigger = false;
            //Player.inventory = true;
        }
        if (transform.parent != null)
        {
            //Debug.Log("check1");
            //Debug.Log("Player's Parent: " + player.transform.parent.name);
            //Debug.Log("Player's Parent: " + transform.parent.name);
            if (transform.parent != null)
            {
                //Debug.Log("check2");
                transform.position = transform.parent.position +
                    transform.parent.transform.forward * offset.z +
                    transform.parent.transform.right * offset.x -
                    transform.parent.transform.up * offset.y;
            }
            
        }
    }
}
