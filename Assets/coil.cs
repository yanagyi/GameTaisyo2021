using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coil : MonoBehaviour
{
    public bool OnOff;                      // true(点いてる->消える) false(消えてる->点く)
    public GameObject[] ElectricCurrent;    // 電気
    public float max_count;                 // 電気が次に点くまでの時間
    float count;                            // 作業用

    public GameObject[] root;
    public UsableObject[] rootScript;
   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < root.Length; i++) {

            rootScript[i] = root[i].GetComponent<UsableObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OnOff) {
            // 刺さってる間、電気を消す
            // 離れたら作業用の変数(count)を減らす
            for (int i = 0; i < root.Length; i++) {
                if (rootScript[i].isZenmai) {
                    ElectricCurrent[0].SetActive(false);
                    ElectricCurrent[1].SetActive(false);

                    // 作業用に代入
                    count = max_count;
                } else {
                    count--;
                }

                // countが0になったら電気を点ける
                if (count <= 0) {
                    ElectricCurrent[0].SetActive(true);
                    ElectricCurrent[1].SetActive(true);
                }
            }

        }
        else {
            // 刺さってる間、電気を点ける
            // 離れたら作業用の変数(count)を減らす
            for (int i = 0; i < root.Length; i++) {
                if (rootScript[i].isZenmai) {
                    ElectricCurrent[0].SetActive(true);
                    ElectricCurrent[1].SetActive(true);

                    // 作業用に代入
                    count = max_count;
                } else {
                    count--;
                }

                // countが0になったら電気を消す
                if (count <= 0) {
                    ElectricCurrent[0].SetActive(false);
                    ElectricCurrent[1].SetActive(false);
                }
            }

        }
    }
}
