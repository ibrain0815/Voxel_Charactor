using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform spawnPoint;
    public AudioSource gateSFX;

    private void Awake()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            SpawnPlayer();
        }
    }


    private void SpawnPlayer()
    {
        var player = Instantiate(prefabs[UserData.charIndex], spawnPoint.position, spawnPoint.rotation);
        gateSFX.Play();

        //DontDestroyOnLoad(player);
        //player.SetActive(true);
       
    }

    

}
