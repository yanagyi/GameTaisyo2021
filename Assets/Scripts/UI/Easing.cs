using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������������������� �ȈՐ��� ��������������������
// In�͉����ɖc���(����)�AOut�͎R�Ȃ��(����)�A���l���ϓ�����
// InOut�͍��̂�������
// 
// time(���݂̎���)�AtimeLength(���Ԃ̒���)�Astart(�J�n���l)�Aend(�I�����l)
// ����4��ݒ肵�AUpdate(FixedUpdate)��time��++����Ȃǂ��Ďg��
//
// ��BACK�n���̂�overshoot(�ǂꂾ���o�b�N���邩)���ǉ�����Ă��� ���ӂ��ꂽ��

public class Easing : MonoBehaviour
{
    //
    // SIN(sin)
    //

    public static float SineIn(float time, float timeLength, float start, float end)
    {
        return -end * Mathf.Cos(time / timeLength * (Mathf.PI / 2.0f)) + end + start;
    }

    public static float SineOut(float time, float timeLength, float start, float end)
    {
        return end * Mathf.Sin(time / timeLength * (Mathf.PI / 2.0f)) + start;
    }

    public static float SineInOut(float time, float timeLength, float start, float end)
    {
        return -end / 2.0f * (Mathf.Cos(Mathf.PI * time / timeLength) - 1.0f) + start;
    }


    //
    // LINEAR(�ꎟ�֐�)
    //

    public static float Linear(float time, float timeLength, float start, float end)
    {
        return end * time / timeLength + start;
    }


    //
    // QUAD(�񎟊֐�)
    //

    public static float QuadIn(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        return end * time * time + start;
    }

    public static float QuadOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        return -end * time * (time - 2.0f) + start;
    }

    public static float QuadInOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength / 2.0f;

        if(time < 1.0f)
        {
            return end / 2.0f * time * time + start;
        }

        time--;
        return -end / 2.0f * (time * (time - 2.0f) - 1.0f) + start;
    }

    //
    // CUBIC(�O���֐�)
    //

    public static float CubicIn(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        return end * time * time * time + start;
    }

    public static float CubicOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        time--;
        return end * (time * time * time + 1.0f) + start;
    }

    public static float CubicInOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength / 2.0f;

        if (time < 1.0f)
        {
            return end / 2.0f * time * time * time + start;
        }

        time -= 2.0f;
        return end / 2.0f * (time * time * time + 2.0f) + start;
    }

    //
    // QUART(�l���֐�)
    //

    public static float QuartIn(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        return end * time * time * time * time + start;
    }

    public static float QuartOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        time--;
        return -end * (time * time * time * time - 1.0f) + start;
    }

    public static float QuartInOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength / 2.0f;

        if (time < 1.0f)
        {
            return end / 2.0f * time * time * time * time + start;
        }

        time -= 2.0f;
        return -end / 2.0f * (time * time * time * time - 2.0f) + start;
    }

    //
    // QUINT(�܎��֐�)
    //

    public static float QuintIn(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        return end * time * time * time * time * time + start;
    }

    public static float QuintOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        time--;
        return end * (time * time * time * time * time + 1.0f) + start;
    }

    public static float QuintInOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength / 2.0f;

        if (time < 1.0f)
        {
            return end / 2.0f * time * time * time * time * time + start;
        }

        time -= 2.0f;
        return end / 2.0f * (time * time * time * time * time + 2.0f) + start;
    }


    //
    // EXPO(�w���֐�)
    //

    public static float ExpoIn(float time, float timeLength, float start, float end)
    {
        return end * Mathf.Pow(2.0f, 10.0f * (time / timeLength - 1.0f)) + start;
    }

    public static float ExpoOut(float time, float timeLength, float start, float end)
    {
        return end * (-Mathf.Pow(2.0f, -10.0f * time / timeLength) + 1.0f) + start;
    }

    public static float ExpoInOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength / 2.0f;

        if (time < 1)
        {
            return end / 2.0f * Mathf.Pow(2.0f, 10.0f * (time - 1.0f)) + start;
        }

        time--;
        return end / 2.0f * (-Mathf.Pow(2.0f, -10.0f * time) + 2.0f) + start;
    }


    //
    // Circle(�~)
    //

    public static float CircleIn(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        return -end * (Mathf.Sqrt(1.0f - time * time) - 1.0f) + start;
    }

    public static float CircleOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength;
        time--;
        return end * Mathf.Sqrt(1.0f - time * time) + start;
    }

    public static float CircleInOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength / 2.0f;

        if (time < 1.0f)
        {
            return -end / 2 * (Mathf.Sqrt(1.0f - time * time) - 1.0f) + start;
        }

        time -= 2.0f;
        return end / 2 * (Mathf.Sqrt(1.0f - time * time) + 1.0f) + start;
    }


    //
    // BACK(�o�b�N)
    //

    public static float BackIn(float time, float timeLength, float start, float end, float overshoot)
    {
        time /= timeLength;
        return end * time * time * ((overshoot + 1.0f) * time - overshoot) + start;
    }

    public static float BackOut(float time, float timeLength, float start, float end, float overshoot)
    {
        time = time / timeLength - 1;
        return end * (time * time * ((overshoot + 1.0f) * time + overshoot) + 1) + start;
    }

    public static float BackInOut(float time, float timeLength, float start, float end, float overshoot)
    {
        overshoot *= 1.525f;
        time /= timeLength / 2.0f;

        if (time < 1.0f)
        {
            return end / 2.0f * (time * time * ((overshoot + 1.0f) * time - overshoot)) + start;
        }

        time -= 2;
        return end / 2 * (time * time * ((overshoot + 1.0f) * time + overshoot) + 2.0f) + start;
    }


    //
    // ELASTIC(�e�͊֐�)
    //

    public static float ElasticIn(float time, float timeLength, float start, float end)
    {
        time /= timeLength;

        // �ǂꂾ���߂邩(���10%)
        float shoot = 1.70158f;

        float period = timeLength * 0.3f;
        float amplitude = end;

        if (time == 0.0f) return start;
        if (time == 1.0f) return start + end;

        if (amplitude < Mathf.Abs(end))
        {
            amplitude = end;
            shoot = period / 4.0f;
        }
        else
        {
            shoot = period / (2.0f * Mathf.PI) * Mathf.Asin(end / amplitude);
        }

        time = time - 1.0f;
        return -(amplitude * Mathf.Pow(2.0f, 10.0f * time) * Mathf.Sin((time * timeLength - shoot) * (2.0f * Mathf.PI) / period)) + start;
    }

    public static float ElasticOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength;

        // �ǂꂾ���߂邩(���10%)
        float shoot = 1.70158f;

        float period = timeLength * 0.3f;
        float amplitude = end;

        if (time == 0.0f) return start;
        if (time == 1.0f) return start + end;

        if (amplitude < Mathf.Abs(end))
        {
            amplitude = end;
            shoot = period / 4.0f;
        }
        else
        {
            shoot = period / (2.0f * Mathf.PI) * Mathf.Asin(end / amplitude);
        }

        time = time - 1.0f;
        return amplitude * Mathf.Pow(2.0f, -10.0f * time) * Mathf.Sin((time * timeLength - shoot) * (2.0f * Mathf.PI) / period) + end + start;
    }

    public static float ElasticInOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength;

        // �ǂꂾ���߂邩(���10%)
        float shoot = 1.70158f;

        float period = timeLength * 0.3f;
        float amplitude = end;

        if (time == 0.0f) return start;
        if (time == 1.0f) return start + end;

        if (amplitude < Mathf.Abs(end))
        {
            amplitude = end;
            shoot = period / 4.0f;
        }
        else
        {
            shoot = period / (2.0f * Mathf.PI) * Mathf.Asin(end / amplitude);
        }


        if (time < 1.0f)
        {
            return -0.5f * (amplitude * Mathf.Pow(2.0f, 10.0f * (time -= 1.0f)) * Mathf.Sin((time * timeLength - shoot) * (2.0f * Mathf.PI) / period)) + start;
        }

        time = time - 1.0f;
        return amplitude * Mathf.Pow(2.0f, -10.0f * time) * Mathf.Sin((time * timeLength - shoot) * (2.0f * Mathf.PI) / period) * 0.5f + end + start;
    }


    //
    // BOUNCE(�o�E���X�֐�)
    //

    public static float BounceIn(float time, float timeLength, float start, float end)
    {
        return end - BounceOut(timeLength - time, timeLength, 0, start);
    }

    public static float BounceOut(float time, float timeLength, float start, float end)
    {
        time /= timeLength;

        if (time < 1.0f / 2.75f)
        {
            return end * (7.5625f * time * time) + start;
        }
        else if (time < 2.0f / 2.75f)
        {
            time -= 1.5f / 2.75f;
            return end * (7.5625f * time * time + 0.75f) + start;
        }
        else if (time < 2.5f / 2.75f)
        {
            time -= 2.25f / 2.75f;
            return end * (7.5625f * time * time + 0.9375f) + start;
        }
        else
        {
            time -= 2.625f / 2.75f;
            return end * (7.5625f * time * time + 0.984375f) + start;
        }
    }

    public static float BounceInOut(float time, float timeLength, float start, float end)
    {
        if (time < timeLength / 2.0f)
        {
            return BounceIn(time * 2.0f, timeLength, 0, end - start) * 0.5f + start;
        }
        else
        {
            return BounceOut(time * 2.0f - timeLength, timeLength, 0, end - start) * 0.5f + start + (end - start) * 0.5f;
        }
    }
}
