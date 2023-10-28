using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicChange : MonoBehaviour
{
    private AudioSource theAudio;
    [SerializeField] private AudioClip[] clip;

    // Start is called before the first frame update
    void Start()
    {
        theAudio = GetComponent<AudioSource>();

    }

    public void PlaySE()
    {
        //int[] randomArray = GenerateRandomArray(0, clip.Length - 1, clip.Length);
        //foreach (int num in randomArray)
        //{
        //    theAudio.clip = clip[num];
        //    theAudio.Play();
        //    Debug.Log(num);
        //}

        int _temp = Random.Range(0, 4);

        theAudio.clip = clip[_temp];
        theAudio.Play();
        //Debug.Log(_temp);

    }

    //���� �ߺ��Լ� ����
    static int[] GenerateRandomArray(int minNumber, int maxNumber, int arraySize)
    {
        if (maxNumber - minNumber + 1 < arraySize)
        {
            throw new ArgumentException("�迭 ũ�Ⱑ �������� Ů�ϴ�.");
        }

        int[] randomArray = new int[arraySize];
        System.Random random = new System.Random();

        // �迭 �ʱ�ȭ
        for (int i = 0; i < arraySize; i++)
        {
            randomArray[i] = i + minNumber;
        }

        // Fisher-Yates ���� �˰����� ����Ͽ� �迭 ����
        for (int i = arraySize - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            int temp = randomArray[i];
            randomArray[i] = randomArray[j];
            randomArray[j] = temp;
        }

        return randomArray;
    }




}








