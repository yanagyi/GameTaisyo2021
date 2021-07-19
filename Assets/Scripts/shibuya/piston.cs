using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piston : MonoBehaviour
{
    public bool Zenmai;
    public float pressTime;//ゼンマイを抜いてから何秒間動き続けるか
    float WpressTime;//作業用変数

    public float pressTempo;//プレスする周期
    float WpressTempo;//周期計算用

    public float pressSpeed;//プレスする速さ(上から下まで
    public float pressPos;//どれだけプレスするか（距離

    public bool pressFlag;//プレスしているかどうか

    Vector3 startPos, targetPos;//初期座標と目標の座標　この二つを往復する
    public GameObject[] Root;
    public UsableObject[] parentsScript;
    // Start is called before the first frame update
    void Start()
    {
        Zenmai = false;

        //作業用変数に代入
        WpressTempo = pressTempo;

        //初期状態が上か下か判別して初期座標と目標座標を設定する
        if (pressFlag) {
            startPos = transform.localPosition;
            targetPos = startPos + new Vector3(0.0f, -pressPos, 0.0f);
        } else {
            targetPos = transform.localPosition;
            startPos = targetPos + new Vector3(0.0f, pressPos, 0.0f);
        }
        for (int i = 0; i < Root.Length; i++) {

            parentsScript[i] = Root[i].GetComponent<UsableObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Move()
    {
        for (int i = 0; i < Root.Length; i++) {
            if (parentsScript[i].isZenmai) {
                WpressTime = pressTime;
                WpressTempo--;

                //プレス周期ならば
                if (WpressTempo < 0) {
                    if (transform.localPosition == startPos)//初期座標になったらプレスしていない状態
                    {
                        pressFlag = false;
                    }
                    if (transform.localPosition == targetPos)//目標座標になったらプレスしている状態
                    {
                        pressFlag = true;
                    }
                    WpressTempo = pressTempo;
                }

                if (pressFlag)//初期座標を目指して動く
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, pressSpeed);
                } else//目標座標を目指して動く
                  {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, pressSpeed);
                }
            } else//ゼンマイを抜いても残り時間があれば動き続ける
              {
                if (WpressTime > 0) {
                    WpressTime--;
                    WpressTempo--;

                    //プレス周期ならば
                    if (WpressTempo < 0) {
                        if (transform.localPosition == startPos)//初期座標になったらプレスしていない状態
                        {
                            pressFlag = false;
                        }
                        if (transform.localPosition == targetPos)//目標座標になったらプレスしている状態
                        {
                            pressFlag = true;
                        }
                        WpressTempo = pressTempo;
                    }

                    if (pressFlag)//初期座標を目指して動く
                    {
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, pressSpeed);
                    } else//目標座標を目指して動く
                      {
                        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, pressSpeed);
                    }
                }
            }
        }

    }
    public void PressFlag(bool isZenmai)//オンオフを他のスクリプト(PressManager.cs)からいじれるように
    {
        Zenmai=isZenmai;
    }
}
