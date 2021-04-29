using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// ────────── 簡易説明 ──────────
// PauseManagerの子要素につっこんだオブジェクトを停止するスクリプト
// 止めたくないオブジェクトがある場合はインスペクターからignoreObjectに登録
// Pauseで停止、Resumeで再開


// Rigidbodyの速度保存用
// これがないとポーズ解除時の挙動がおかしくなる
public class RigidbodyVelocity
{
    public Vector3 velocity;
    public Vector3 angularVelocity;

    public RigidbodyVelocity(Rigidbody rigidbody)
    {
        velocity = rigidbody.velocity;
        angularVelocity = rigidbody.angularVelocity;
    }
}

public class PauseManager : MonoBehaviour
{
    // ポーズ中か否か
    private bool isPause;

    // 前のポーズ状態を保存
    private bool prevPause;

    // 無視するオブジェクト
    public GameObject[] ignoreObjects;


    // ポーズ用配列
    private RigidbodyVelocity[] pauseRigidbodyVelocitys;
    private Rigidbody[] pauseRigidbodys;
    private MonoBehaviour[] pauseMonoBehaviours;

    void Start()
    {
        isPause = false;
        prevPause = false;
    }

    void Update()
    {
        // 直前の停止状態と渡された値を比較し停止/再開を行う
        if (prevPause != isPause)
        {
            if(isPause)
            {
                onPause();
            }
            else
            {
                onResume();
            }

            prevPause = isPause;
        }
    }

    // 他スクリプトからの呼び出し用
    public void Pause()
    {
        isPause = true;
    }

    public void Resume()
    {
        isPause = false;
    }

    // ポーズ
    void onPause()
    {
        // 無視するオブジェクトを除くPauseManagerの子要素のRigidBodyを取得
        pauseRigidbodys = Array.FindAll(GetComponentsInChildren<Rigidbody>(), (obj) => { return (!obj.IsSleeping() && Array.FindIndex(ignoreObjects, igObject => igObject == obj.gameObject) < 0); });

        pauseRigidbodyVelocitys = new RigidbodyVelocity[pauseRigidbodys.Length];

        // Rigidbodyの速度など保存、Sleep
        for (int i = 0; i < pauseRigidbodys.Length; i++)
        {
            pauseRigidbodyVelocitys[i] = new RigidbodyVelocity(pauseRigidbodys[i]);
            pauseRigidbodys[i].Sleep();
        }

        // 無視するオブジェクトを除くPauseManagerの子要素のMonoBehaviourを取得
        pauseMonoBehaviours = Array.FindAll(GetComponentsInChildren<MonoBehaviour>(), (obj) => { return (obj.enabled && obj != this &&Array.FindIndex(ignoreObjects, igObject => igObject == obj.gameObject) < 0); });

        // MonoBehaviourを停止
        foreach (var monoBehaviour in pauseMonoBehaviours)
        {
            monoBehaviour.enabled = false;
        }
    }

    // ポーズ解除
    void onResume()
    {
        // Rigidbodyに保存しておいた速度を戻す、WakeUp
        for (int i = 0; i < pauseRigidbodys.Length; i++)
        {
            pauseRigidbodys[i].WakeUp();
            pauseRigidbodys[i].velocity = pauseRigidbodyVelocitys[i].velocity;
            pauseRigidbodys[i].angularVelocity = pauseRigidbodyVelocitys[i].angularVelocity;
        }

        // MonoBehaviourを再開
        foreach (var monoBehaviour in pauseMonoBehaviours)
        {
            monoBehaviour.enabled = true;
        }
    }
}
