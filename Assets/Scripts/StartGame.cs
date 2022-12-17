using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    
    CardsLayout layout;
    LoadImages loadimages;
    Randomizer randomizer;
    
    void Start()
    {
        layout = GetComponent<CardsLayout>();
        loadimages = GetComponent<LoadImages>();
        randomizer = GetComponent<Randomizer>();

        loadimages.Load();
        randomizer.RandomCardsCount();
        randomizer.RandomHpManaAttack();
        layout.Rebuild();

    }

}
