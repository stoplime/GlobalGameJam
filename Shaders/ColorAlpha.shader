Shader "Unlit/ColorAlpha"
{
	Properties
	{
		_Color ("Primary Color", Color) = (1, 0, 0, 1)
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

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				return _Color;
			}
			ENDCG
		}
	}
}
