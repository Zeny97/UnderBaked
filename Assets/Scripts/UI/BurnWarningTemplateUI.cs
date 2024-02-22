using UnityEngine;
using UnityEngine.UI;

public class BurnWarningTemplateUI : MonoBehaviour
{
    [SerializeField] private Image warningSprite;
    private void Awake()
    {
        warningSprite.transform.gameObject.SetActive(false);
    }

    public void UpdateWarningStatus(bool state)
    {
        warningSprite.gameObject.SetActive(state);
    }
}
