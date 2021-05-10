Shader "Unlit/NewUnlitShader"
{
    Properties // �}�e���A����Inspector�Őݒ肵�����v���p�e�B��������
	{
		// ; �͂��Ȃ�
		// �v���p�e�B�� ("Inspector�̕\����", �^) = "�f�t�H���g�l" {�I�v�V����}
		_MainTex("Texture", 2D) = "white" {} // 2D�́hTexture2D�h�̂���

		// �����Őݒ肳�ꂽ�v���p�e�B�͉���Pass�u���b�N�������O�̃v���p�e�B�Ɏ����œn�����
		// [Space] :Inspector�̍s�ԂɌ��Ԃ�����
		[Space] _FloatValue("Float", float) = 0.1

		[Space] _IntValue("Int", int) = 5

		[Space] _Range("Range", Range(0.5, 1.0)) = 0.63 // �l���X���C�_�[�Őݒ�ł���

		[Space] _Color("Color", Color) = (1, 0, 0, 1) // �p���b�g�ŐF��ݒ�ł���i0 ~ 1�Łj
    }
    SubShader // �V�F�[�_�[��������
			  // �����������Ƃ��ł��A���̏ꍇ���s�ł���SubShader��������܂ŏォ�珇�ɗ���Ă�
    {
        Tags // �V�F�[�_�̐ݒ�����߂ꂽ�肷��BSubShader�̒��APass�̒��ł����g���Ȃ����̂�����B�F�X���邩�璲�ׂ��ق�����������
		{
			"RenderType"="Opaque" // �������`��Ȃ� "Transparent"�A����ȊO�Ȃ� "Opaque"�ɂ��Ƃ���OK
		}
        LOD 100 // ���i���̃V�F�[�_�ƒ�i���̃V�F�[�_��؂�ւ��邽�߂̒l�BC���X�N���v�g�������Ȃ��Ƌ@�\���Ȃ�

        Pass // �Œ�@�\�V�F�[�_�A�T�[�t�F�X�V�F�[�_�A���_�A�s�N�Z���V�F�[�_�̂����ꂩ�������B��������ꍇ�͏ォ�珇�ɑS�Ď��s�����
        {
			// Pass�̃^�O�͊�{���C�e�B���O�n

            HLSLPROGRAM
			// #pragma : �R���p�C���ɑ΂��ď���n������
            #pragma vertex vert   // #pragma vertex ���_�V�F�[�_�̊֐���
            #pragma fragment frag // #pragma fragment �t���O�����g�V�F�[�_�̊֐���
			// multi_compile����n�܂�̂̓V�F�[�_�o���A���g�Ƃ����@�\���g�����߂̖��߁B�����̖��ʂ��Ȃ����߂ɂ���B����ł���
            #pragma multi_compile_fog // �E�B���h�E�������_�����O��������Fog��ON/OFF���ł��A���������ON�̂Ƃ�����Fog�̏����������悤�ɂ���

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f // vertex to fragment ���_�V�F�[�_�Œl���Z�b�g����ƃ|���S�����ƂɃ��X�^���C�Y����ăt���O�����g�V�F�[�_�ɓn�����
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1) // fog
                float4 vertex : SV_POSITION; // ���W�Ԋ҂��ꂽ��̒��_���W
            };

			// Properties�Őݒ肵�����̂̒l�n����Ă���
            sampler2D _MainTex; // Texture2D�Ɠ���
            float4 _MainTex_ST; // Inspector�ɂ���Tiling��Offset�̒l���n�����

			// ���_�V�F�[�_
            v2f vert (appdata v) 
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // v2f��vertex�ɍ��W�ϊ����Ēl������Ă� | UnityObjectToClipPos:3D->2D�ɕϊ����Ă����(-1 ~ 1)�BUnityCG.cginc�Œ�`����Ă�
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); // texture
                UNITY_TRANSFER_FOG(o,o.vertex); // fog
                return o;
            }

			// �t���O�����g�V�F�[�_
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDHLSL
        }
    }
	//FallBack "Standard" // �����ł���SubShader���Ȃ��ꍇStantardShader�����s�����B�܂��A�p�r�ɍ��킹���V�F�[�_����`����Ă��Ȃ��ꍇ���i�e�̕`�悪�ݒ肳��ĂȂ�������StandardShader�̂��ꂪ�K�������j
}
