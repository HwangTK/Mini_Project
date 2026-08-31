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


}
