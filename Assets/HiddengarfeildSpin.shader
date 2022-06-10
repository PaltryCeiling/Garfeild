Shader "Hidden/garfieldSpin"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }
        SubShader
    {
        // No culling or depth
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

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            float getPos(float pos, float offset) {
                return (pos + offset) % 1;
            }
            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
            // just invert the colors
            col.rgb = tex2D(_MainTex, float2(i.uv.x, getPos(i.uv.y, (floor(_Time.x * 1000) % 2 == 0 ? (_Time.x * 1.45) + 0.023935 : (_Time.x * 1.45)) * 20)));


            return col;
        }
        ENDCG
    }
    }
}