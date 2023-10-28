using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject popupBtn, itemWindow ,miniMap ,map,jukeBox;
    public TextMeshProUGUI coinCnt, potionCnt, keyCnt,candyCnt , cakeCnt, giftCnt;
    public bool isMapOpen = false;

    private void Awake()
    {
        Instance = this;
        popupBtn.SetActive(true);
        itemWindow.SetActive(false);
        miniMap.SetActive(true);
        map.SetActive(false);
        jukeBox.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            popupBtn.SetActive(!popupBtn.activeInHierarchy);
            itemWindow.SetActive(!itemWindow.activeInHierarchy);  //�ķ������� �ݰ� ���������� ����.
            ItemRefresh(); //â�� �������� ������ ���� UI����
        }
        if(Input .GetKeyDown(KeyCode.M))
        {
            miniMap.SetActive(!miniMap.activeInHierarchy);
            map.SetActive(!miniMap.activeInHierarchy);
            isMapOpen = miniMap.activeInHierarchy;
        }

        if(Input .GetKeyDown(KeyCode.J))
        {
            jukeBox.SetActive(!jukeBox.activeInHierarchy);

        }
    }

    public void ItemRefresh()
    {
        if(!itemWindow.activeInHierarchy)//������ â�� ���������� �Ʒ� ���� �ν��ϰ� ����
        {
            return;
        }
            coinCnt.text = UserData.coinCount.ToString("D2"); // ������ ���ڿ� ���ڸ��� �ٲٴ� ���1
            potionCnt.text = $"{UserData.pointCount:00}";  // ������ ���ڿ� ���ڸ��� �ٲٴ� ���2
            keyCnt.text = UserData.keyCount.ToString("D2"); // ������ ���ڿ� ���ڸ��� �ٲٴ� ���3
            candyCnt.text = UserData.candyCount.ToString("D2");
            cakeCnt.text = UserData.cakeCount.ToString("D2");
            giftCnt.text = UserData.giftCount.ToString("D2");
            

           //$"{ù��°����:00} :{�ι�° ����:00} : {����°����:00}"
           //string.Format("{0:00}:{1:00} : {2:00}" ,0�� ����,1�� ����,3�� ����)
           //�����Ѱ� ToString()����,�����ϰ� ���� ������ ����$""�� ���°� ����.
    }
}
