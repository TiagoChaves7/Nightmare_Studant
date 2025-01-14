using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cronometro2 : MonoBehaviour
{
    // Timer variables
    private int N1;
    private float seg2 = 59; // Seconds
    private float min2 = 7;  // Minutes
    public Text VenceGame_txt;
    public Text TimeGame2_txt;
    public Text EndTime_txt;
    public Image VenceGame_imag;

    [SerializeField] private GameObject bossFase;
    [SerializeField] private GameObject VencePlayer;
    [SerializeField] private string Justifica;

    void Start()
    {
        N1 = 1;
        StartCoroutine("cronometro2");
    }

    // Display victory message
    public void VenceGame()
    {
        bossFase.SetActive(false);
        VencePlayer.SetActive(false);
        VenceGame_txt.enabled = true;
        VenceGame_txt.text = "APPROVED ! ! !  You won ! ";
        StartCoroutine("tempo");
    }

    // Transition to menu after delay
    public IEnumerator tempo()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Justifica");
    }

    // Timer coroutine
    IEnumerator cronometro2()
    {
        if (N1 == 1)
        {
            yield return new WaitForSeconds(0.1f);
            seg2 -= 1;

            if (seg2 == 0)
            {
                seg2 = 59;
                min2 -= 1;
                if (min2 < 0)
                {
                    StartCoroutine("VenceGame");
                    N1 = 0;
                }
            }
            // Convert float to string
            string s = seg2.ToString();
            string m = min2.ToString();
            // Display timer
            TimeGame2_txt.text = m + ":" + s;

            StartCoroutine("cronometro2");
        }
    }
}
