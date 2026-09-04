using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CraftManager : MonoBehaviour
{
    [SerializeField] private CraftSlot[] _craftSlots;

    [SerializeField] private Inventory _inventory;
    [SerializeField] private CraftRecipe[] _recipes;
    [SerializeField] private TMP_Text _resultText;


    public void Craft()
    {
        List<ItemData> currentItems = new List<ItemData>();
        

        for (int i = 0; i < _craftSlots.Length; i++)
        {
            if (_craftSlots[i].IsEmpty)
            {
                continue;
            }

            currentItems.Add(_craftSlots[i].ItemData);
            

        }

        for (int i = 0; i < _recipes.Length; i++)
        {
            CraftRecipe recipe = _recipes[i];

            if (currentItems.Count != recipe.materials.Length)
            {
                continue;
            }

            bool isMatch = true;

            for (int j = 0; j < recipe.materials.Length; j++)
            {
                ItemData recipeItem = recipe.materials[j];

                if (!currentItems.Contains(recipeItem))
                {
                    isMatch = false;
                    break;
                }
            }


            if (isMatch)
            {
                Debug.Log("제작 성공");
                _resultText.text = "제작 성공";
                StartCoroutine(HideResultText());

                _inventory.AddItem(recipe.resultItem);

                for (int j = 0; j < _craftSlots.Length; j++)
                {
                    if (!_craftSlots[j].IsEmpty)
                    {
                        _craftSlots[j].RemoveItem();
                    }
                }

                return;
            }
        }
        
        Debug.Log("조합 실패");
        _resultText.text = "조합 실패";
        StartCoroutine(HideResultText());

    }




    private IEnumerator HideResultText()
    {
        yield return new WaitForSeconds(1.5f);

        _resultText.text = "";
    }
}
