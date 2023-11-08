using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject unit;

    float maxHp, nowHp;

    private void Update()
    {
        maxHp = unit.GetComponent<Unit_Status_Script>().maxHp;
        nowHp = unit.GetComponent<Unit_Status_Script>().nowHp;

        gameObject.GetComponent<Slider>().value = nowHp / maxHp;
        GameObject.Find("Hp_Text").GetComponent<Text>().text = nowHp + "/" + maxHp;
    }
}