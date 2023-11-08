using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Director_Script : MonoBehaviour
{
    public GameObject Result_Canvas;

    public Unit_Status_Script target;
    public Unit_Status_Script attacker;

    public bool playSimulation = false;

    public float timer;

    private void Update()
    {
        //If click esc key quit application
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        if(playSimulation == true)
        {
            timer += Time.deltaTime;

            attacker.Attack(target);
            if (target.CheckingDying() == true)
            {
                ShowResult();
            }
        }
        else
        {
            target.maxHp = float.Parse(GameObject.Find("Max_HP_InputField").GetComponent<InputField>().text);
            target.nowHp = target.maxHp;
            target.defensePower = int.Parse(GameObject.Find("DefensePower_InputField").GetComponent<InputField>().text);

            attacker.attackPower = float.Parse(GameObject.Find("AttackPower_InputField").GetComponent<InputField>().text);
            attacker.durabilityNegation = int.Parse(GameObject.Find("DurabilityNegation_InputField").GetComponent<InputField>().text);
            attacker.attackSpeed = float.Parse(GameObject.Find("AttackSpeed_InputField").GetComponent<InputField>().text);
        }

        GameObject.Find("PlayTime_Text").GetComponent<Text>().text = string.Format("{0:N2}", timer);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // if click simulation button
    public void OnClickSimulationButton()
    {
        if (playSimulation == false)
        {
            GameObject.Find("Simulation_StartEnd_Text").GetComponent<Text>().text = "시뮬레이션 종료";
            playSimulation = true;
        }
        else
        {
            ShowResult();
        }
    }

    public void OnClickResultCheckButton()
    {
        Result_Canvas.SetActive(false);
    }

    private void ShowResult()
    {
        Result_Canvas.SetActive(true);
        GameObject.Find("ResultTime_Text").GetComponent<Text>().text = string.Format("{0:N2}", timer);
        playSimulation = false;
        timer = 0;
        GameObject.Find("Simulation_StartEnd_Text").GetComponent<Text>().text = "시뮬레이션 시작";
    }
}