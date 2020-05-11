using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    private AudioSource source;
    public AudioClip click;
    public AudioClip dove_hit;
    public AudioClip eagle_hit;
    public AudioClip gameover;
    public AudioClip low_health;
    public AudioClip hp_up;
    public AudioClip coin;
    public AudioClip olive_hit;
    public AudioClip box_open_1;
    public AudioClip box_open_2;
    public AudioClip box_open_3;
    public AudioClip surprised;
    public AudioClip disappear;
    public AudioClip hiddenin;
    public AudioClip hiddenout;
    public AudioClip ufo;
    public AudioClip yeah;
    public AudioClip select;
    public AudioClip beam;
    public AudioClip bang;
    public AudioClip shield;
    public AudioClip talk;
    public AudioClip oha;

    //네트워크
    public AudioClip people_in;
    public AudioClip people_out;

    public static int SFX_Value;
    //비둘기 설정
    private bool Hp_Red;

    public AudioSource source_skill;
    public AudioSource source_sea;
    public AudioSource source_rain;
    public AudioSource source_disco;
    public AudioSource source_warning;

    private bool Sea_Value;

    void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();

        Hp_Red = false;
        Sea_Value = false;

        if (source_skill != null)
        {
            source_skill.enabled = false;
        }
        if (source_sea != null)
        {
            source_sea.enabled = false;
        }
        if (source_rain != null)
        {
            source_rain.enabled = false;
        }
        if (source_disco != null)
        {
            source_disco.enabled = false;
        }
        if (source_warning != null)
        {
            source_warning.enabled = false;
        }
    }

    public void Option()
    {
        if(source_skill.enabled == true)
        {
            source_skill.Pause();
        }
        if (source_sea.enabled == true)
        {
            source_sea.Pause();
        }
        if (source_rain.enabled == true)
        {
            source_rain.Pause();
        }
        if (source_disco.enabled == true)
        {
            source_disco.Pause();
        }
        if (source_warning.enabled == true)
        {
            source_warning.Pause();
        }
    }

    public void Continue()
    {
        if (source_skill.enabled == true)
        {
            source_skill.UnPause();
        }
        if (source_sea.enabled == true)
        {
            source_sea.UnPause();
        }
        if (source_rain.enabled == true)
        {
            source_rain.UnPause();
        }
        if (source_disco.enabled == true)
        {
            source_disco.UnPause();
        }
        if (source_warning.enabled == true)
        {
            source_warning.UnPause();
        }
    }

    public void onClick()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(click);
        }

    } //버튼이 눌리면 클릭소리

    public void SFX_On()
    {
        SFX_Value = 1;
        if (source_skill != null)
        {
            Sfx_Check(SFX_Value);
        }
    }
    public void SFX_Off()
    {
        SFX_Value = 0;
        if (source_skill != null)
        {
            Sfx_Check(SFX_Value);
        }
    }
    public void GameOver()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(gameover);
        }
    }
    //게임
    public void Hp_Minus(int number)
    {
        if (SFX_Value == 1)
        {
            if (number == 1)
            {
                source.PlayOneShot(dove_hit, 1.5f);
            }
            else
            {
                source.PlayOneShot(eagle_hit, 2f);
            }
        }
    }
    public void Hp_Red_In()
    {
        StopAllCoroutines();

        Hp_Red = true;
        StartCoroutine(Hp_Red_Song());
    }
    public void Hp_Red_Out()
    {
        Hp_Red = false;
    }
    IEnumerator Hp_Red_Song()
    {
        while (Hp_Red)
        {
            if (SFX_Value == 1)
            {
                source.PlayOneShot(low_health, 0.07f);
            }
            else
            {
                yield break;
            }
            yield return new WaitForSeconds(2.5f);
        }
    }

    public void Hp_Plus()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(hp_up);
        }
    }
    public void Coin_Plus()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(coin);
        }
    }
    public void Olive_In()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(olive_hit);
        }
    }

    public void Box_Open_1()
    {
        if (SFX_Value == 1)
        {
            source.Stop();
            source.PlayOneShot(box_open_1);
        }
    }
    public void Box_Open_2()
    {
        if (SFX_Value == 1)
        {
            source.Stop();
            source.PlayOneShot(box_open_2);
        }
    }
    public void Box_Open_3()
    {
        if (SFX_Value == 1)
        {
            source.Stop();
            source.PlayOneShot(box_open_3);
        }
    }

    public void Surprised()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(surprised);
        }
    }

    public void Disappear()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(disappear);
        }
    }

    public void Hidden_In()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(hiddenin,0.75f);
        }
    }
    public void Hidden_Out()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(hiddenout,0.75f);
        }
    }

    public void Ufo()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(ufo);
        }
    }

    public void Beam()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(beam,0.4f);
        }
    }

    public void Bang()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(bang);
        }
    }

    public void Shield()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(shield);
        }
    }

    public void Talk ()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(talk);
        }
    }
    public void Bad()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(oha);
        }
    }

    public void People_In()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(people_in);
        }
    }

    public void People_Out()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(people_out);
        }
    }

    //선택창 전용

    public void Dove_Select()
    {
        if (SFX_Value == 1)
        {
            source.PlayOneShot(select);
        }
    }
    public void Yeah()
    {
        if (SFX_Value == 1)
        {
            source.Stop();
            source.PlayOneShot(yeah);
        }
    }

    public void Warning_On()
    {
        if (SFX_Value == 1)
        {
            source_warning.enabled = true;
        }
        else
        {
            source_warning.enabled = true;
            source_warning.Pause();
        }
    }

    public void Warning_Off()
    {
        source_warning.enabled = false;
    }


    //그 외

    void Sfx_Check(int number)
    {
        if(number == 1)
        {
            if (source_skill.enabled == true)
            {
                source_skill.UnPause();
            }

            if (source_sea.enabled == true)
            {
                source_sea.UnPause();
            }

            if (source_rain.enabled == true)
            {
                source_rain.UnPause();
            }

            if (source_disco.enabled == true)
            {
                source_disco.UnPause();
            }

        }
        else
        {
            if(source_skill.enabled == true)
            {
                source_skill.Pause();
            }

            if (source_sea.enabled == true)
            {
                source_sea.Pause();
            }

            if (source_rain.enabled == true)
            {
                source_rain.Pause();
            }

            if (source_disco.enabled == true)
            {
                source_disco.Pause();
            }
        }
    }

    public void Boast_Song_On()
    {
        if(SFX_Value == 1)
        {
            source_skill.enabled = true;
        }
        else
        {
            source_skill.enabled = true;
            source_skill.Pause();
        }
    }
    public void Boast_Song_Off()
    {
        source_skill.enabled = false;
    }
    public void Sea_Song_On()
    {
        Sea_Value = true;
        //Debug.Log("바다소리 재생");
        if (SFX_Value == 1)
        {
            source_sea.enabled = true;
        }
        else
        {
            source_sea.enabled = true;
            source_sea.Pause();
        }
    }
    public void Sea_Song_Off()
    {
        Sea_Value = false;
        source_sea.enabled = false;
    }

    public void Rain_Song_On()
    {
        if (SFX_Value == 1)
        {
            source_rain.enabled = true;
        }
        else
        {
            source_rain.enabled = true;
            source_rain.Pause();
        }

        if (Sea_Value == true)
        {
            source_sea.enabled = false;
        }
    }
    public void Rain_Song_Off()
    {
        source_rain.enabled = false;

        if (Sea_Value == true)
        {
            source_sea.enabled = true;
        }
    }

    public void Disco_Song_On()
    {
        if (SFX_Value == 1)
        {
            source_disco.enabled = true;
        }
        else
        {
            source_disco.enabled = true;
            source_disco.Pause();
        }
    }
    public void Disco_Song_Off()
    {
        source_disco.enabled = false;
    }

}
