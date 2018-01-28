Shader "Custom/WaveRippleSq"
{
	Properties
	{
		_Color ("Primary Color", Color) = (1, 0, 0, 1)
		_Texture ("Base (RGB), Alpha (A)", 2D) = "white" {}
		_Frequency ("Frequency", Range (-1, 1)) = 0.25
		_Thickness ("Thickness", Range (0, 1)) = 0.125
		_Offset ("Emptiness", Range (-1, 1)) = 0
		_MaxRadius ("Max Radius", Range (0, 1)) = 0.5
	}
	SubShader
	{
		LOD 200

		Tags {
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		} 
		
		Pass
		{
			Cull Off
            Lighting Off
            ZWrite Off
            Offset -1, -1
            Fog { Mode Off }
            ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct v2f {
				float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                fixed3 color : COLOR0;
            };

			sampler2D _Texture;
			fixed4 _Color;
			float _Frequency;
			float _Thickness;
			float _Offset;
			float _MaxRadius;

            v2f vert (appdata_base v)
            {
				
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
                o.color = _Color.rgb;
                return o;
            }

            fixed4 frag (v2f i) : COLOR
            {
				float2 c = i.uv;
				float FOUR_THIRDS = (4 / 3);
				float x = FOUR_THIRDS * (c.x - 0.5 );
				float y = FOUR_THIRDS * (c.y - 0.5);
				float xs = x * x;
				float ys = y * y;
				float ci = xs + ys;
				clip((1 - ci) - (1 - _MaxRadius));
				float timeFrac = frac(_Time.a / (1 / _Frequency));
				clip(sin((2 * 3.1415926) / (_Thickness * sin(3 * atan2(y, x))) * (ci - timeFrac)) - _Offset);
				float4 color = { i.color * ((1 - ci) + 0.5), (1 - 2 * ci) };
				float4 tex = tex2D(_Texture, i.uv);
				tex.a = color.a;
                return color;
            }
            ENDCG
		}
	}
}
