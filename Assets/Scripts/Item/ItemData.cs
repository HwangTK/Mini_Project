using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    [TextArea]
    public string description;


    public int healthUp;
    public int manaUp;
    public int manaRegenUp;
    public int healthRegenUp;

    public float healthRegenTimer;


    public int attackUp;

    public float attackDelayDecrease;
    public float moveSpeedUp;







}
