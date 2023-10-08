using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using Fungus;

public class FightMgr : MoonSingleton<FightMgr>
{
    public GameObject Enemy;
    public PlayerData playerData;
    public EnemyData enemyData;
    private readonly WaitForSeconds _delaySeconds = new WaitForSeconds(3.5f);
    public bool fight;
    public bool say;
    public bool start;
    bool canMagic;
    Action sucCallback; Action lostCallback;
    Flowchart flowchart;
    private void Start()
    {
  
        sucCallback += () =>
        {
            Debug.Log("���ʤ��");
            //TODO ʤ���ص�
            Destroy(Enemy);
            playerData.exp = enemyData.Exp_contains;
            playerData.defeatnum += 1;
            start = false;
            QuitGame();
        };
        lostCallback += () =>
        {
            Debug.Log("���ʧ��");
            //TODO ʧ�ܻص�
            start = false;
            QuitGame();
        };
        playerData =(PlayerData) GameObject.FindGameObjectWithTag("player").GetComponent<SkillCtrl>().playerData;
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        /*        Enemy.GetComponent<EnemyCtrl>().ս��.onClick.AddListener(startfight);
                Enemy.GetComponent<EnemyCtrl>().�Ի�.onClick.AddListener(startsay);*/
    }
    public void StartGame()
    {
        playerData.ChangeBellevel();
        //flowchart.SetStringVariable("Var", playerData.bellevel.ToString());
        start = true;
        Debug.Log("��Ϸ��ʼ");
        foreach (var skill in playerData.skills)
        {
            if (!skill.isreleased) {
                skill.ReleaseSkill(playerData, enemyData);
                skill.isreleased = true;
            }

        }
        StartCoroutine(Fight());
    }

    public void QuitGame() {
        StopCoroutine(Fight());
    }

    private IEnumerator Fight()
    {
        int round = 1;
        bool playerTurn = false;
        while (!playerData.Dead && !enemyData.Dead)
        {
            Debug.LogWarning($"��{round}�غϿ�ʼ");
            playerTurn = !playerTurn;
            CharacterData attacker = playerTurn ? playerData : enemyData;
            CharacterData opponent = playerTurn ? enemyData : playerData;
            Debug.Log($"{attacker.characterName}��{opponent.characterName}�����˽���");
            canMagic = Random.Range(0, 101) >= attacker.magicRate;
            attacker.canMagic = canMagic;

            if (playerTurn)
            {

                Debug.Log("��һغ�");
                Enemy.GetComponent<EnemyCtrl>().PlayHurtAnim();
                Debug.Log("hh");

                yield return _delaySeconds;
                if (canMagic)
                {
                    Debug.LogError($"{attacker.name}����ħ��������");
                    int dmg = (attacker.atk - opponent.def) + (attacker.magicatk - opponent.magicdef);
                    opponent.hp -= dmg;
                    Debug.LogError($"{attacker.name}��{opponent.name}�����{dmg}���˺���{opponent.name}ʣ��{opponent.hp}��Ѫ����");
                }
                else
                {
                    int dmg = attacker.atk - opponent.def;
                    opponent.hp -= dmg;

                    Debug.LogError($"{attacker.name}��{opponent.name}�����{dmg}���˺���{opponent.name}ʣ��{opponent.hp}��Ѫ����");
                }


            }
            else
            {
                Debug.Log("���˻غ�");
                Enemy.GetComponent<EnemyCtrl>().�Ի�.gameObject.SetActive(false);
                Enemy.GetComponent<EnemyCtrl>().ս��.gameObject.SetActive(false);
                foreach (var skill in enemyData.skills)
                {
                    skill.ReleaseSkill(playerData, enemyData);
                }
                Enemy.GetComponent<EnemyCtrl>().PlayAtkAnim();
                //_delaySeconds = Enemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
                yield return _delaySeconds;
 
                if (canMagic)
                {
                    Debug.LogError($"{attacker.name}����ħ��������");
                    int dmg = (attacker.atk - opponent.def) + (attacker.magicatk - opponent.magicdef);
                    opponent.hp -= dmg;
                    Debug.LogError($"{attacker.name}��{opponent.name}�����{dmg}���˺���{opponent.name}ʣ��{opponent.hp}��Ѫ����");
                }
                else
                {
                    int dmg = attacker.atk - opponent.def;
                    opponent.hp -= dmg;

                    Debug.LogError($"{attacker.name}��{opponent.name}�����{dmg}���˺���{opponent.name}ʣ��{opponent.hp}��Ѫ����");
                }
                EventHandler.CallChangeUIEvent(opponent as PlayerData);
                fight = false;
                say = false;
           
                yield return choose();



            }


            Debug.Log(opponent.hp);
/*            if (opponent == playerData) {
                fight = false;
                say = false;
                EventHandler.CallChangeUIEvent(opponent as PlayerData);
                yield return choose();
      
            }*/
         
  
            if (!playerData.Dead && !enemyData.Dead)
            {
                // yield return _delaySeconds;
                round++;
                if (round > 2) { yield break; }
               
            }
            else
            {
                if (playerData.Dead)
                {
                    lostCallback?.Invoke();
                }
                else
                {
                    sucCallback?.Invoke();
                }
            }
           
        }
    }

    IEnumerator choose() {
        while(!fight||say){
            Debug.Log("123");
            yield return null;
        }


    }
  

    public void startfight() {
        fight = true;
        Enemy.GetComponent<EnemyCtrl>().�Ի�.gameObject.SetActive(false);
        Enemy.GetComponent<EnemyCtrl>().ս��.gameObject.SetActive(false);
    }

    public void startsay() {
        flowchart.SetStringVariable("Var", playerData.bellevel.ToString());
        Debug.Log(flowchart.GetStringVariable("Var"));
        Debug.Log("nihao");
        EventHandler.CallSayDialogEvent();
        say = true;
        Enemy.GetComponent<EnemyCtrl>().�Ի�.gameObject.SetActive(false);
        Enemy.GetComponent<EnemyCtrl>().ս��.gameObject.SetActive(false);
    }

    public void SetSayFasle() {
        Enemy.GetComponent<EnemyCtrl>().�Ի�.gameObject.SetActive(true);
        Enemy.GetComponent<EnemyCtrl>().ս��.gameObject.SetActive(true);
        say = false;
        fight = true;
    }
}

