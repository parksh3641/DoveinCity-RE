using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSkill : MonoBehaviour
{
    public static TutorialSkill instance;

    private bool SkillValue;

    public UISprite Skill_Filter;
    public UILabel Skill_txt;

    public UISprite InGame_Skill_Filter;


    void Awake()
    {
        instance = this;

        SkillValue = true;
    }



}
