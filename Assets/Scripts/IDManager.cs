using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{
    public Ability[] abilities;
    public PassiveAbility[] passives;
    public PassiveEffect[] effects;
    public StatusEffect[] statuses;
    public FollowUpAttack[] fuas;
    public EnemySO[] summonnableEnemies;

    private void Start()
    {
        abilities = new Ability[]
        {
            new PlaceholderAbility(),
            new HealingPlaceholderAbility(),
            new DamageAllyAbility(),
            new BeanieActive1(),
            new BeanieAttackAction(),
            new BeanieUlt1(), // 5
            new QingqueActive1(),
            new QingqueActive2(),
            new QingqueActive3(),
            new QingqueActive4(),
            new QingqueActive5(), // 10
            new TestBuff(),
            new ShirokoActive1(),
            new ShirokoUlt1(),
            new TestInstaKill(),
            new TestSummonEnemy(), // 15
            new NerfcentSpell1(),
            new NerfcentSpell2(),
            new NerfcentSpell3(),
            new NerfcentSpell4(),
            new NerfcentSpell5(), // 20
            new NerfcentSpell6(),
            new NerfcentSpell7(),
            new NerfcentSpell8(),
            new NerfcentSpell9(),
            new NerfcentSpell10(), // 25
            new NerfcentSpell11(),
            new NerfcentSpell12()
        };

        passives = new PassiveAbility[]
        {
            new HealOnTurnStartPassive(),
            new BeaniePassive1(),
            new ShirokoPassive1(),
            new ShirokoPassive2(),
            new NerfcentPassive()
        };

        effects = new PassiveEffect[]
        {
            new HealOnTurnStartEffect(100),
            new BeanieEffect1(),
            new ShirokoPEffect1(),
            new ShirokoPEffect2(),
            new NerfcentPEffect(),
            new BurnDoTEffect(), // 5
            new ShockDoTEffect(),
            new BleedDoTEffect(),
            new NerfcentHealEffect()
        };

        statuses = new StatusEffect[]
        {
            new QingqueMATKBuff(),
            new ShirokoDebuff1(),
            new ShirokoATKBuff(),
            new TestBuff1(),
            new TestBuff2(),
            new ShirokoDebuffs21(), // 5
            new ShirokoDebuffs22(),
            new ShirokoDebuffs23(),
            new ShirokoDEFIgnoreBuff(),
            new BurnDoT(),
            new ShockDoT(), // 10
            new BleedDoT(),
            new PoisonDoT(),
            new FreezeCC(),
            new StunCC(),
            new NerfcentATKReduction(), // 15
            new NerfcentHealOnTurnStart()
        };

        fuas = new FollowUpAttack[]
        {
            new ShirokoFuA()
        };
    }
}
