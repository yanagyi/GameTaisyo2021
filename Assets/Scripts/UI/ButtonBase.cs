using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �{�^�����ʉ��p�N���X
public class ButtonBase : MonoBehaviour
{
    public ButtonBase button;

    public void OnClick()
    {
        if (button == null)
        {
            throw new System.Exception("Button Instance Null");
        }
        // �{�^���̖��O���擾
        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectName)
    {
    }
}
