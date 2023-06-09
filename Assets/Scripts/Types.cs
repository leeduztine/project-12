using System;
using Sirenix.OdinInspector;
using UnityEngine;

public enum Element
{
    Fire,
    Ice,
    Wind,
    Thunder,
}

public enum Race
{
    Human,
    Beast,
    Mecha,
}

public enum Tier
{
    D,
    C,
    B,
    A,
    S,
    X,
}

public enum DamageType
{
    Physical,
    Magical,
    Pure,
}

public enum Range
{
    Ranged,
    Melee,
}

public enum Rarity
{
    Normal,
    Rare,
    Epic,
    Legendary,
    Mythic,
    Relic,
}

public enum Slot
{
    Weapon,
    Headgear,
    Garment,
    Jewelry,
}

public enum Requirement
{
    None,
    Physical,
    Magical,
}

public enum Effect
{
    //buff
    Invincible,
    Undying,
    
    //debuff
    Stun,
    Silent,
    Bleeding,
}

[Serializable]
public struct Stats
{
    [HideInInspector]
    public bool showFull;
    
    [ShowIf("@showFull || this.health > 0")]
    public float health;
    [ShowIf("@showFull || this.damage > 0")]
    public float damage;
    [ShowIf("@showFull || this.armor > 0")]
    public float armor;
    [ShowIf("@showFull || this.resistance > 0")]
    public float resistance; 
    
    [ShowIf("@showFull || this.intelligence > 0")]
    public float intelligence;
    [ShowIf("@showFull || this.speed > 0")]
    public float speed;
    [ShowIf("@showFull || this.luck > 0")]
    public float luck;
    [ShowIf("@showFull || this.critDamage > 0")]
    public float critDamage;
    
    [ShowIf("@showFull || this.lifeSteal > 0")]
    public float lifeSteal;
    [ShowIf("@showFull || this.accuracy > 0")]
    public float accuracy;

    public static Stats operator +(Stats st1, Stats st2)
    {
        return new Stats
        {
            health = st1.health + st2.health,
            damage = st1.damage + st2.damage,
            armor = st1.armor + st2.armor,
            resistance = st1.resistance + st2.resistance,
            
            intelligence = Clamp(st1.intelligence + st2.intelligence, 100),
            speed = Clamp(st1.speed + st2.speed, 100),
            luck = Clamp(st1.luck + st2.luck, 100),
            critDamage = st1.critDamage + st2.critDamage,
            
            lifeSteal = st1.lifeSteal + st2.lifeSteal,
            accuracy = Clamp(st1.accuracy + st2.accuracy, 80),
        };
    }
    
    public static Stats operator -(Stats st1, Stats st2)
    {
        return new Stats
        {
            health = st1.health - st2.health,
            damage = st1.damage - st2.damage,
            armor = st1.armor + st2.armor,
            resistance = st1.resistance + st2.resistance,
            
            intelligence = st1.intelligence - st2.intelligence,
            speed = st1.speed - st2.speed,
            luck = st1.luck - st2.luck,
            critDamage = st1.critDamage - st2.critDamage,
            
            lifeSteal = st1.lifeSteal - st2.lifeSteal,
            accuracy = st1.accuracy - st2.accuracy,
        };
    }
    
    public static Stats operator *(Stats st1, float rate)
    {
        return new Stats
        {
            health = st1.health * rate,
            damage = st1.damage * rate,
            armor = st1.armor * rate,
            resistance = st1.resistance * rate,
            
            intelligence = Clamp(st1.intelligence * rate, 100),
            speed = Clamp(st1.speed * rate, 100),
            luck = Clamp(st1.luck * rate, 100),
            critDamage = st1.critDamage * rate,
            
            lifeSteal = st1.lifeSteal * rate,
            accuracy = Clamp(st1.accuracy * rate, 80),
        };
    }

    private static float Clamp(float value, float limit)
    {
        return Mathf.Min(value, limit);
    }
}