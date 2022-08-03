using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float hp;
    public float mana;
    public float max_hp;
    public float max_mana;
    public float manaRegenTime;

    public ProgressBar HPB;
    public ProgressBar ManaB;


    private void Update()
    {
        HPB.SetProgressBar(max_hp, hp, 0);
        ManaB.SetProgressBar(max_mana, mana, 0);
        if(mana < max_mana)
        mana += (manaRegenTime * Time.deltaTime);

        if (hp <= 0)
            GetComponent<SceneChanger>().ChangeScene("MainMenuScene");
    }
}
