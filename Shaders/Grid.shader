Shader "Custom/Grid"
{
	Properties
	{
		_Color ("Color", Color) = (0.13, 0.13, 0.13, 1)
		_Density ("Density", Range(2, 5000)) = 30
		_Thickness ("Thickness", Range(0, 1)) = 0.01
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

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

			fixed4 _Color;
			float _Density; 
			float _Thickness;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv * _Density;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 c = i.uv;
				clip(frac(c.x) - _Thickness);
				clip(frac(c.y) - _Thickness);
				return _Color;
			}
			ENDCG
		}
	}
}
