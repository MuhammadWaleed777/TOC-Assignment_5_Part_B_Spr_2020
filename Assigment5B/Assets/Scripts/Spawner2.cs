using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;

    private GameObject g;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLessWait;
    public int startWait;
    public bool stop;
    public static int countParenthesis = 0;
    static int token = 1;
    string langstr;
    private Vector3[] positionArray = new Vector3[10];
    int randEnemy;

    void Start()
    {
        langstr = "(m2)";
        cubes();
    }


    public void cubes()
    {
        for (int i = 0; i < 52; i++)
        {
            GameObject gameobject;
            Text textobj;
            randEnemy = Random.Range(0, 4);
            float x = Random.Range(-9, 9);
            float z = Random.Range(-9, 9);
            int checker = 0;
            string str = "";
            if (checker == 0)
            {
                Vector3 spawnPosition = new Vector3(x, 1, z);
                // for generating 33% correct language
                if (token % 3 == 0)
                {
                    str = countParenthesisthesiss();
                    countParenthesis = countParenthesis + 1;
                }
                else
                {
                    str = maliciouslang();
                }
                token = token + 1;
                gameobject = Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
                gameobject.GetComponent<Rotator>().x = str;
                gameobject.GetComponentInChildren<TextMesh>().text = str;
            }
        }
    }

    string maliciouslang()
    {

        string textstring = "";

        int len = Random.Range(9, 15);

        for (int m = 0; m < len; m++)
        {
            textstring = textstring + langstr[Random.Range(0, langstr.Length)];
        }


        return "x" + textstring;
    }

    string countParenthesisthesiss()
    {
        int parenCheck = 0;
        string textstring = "";
        int len = Random.Range(9, 15);

        for (int i = 0; i < len; i++)
        {
            char bracket = langstr[Random.Range(0, langstr.Length)];
            if (bracket == '(')
            {
                textstring = textstring + bracket;
                parenCheck = parenCheck + 1;
            }
            else
            {
                textstring = textstring + bracket;
            }

            else if (bracket == ')')
            {
                if (parenCheck > 0)
                {
                    textstring = textstring + bracket;
                    parenCheck = parenCheck - 1;
                }
                else
                {
                    bracket = langstr[Random.Range(0, langstr.Length - 1)];
                    if (bracket == '(')
                    {
                        textstring = textstring + bracket;
                        parenCheck = parenCheck + 1;
                    }
                    else
                    {
                        textstring = textstring + bracket;
                    }
                }
            }

        }
        if (parenCheck > 0)
        {
            for (int checker = parenCheck; checker > 0; checker--)
            {
                textstring = textstring + ')';
            }
        }
        return "x" + textstring;

    }

    public bool isbalnce(string s)
    {

        int parenCheck = 0;

        for (int i = 0; i < s.Length; i++)
        {
            char bracket = s[i];
            if (bracket == '(')
            {

                parenCheck = parenCheck + 1;
            }
            if (bracket == ')')
            {
                if (parenCheck == 0)
                {
                    return false;
                }
                parenCheck = parenCheck - 1;
            }
        }
        if (parenCheck == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int getcountParenthesis()
    {
        return countParenthesis;
    }
}
