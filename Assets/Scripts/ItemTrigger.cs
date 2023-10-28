using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{

    [Range(0, 100)]
    public float rotateSpd = 20f;
    public Vector3 RotateDirection = new Vector3(0, 1, 0);
    public string itemType;
    public AudioSource itemSFX;

    private void Update()
    {
        transform.Rotate(RotateDirection * rotateSpd * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(itemType =="coin")
            {
                UserData.coinCount++;
                itemSFX.Play();
            }

            if (itemType == "potion")
            {
                UserData.pointCount++;
                itemSFX.Play();
            }
               
            if(itemType =="key")
            {
                UserData.keyCount++;
                itemSFX.Play();
            }

            if (itemType == "cake")
            {
                UserData.cakeCount++;
                itemSFX.Play();
            } 
            if (itemType == "gift")
            {
                UserData.giftCount++;
                itemSFX.Play();
            }
                
            if (itemType == "candy")
            {
                UserData.candyCount++;
                itemSFX.Play();
            }
                
            GameManager.Instance.ItemRefresh();

            Destroy(gameObject);
        }
            
    }
}
