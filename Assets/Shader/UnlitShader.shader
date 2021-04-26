// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/UnlitShader"
{
    Properties // マテリアルのInspectorで設定したいプロパティを記述
               // プロパティ名 ("Inspectorに表示する名前", 型) = "デフォルト値" { オプション }
    {
        [NoScaleOffset] _MainTex("Texture", 2D) = "white" {}    // NoScaleDffset -> Tiling,Offsetを使用しない
                                                                // Texture -> テクスチャ名
                                                                // 2D -> 2Dのテクスチャ(普通のテクスチャ)を使用
                                                                // white -> テクスチャがNoneの場合のデフォルトカラー(black or white or red)
    }
    
    SubShader // シェーダーの中身(複数可)
    {
        Pass
        {
            // pass はフォワードレンダリングパイプラインの「ベース」パスであることを示す。
            // アンビエントと主要ディレクショナルライトのデータ設定を行う。
            // ライト方向は _WorldSpaceLightPos0
            // カラーは _LightColor0
            Tags {"LightMode" = "ForwardBase"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc" //  UnityObjectToWorldNormal に対し
            #include "UnityLightingCommon.cginc" // _LightColor0 に対し

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 diff : COLOR0; // 拡散ライティングカラー
                float4 vertex : SV_POSITION;
            };

            v2f vert(appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                // ワールド空間で頂点法線を取得
                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                // 標準拡散 (Lambert) ライティングを求めるための
                // 法線とライト方向間のドット積
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                // ライトカラーの積
                o.diff = nl * _LightColor0;
                return o;
            }

            sampler2D _MainTex;

            fixed4 frag(v2f i) : SV_Target
            {
                // テクスチャのサンプリング
                fixed4 col = tex2D(_MainTex, i.uv);
                // ライティングで乗算
                col *= i.diff;
                return col;
            }
            ENDCG
        }
    }
        
    FallBack "Standard" // Standard -> SubShaderが使えなかった場合に使うシェーダー
}