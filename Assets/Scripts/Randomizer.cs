using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Randomizer : MonoBehaviour
{
    
    public List<GameObject> Cards = new List<GameObject>();
    public List<GameObject> Attack = new List<GameObject>();
    public List<GameObject> HP = new List<GameObject>();
    public List<GameObject> Mana = new List<GameObject>();

    private Text text;
    CardsLayout layout;

    void Start() 
    {
        layout = GetComponent<CardsLayout>();
    }

    public void RandomCardsCount()
    {
        int random = UnityEngine.Random.Range(0,3);
        
        for(int i = 0; i < random; i++)
        {
            Cards[i].SetActive(false);
        }
    }

    public void RandomHpManaAttack()
    {
        SetRandomNum(Attack);
        SetRandomNum(HP);
        SetRandomNum(Mana); 
    }
    
    private void SetRandomNum(List<GameObject> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            int random = UnityEngine.Random.Range(1,10);
            list[i].GetComponentInChildren<Text>().text = random.ToString();
        }
    }

    public void AnimatedRandomHpManaAttack()
    {
        StopAllCoroutines();
        StartCoroutine(AnimatedSetRandomNum());
    }

    private IEnumerator AnimatedSetRandomNum()
    {  
        for(int i = 0; i < Cards.Count; i++)
        {
            if(!Cards[i].activeSelf) continue;
            Cards[i].transform.SetSiblingIndex(5);

            int randomElement = UnityEngine.Random.Range(1,4);
            int randomNum = UnityEngine.Random.Range(-2,10);

            yield return new WaitForSeconds(0.3f);

            switch(randomElement)
            {
                case 1: Attack[i].GetComponentInChildren<Text>().DOText(randomNum.ToString(), 2, true, ScrambleMode.Numerals); break;
                case 2: HP[i].GetComponentInChildren<Text>().DOText(randomNum.ToString(), 2, true, ScrambleMode.Numerals); break;
                case 3: Mana[i].GetComponentInChildren<Text>().DOText(randomNum.ToString(), 2, true, ScrambleMode.Numerals); break;
            }

            yield return new WaitForSeconds(1);
            CheckHP();

        }
    }

    private void CheckHP()
    {
        for(int i = 0; i < HP.Count; i++)
        {
            if(!Cards[i].activeSelf) continue;
            if(int.Parse(HP[i].GetComponentInChildren<Text>().text) < 1)
            {
                StartCoroutine(AnimatedKillCard(Cards[i]));
            }
        }
    }

    private IEnumerator AnimatedKillCard(GameObject obj)
    { 
        obj.transform.DORotate(new Vector3(0,360,0), 2f, RotateMode.FastBeyond360);
        obj.transform.DOMoveY(20, 5);
        yield return new WaitForSeconds(1);
        obj.SetActive(false);
        layout.Rebuild();
    }



}
