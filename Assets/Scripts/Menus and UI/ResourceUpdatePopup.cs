using System.Collections;
using TMPro;
using UnityEngine;

public class ResourceUpdatePopup : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float animationSpeed = 1;

    public void AnimatePopup()
    {
        canvas.gameObject.SetActive(true);
        MoveUp();
    }

    IEnumerator MoveUp()
    {
        int count = 0;

        while (count < 30)
        {
            yield return new WaitForSeconds(0.25f * animationSpeed);
            text.transform.position += new Vector3(0, (0.1f), 0);
            count++;
        }

        gameObject.SetActive(false);
    }
}
