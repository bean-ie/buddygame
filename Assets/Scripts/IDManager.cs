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

    private void Start()
    {
        abilities = new Ability[]
        {
            new PlaceholderAbility(),
            new HealingPlaceholderAbility(),
            new DamageAllyAbility(),
            new BeanieActive1(),
            new BeanieAttackAction(),
            new BeanieUlt1(),
            new QingqueActive1(),
            new QingqueActive2(),
            new QingqueActive3(),
            new QingqueActive4(),
            new QingqueActive5(),
            new TestBuff(),
            new ShirokoActive1()
        };

        passives = new PassiveAbility[]
        {
            new HealOnTurnStartPassive(),
            new BeaniePassive1(),
            new ShirokoPassive1(),
            new ShirokoPassive2()
        };

        effects = new PassiveEffect[]
        {
            new HealOnTurnStartEffect(100),
            new BeanieEffect1(),
            new ShirokoPEffect1(),
            new ShirokoPEffect2()
        };

        statuses = new StatusEffect[]
        {
            new QingqueMATKBuff(),
            new ShirokoDebuff1(),
            new ShirokoATKBuff(),
            new TestBuff1(),
            new TestBuff2(),
            new ShirokoDebuffs21(),
            new ShirokoDebuffs22(),
            new ShirokoDebuffs23()
        };

        fuas = new FollowUpAttack[]
        {
            new ShirokoFuA()
        };
    }
}
