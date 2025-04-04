using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionButtonUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private TextMeshProUGUI actionCostTextMeshPro;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedGameObject;

    private BaseAction baseAction;
    public void SetBaseAction(BaseAction baseAction) {
        this.baseAction = baseAction;
        textMeshPro.text = baseAction.GetActionName().ToUpper();
        actionCostTextMeshPro.text = baseAction.GetActionResourceCost().ToString();
        button.onClick.AddListener(() => {
            UnitActionManager.Instance.SetSelectedAction(baseAction);
        });
    }

    public void UpdateSelectedVisual() {
        BaseAction selectedBaseAction = UnitActionManager.Instance.GetSelectedAction();
        selectedGameObject.SetActive(selectedBaseAction == baseAction);
    }
}
