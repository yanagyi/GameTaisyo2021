// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/UnlitShader"
{
    Properties // �}�e���A����Inspector�Őݒ肵�����v���p�e�B���L�q
               // �v���p�e�B�� ("Inspector�ɕ\�����閼�O", �^) = "�f�t�H���g�l" { �I�v�V���� }
    {
        [NoScaleOffset] _MainTex("Texture", 2D) = "white" {}    // NoScaleDffset -> Tiling,Offset���g�p���Ȃ�
                                                                // Texture -> �e�N�X�`����
                                                                // 2D -> 2D�̃e�N�X�`��(���ʂ̃e�N�X�`��)���g�p
                                                                // white -> �e�N�X�`����None�̏ꍇ�̃f�t�H���g�J���[(black or white or red)
    }
    
    SubShader // �V�F�[�_�[�̒��g(������)
    {
        Pass
        {
            // pass �̓t�H���[�h�����_�����O�p�C�v���C���́u�x�[�X�v�p�X�ł��邱�Ƃ������B
            // �A���r�G���g�Ǝ�v�f�B���N�V���i�����C�g�̃f�[�^�ݒ���s���B
            // ���C�g������ _WorldSpaceLightPos0
            // �J���[�� _LightColor0
            Tags {"LightMode" = "ForwardBase"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc" //  UnityObjectToWorldNormal �ɑ΂�
            #include "UnityLightingCommon.cginc" // _LightColor0 �ɑ΂�

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 diff : COLOR0; // �g�U���C�e�B���O�J���[
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                // ���[���h��ԂŒ��_�@�����擾
                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                // �W���g�U (Lambert) ���C�e�B���O�����߂邽�߂�
                // �@���ƃ��C�g�����Ԃ̃h�b�g��
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                // ���C�g�J���[�̐�
                o.diff = nl * _LightColor0;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target
            {
                // �e�N�X�`���̃T���v�����O
                fixed4 col = tex2D(_MainTex, i.uv);
                // ���C�e�B���O�ŏ�Z
                col *= i.diff;
                return col;
            }
            ENDCG
        }
    }
        
    FallBack "Standard" // Standard -> SubShader���g���Ȃ������ꍇ�Ɏg���V�F�[�_�[
}