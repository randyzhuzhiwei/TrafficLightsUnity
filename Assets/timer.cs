using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        StartCoroutine("TrafficLights");
        m_Material.color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_Material.color == Color.red)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
            int i = 0;
            if (hitColliders.Length > 1)
            {
                while (i < hitColliders.Length)
                {
                    if(hitColliders[i].gameObject.tag=="cars")
                    {
                        hitColliders[i].gameObject.GetComponent<move>().canMove = false;
                    }
                    i++;
                }
            }
        }
        else
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
            int i = 0;
            if (hitColliders.Length > 1)
            {
                while (i < hitColliders.Length)
                {
                    if (hitColliders[i].gameObject.tag == "cars")
                    {
                        hitColliders[i].gameObject.GetComponent<move>().canMove = true;
                    }
                    i++;
                }
            }
        }

    }
     IEnumerator TrafficLights()
    {
        while (true)
        {
            if (m_Material.color == Color.red)
            {
                m_Material.color = Color.green;
            }else
            {
                m_Material.color = Color.red;
            }
            yield return new WaitForSeconds(5f);
        }
    }
}