using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] int pointsForCrops = 1;

    public int damage;
    public float shootRange = 5.0f;
    public GameObject player;
    public GameObject food;
    //public bool inventory = true;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Interact();

        }
        if (Input.GetButtonDown("Fire3"))
        {
            Harvest();
        }
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    Sit();
        //}
        //if(inventory == true)
        //{
        //    Debug.Log("true");
        //}
    }

    void Interact()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 3);
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.GetComponent<ItemInteraction>() != null) //&& inventory == true)
            {
                //float XScale = Mathf.Abs(hit.transform.localScale.x = 1f);
                //float YScale = Mathf.Abs(hit.transform.localScale.y = 1f);
                //float ZScale = Mathf.Abs(hit.transform.localScale.z = 1f);
                hit.transform.parent = gameObject.transform;
                hit.transform.gameObject.GetComponent<Rigidbody>().useGravity = false;
                hit.transform.gameObject.GetComponent<Collider>().isTrigger = true;
                //inventory = false;
                //hit.transform.gameObject.transform.localScale = new Vector3(XScale, YScale, ZScale);
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, shootRange);
        if (hit.transform != null)
        {
            //Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.GetComponent<WeedHealth>() != null)
            {
                hit.transform.gameObject.GetComponent<WeedHealth>().ReduceHP(damage);
            }

            else if (hit.transform.gameObject.GetComponent<Seat>() != null)
            {

                //transform.parent.transform.position = hit.transform.gameObject.transform.position;
                //hit.transform.gameObject.transform.forward * offset.z;
                transform.position = hit.transform.gameObject.transform.position -
                    transform.gameObject.transform.forward * offset.z;
            }
        }
    }

    void Harvest()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, shootRange);
        if (hit.transform != null)
        {
            //Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.GetComponent<FoodCollection>() != null)
            {
                food = player.transform.GetChild(1).gameObject;
                //Debug.Log(player.transform.GetChild(0));
                DestroyImmediate(food);
                Debug.Log("+1 point");
                FindObjectOfType<ScoreText>().AddToScore(pointsForCrops);
                
            }
        }
    }

    void Sit()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, shootRange);
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.GetComponent<Seat>() !=null)
            {

                transform.parent.transform.position = hit.transform.gameObject.transform.position;
                    //hit.transform.gameObject.transform.forward * offset.z;
                transform.position = hit.transform.gameObject.transform.position -
                    transform.parent.transform.forward * offset.z;
            }
        }
    }
}
