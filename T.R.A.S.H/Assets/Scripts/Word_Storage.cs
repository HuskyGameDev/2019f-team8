using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word_Storage : MonoBehaviour
{
    public string word;
    // Start is called before the first frame update
    void Start()
    {
        word = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(word.Contains("heal"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Hobo_Health>().heal();
        }
        if(word.Contains("block"))
        {
            StartCoroutine(block());
        }
    }

    public void addLetter(char letter)
    {
        word = word + letter;
    }

    public IEnumerator block()
    {
        GameObject.FindGameObjectWithTag("Cannon").GetComponent<Crane_Projectile>().changeSpeed(1000f);
        yield return new WaitForSeconds(5);
        GameObject.FindGameObjectWithTag("Cannon").GetComponent<Crane_Projectile>().changeSpeed(.25f);
    }
}
