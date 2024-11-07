Shader "Hidden/pixelate"
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
            float _Amount;
            float _UpperThreshold, _LowerThreshold;
            float _Pixelate;
            float _Greyscale;

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;

                if(_Pixelate == 1)
                {
                    uv.x *= _ScreenParams / _Amount;
                    uv.x = round(uv.x);
                    uv.x /= _ScreenParams / _Amount;

                    uv.y *= _ScreenParams / _Amount;
                    uv.y = round(uv.y);
                    uv.y /= _ScreenParams / _Amount;
                }
                fixed4 col = tex2D(_MainTex, uv);

                float luminance = dot(col.rgb, float3(0.2125, 0.7154, 0.0721));

                if(_Greyscale == 1)
                    col = luminance;

                if(luminance > _UpperThreshold || luminance < _LowerThreshold)
                    col = 1 - col;

                return col;
            }
            ENDCG
        }
    }
}
