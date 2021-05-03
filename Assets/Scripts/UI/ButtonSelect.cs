using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �e�I�u�W�F�N�g(UI)��\�������Ƃ��Ƀ{�^����I������X�N���v�g

public class ButtonSelect : MonoBehaviour
{
    public GameObject parentObject;
    public Button button;
    [SerializeField]
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (parentObject.activeSelf && !flag)
        {
            button.Select();
            flag = true;
        }
        if (!parentObject.activeSelf)
        {
            flag = false;
        }
    }
}
