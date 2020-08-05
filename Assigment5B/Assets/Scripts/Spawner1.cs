
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Spawner1 : MonoBehaviour
{
    public GameObject[] enemies;

    private GameObject g;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLessWait;
    public int startWait;
    public bool stop;
    public static int palindrome= 0;
    int randEnemy;

    void Start()
    {
		
        add();
    }
   
   
    public void add()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject gameobject;
            

            randEnemy = Random.Range(0, 10);
            float x = Random.Range(-9, 9);
            float z = Random.Range(-9, 9);
            Vector3 spawnPosition = new Vector3(x, 0, z);
        
            int r = Random.Range(0, 2);
            int sizeofText  = Random.Range(9, 15);
            string randomdata  = "";
            if (r == 0)
            {
               
                 randomdata  = "" + RandomString(sizeofText );
            }
            else
            {
                palindrome = palindrome + 1;
                randomdata  = "" + randpalindrom(sizeofText );
            }
            gameobject = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            gameobject.GetComponent<Rotator>().x = randomdata ;
            
            g = gameobject;

            g.GetComponentInChildren<TextMesh>().text = randomdata ;

        }

    }
	 public string randpalindrom(int len )
    {

        char[] ch = new char[len ];
        ch[0] = 'x';
        ch[len  - 1] = 'x';
        int maxLen = len  - 2;
        
        for (int i = 1; i < len ; i++)
        {
            int rnd = Random.Range(0, 2);
            if (rnd == 0)
            {
                ch[i] = 'M';
                ch[maxLen] = 'M';
            }
            else
            {
                ch[i] = '2';
                ch[maxLen] = '2';

            }
            maxLen--;
            if (maxLen <= i)
            {
                break;
            }
        }

        return new string(ch);
    }
    private string RandomString(int length )
    {

        string _chars = "xM2";
        char[] buffer = new char[length ];

        for (int i = 0; i < length ; i++)
        {
            buffer[i] = _chars[Random.Range(0, 3)];
        }
        return new string(buffer);
    }
    public void remove(GameObject obj, string name)
    {
        obj.SetActive(false);
        Destroy(obj);
    }
   
    public bool check(string a)
    {
        string strDummy  = "";

        int n = a.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            strDummy  = strDummy  + a[i];
        }
        if (a.Equals(strDummy ))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int getPlain()
    {
        
        return palindrome;
    }
}