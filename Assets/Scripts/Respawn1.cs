using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Respawn1 : MonoBehaviour
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
