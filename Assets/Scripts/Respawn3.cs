using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn3 : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform spawnPoint;
    public AudioSource moveSFX;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = spawnPoint.position;
            moveSFX.Play();

        }
    }

}
