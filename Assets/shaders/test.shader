Shader "Hidden/test"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _Multiplier, _Threshold, _Size;
            float4 _Color;
            float _YFlip, _XFlip;

            fixed4 frag (v2f i) : SV_Target
            {
                if(_XFlip == 1)
                    i.uv.x = 1 - i.uv.x;
                if(_YFlip == 1)
                    i.uv.y = 1 - i.uv.y;

                float4 col = tex2D(_MainTex, i.uv);

                float4 tint = 0;
                tint.r = i.uv.x % (_Size / _ScreenParams.x);
                tint.g = i.uv.y % (_Size / _ScreenParams.y);
                tint.b = cos(i.uv.y);

                tint.r -= 0.5;
                if(abs(tint.r) > _Threshold)
                    return _Color;
                tint.g -= 0.5;
                if(abs(tint.g) > _Threshold)
                    return _Color;
                
                tint.r += 0.5;
                tint.g += 0.5;

                col += tint * _Multiplier;
                
                return col;
            }
            ENDCG
        }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _SquishAmount;

            fixed4 frag (v2f i) : SV_Target
            {
                float4 col = tex2D(_MainTex, float2(i.uv.x, i.uv.y * _SquishAmount));

                

                if(i.uv.y * _SquishAmount > 1)
                {
                    if(i.uv.x < 0.7 && i.uv.x > 0.3)
                    {
                        if(i.uv.x > 0.65 || i.uv.x < 0.35)
                            return float4(0.8,0.8,0,1);
                        return float4(0.6,0.6,0.6,1);
                    }
                    return 0;
                }
                return col;
            }
            ENDCG
        }
    }
}
