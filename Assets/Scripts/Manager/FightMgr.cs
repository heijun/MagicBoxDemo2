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
            Debug.Log("玩家胜利");
            //TODO 胜利回调
            Destroy(Enemy);
            playerData.exp = enemyData.Exp_contains;
            playerData.defeatnum += 1;
            start = false;
            QuitGame();
        };
        lostCallback += () =>
        {
            Debug.Log("玩家失败");
            //TODO 失败回调
            start = false;
            QuitGame();
        };
        playerData =(PlayerData) GameObject.FindGameObjectWithTag("player").GetComponent<SkillCtrl>().playerData;
        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        /*        Enemy.GetComponent<EnemyCtrl>().战斗.onClick.AddListener(startfight);
                Enemy.GetComponent<EnemyCtrl>().对话.onClick.AddListener(startsay);*/
    }
    public void StartGame()
    {
        playerData.ChangeBellevel();
        //flowchart.SetStringVariable("Var", playerData.bellevel.ToString());
        start = true;
        Debug.Log("游戏开始");
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
            Debug.LogWarning($"第{round}回合开始");
            playerTurn = !playerTurn;
            CharacterData attacker = playerTurn ? playerData : enemyData;
            CharacterData opponent = playerTurn ? enemyData : playerData;
            Debug.Log($"{attacker.characterName}对{opponent.characterName}发起了进攻");
            canMagic = Random.Range(0, 101) >= attacker.magicRate;
            attacker.canMagic = canMagic;

            if (playerTurn)
            {

                Debug.Log("玩家回合");
                Enemy.GetComponent<EnemyCtrl>().PlayHurtAnim();
                Debug.Log("hh");

                yield return _delaySeconds;
                if (canMagic)
                {
                    Debug.LogError($"{attacker.name}发动魔法攻击！");
                    int dmg = (attacker.atk - opponent.def) + (attacker.magicatk - opponent.magicdef);
                    opponent.hp -= dmg;
                    Debug.LogError($"{attacker.name}对{opponent.name}造成了{dmg}点伤害，{opponent.name}剩余{opponent.hp}点血量！");
                }
                else
                {
                    int dmg = attacker.atk - opponent.def;
                    opponent.hp -= dmg;

                    Debug.LogError($"{attacker.name}对{opponent.name}造成了{dmg}点伤害，{opponent.name}剩余{opponent.hp}点血量！");
                }


            }
            else
            {
                Debug.Log("敌人回合");
                Enemy.GetComponent<EnemyCtrl>().对话.gameObject.SetActive(false);
                Enemy.GetComponent<EnemyCtrl>().战斗.gameObject.SetActive(false);
                foreach (var skill in enemyData.skills)
                {
                    skill.ReleaseSkill(playerData, enemyData);
                }
                Enemy.GetComponent<EnemyCtrl>().PlayAtkAnim();
                //_delaySeconds = Enemy.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
                yield return _delaySeconds;
 
                if (canMagic)
                {
                    Debug.LogError($"{attacker.name}发动魔法攻击！");
                    int dmg = (attacker.atk - opponent.def) + (attacker.magicatk - opponent.magicdef);
                    opponent.hp -= dmg;
                    Debug.LogError($"{attacker.name}对{opponent.name}造成了{dmg}点伤害，{opponent.name}剩余{opponent.hp}点血量！");
                }
                else
                {
                    int dmg = attacker.atk - opponent.def;
                    opponent.hp -= dmg;

                    Debug.LogError($"{attacker.name}对{opponent.name}造成了{dmg}点伤害，{opponent.name}剩余{opponent.hp}点血量！");
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
        Enemy.GetComponent<EnemyCtrl>().对话.gameObject.SetActive(false);
        Enemy.GetComponent<EnemyCtrl>().战斗.gameObject.SetActive(false);
    }

    public void startsay() {
        flowchart.SetStringVariable("Var", playerData.bellevel.ToString());
        Debug.Log(flowchart.GetStringVariable("Var"));
        Debug.Log("nihao");
        EventHandler.CallSayDialogEvent();
        say = true;
        Enemy.GetComponent<EnemyCtrl>().对话.gameObject.SetActive(false);
        Enemy.GetComponent<EnemyCtrl>().战斗.gameObject.SetActive(false);
    }

    public void SetSayFasle() {
        Enemy.GetComponent<EnemyCtrl>().对话.gameObject.SetActive(true);
        Enemy.GetComponent<EnemyCtrl>().战斗.gameObject.SetActive(true);
        say = false;
        fight = true;
    }
}

