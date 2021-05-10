Shader "Unlit/NewUnlitShader"
{
    Properties // マテリアルのInspectorで設定したいプロパティを書く所
	{
		// ; はつけない
		// プロパティ名 ("Inspectorの表示名", 型) = "デフォルト値" {オプション}
		_MainTex("Texture", 2D) = "white" {} // 2Dは”Texture2D”のこと

		// ここで設定されたプロパティは下のPassブロック同じ名前のプロパティに自動で渡される
		// [Space] :Inspectorの行間に隙間をつくる
		[Space] _FloatValue("Float", float) = 0.1

		[Space] _IntValue("Int", int) = 5

		[Space] _Range("Range", Range(0.5, 1.0)) = 0.63 // 値をスライダーで設定できる

		[Space] _Color("Color", Color) = (1, 0, 0, 1) // パレットで色を設定できる（0 ~ 1で）
    }
    SubShader // シェーダーを書く所
			  // 複数書くことができ、その場合実行できるSubShaderが見つかるまで上から順に流れてく
    {
        Tags // シェーダの設定を決めれたりする。SubShaderの中、Passの中でしか使えないものもある。色々あるから調べたほうがいいかも
		{
			"RenderType"="Opaque" // 半透明描画なら "Transparent"、それ以外なら "Opaque"にしとけばOK
		}
        LOD 100 // 高品質のシェーダと低品質のシェーダを切り替えるための値。C＃スクリプトも書かないと機能しない

        Pass // 固定機能シェーダ、サーフェスシェーダ、頂点、ピクセルシェーダのいずれかを書く。複数ある場合は上から順に全て実行される
        {
			// Passのタグは基本ライティング系

            HLSLPROGRAM
			// #pragma : コンパイラに対して情報を渡す命令
            #pragma vertex vert   // #pragma vertex 頂点シェーダの関数名
            #pragma fragment frag // #pragma fragment フラグメントシェーダの関数名
			// multi_compileから始まるのはシェーダバリアントという機能を使うための命令。処理の無駄を省くためにある。自作できる
            #pragma multi_compile_fog // ウィンドウ＞レンダリング＞環境からFogのON/OFFができ、それを見てONのときだけFogの処理がされるようにする

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f // vertex to fragment 頂点シェーダで値をセットするとポリゴンごとにラスタライズされてフラグメントシェーダに渡される
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1) // fog
                float4 vertex : SV_POSITION; // 座標返還された後の頂点座標
            };

			// Propertiesで設定したものの値渡されている
            sampler2D _MainTex; // Texture2Dと同じ
            float4 _MainTex_ST; // InspectorにあるTilingとOffsetの値が渡される

			// 頂点シェーダ
            v2f vert (appdata v) 
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex); // v2fのvertexに座標変換して値をいれてる | UnityObjectToClipPos:3D->2Dに変換してくれる(-1 ~ 1)。UnityCG.cgincで定義されてる
                o.uv = TRANSFORM_TEX(v.uv, _MainTex); // texture
                UNITY_TRANSFER_FOG(o,o.vertex); // fog
                return o;
            }

			// フラグメントシェーダ
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
	//FallBack "Standard" // 実況できるSubShaderがない場合StantardShaderが実行される。また、用途に合わせたシェーダが定義されていない場合も（影の描画が設定されてなかったらStandardShaderのそれが適応される）
}
