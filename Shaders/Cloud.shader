Shader "Custom/Cloud"
{
	Properties
	{
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


			float4 _Color;

			float hash( float n )
			{
				return frac(sin(n)*43758.5453);
			}
			
			float noise3d( float3 x )
			{
				// The noise function returns a value in the range -1.0f -> 1.0f
			
				float3 p = floor(x);
				float3 f = frac(x);
			
				f = f*f*(3.0-2.0*f);
				float n = p.x + p.y*57.0 + 113.0*p.z;
			
				return lerp(lerp(lerp( hash(n+0.0), hash(n+1.0),f.x),
							lerp( hash(n+57.0), hash(n+58.0),f.x),f.y),
						lerp(lerp( hash(n+113.0), hash(n+114.0),f.x),
							lerp( hash(n+170.0), hash(n+171.0),f.x),f.y),f.z);
			}

			float rand(float2 co){
				return frac(sin(dot(co.xy, float2(12.9898,78.233))) * 43758.5453);
			}
			
			v2f vert (appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				o.color = _Color.rgb;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 c = i.uv;
				float FOUR_THIRDS = (4 / 3);
				float x = FOUR_THIRDS * (c.x - 0.5 );
				float y = FOUR_THIRDS * (c.y - 0.5);
				float xs = x * x;
				float ys = y * y;
				float ci = sqrt(xs + ys);
				float timeFrac = _Time.z;
				clip(1 * rand(float2(x, y)) - ci);
				float3 color = {0, ci, 0};
				color = noise3d(color) * rand(float2(x * sin(timeFrac), y * _Time.a));
				//color = float3( rand( float2(noise3d(color).x, noise3d(color).y) ), rand( sqrt( tan( timeFrac * x/y ) ) ).x);
				clip((0.05 * rand(float2(x, y)) / sin(atan2(y, x)) * sin(timeFrac) + 0.45) - ci);
				return fixed4(color.x * rand(float2(xs, ci)), color.y * rand(float2(ys, ci)), color.z * rand(float2(ci, ci)), 1);
			}
			ENDCG
		}
	}
}
