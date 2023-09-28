using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehavior : MonoBehaviour
{
    
    TMP_Text headTxt;

    TMP_Text timerTxt;

    void Start()
    {
        headTxt = GameObject.Find("DeadCat_txt").GetComponent<TMPro.TMP_Text>();
        timerTxt = GameObject.Find("lblTime").GetComponent<TMPro.TMP_Text>();

        headTxt.text = "CatBots abattus : " + GameVariables.killedCat;

        StartCoroutine(TimerTick());
    }

    public void addHit() {
        GameVariables.killedCat++;
        headTxt.text = "CatBots abattus : " + GameVariables.killedCat;

        if(GameVariables.killedCat > 2){
            SceneManager.LoadScene("catBoss");
        }
    }

    IEnumerator TimerTick() {
        while (GameVariables.currentTime > 0)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerTxt.text = "Time :" + GameVariables.currentTime.ToString();
        }
        // game over
        SceneManager.LoadScene("Scene1");
    }
}
