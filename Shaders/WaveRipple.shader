Shader "Custom/WaveRipple"
{
	Properties
	{
		_Color ("Primary Color", Color) = (1, 0, 0, 1)
		_Texture ("Base (RGB), Alpha (A)", 2D) = "white" {}
		_Frequency ("Frequency", Range (-1, 1)) = 0.25
		_Thickness ("Thickness", Range (0, 1)) = 0.125
		_Offset ("Emptiness", Range (-1, 1)) = 0
		_MaxRadius ("Max Radius", Range (0, 1)) = 0.5
		_InnerRadius ("Inner Radius", Range (0, 1)) = 0
		_CutoffXL ("Horizontal Cutoff (Left)", Range(0, 1)) = 0
		_CutoffXR ("Horizontal Cutoff (Right)", Range(0, 1)) = 1
		_RippleSize ("Ripple Size", Range (0, 1)) = 0.2
		_RippleNum ("Number of Ripples", Range (0, 10)) = 6
		_RippleRotate ("Ripple Rotation Rate", Range (0, 10)) = 1
		//_Direction("Cutoff Direction", Range(0, 2)) = 0
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
			float _InnerRadius;
			float _CutoffXL;
			float _CutoffXR;
			float _RippleSize;
			float _RippleNum;
			float _RippleRotate;
			//float _Direction;

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
				float ci = sqrt(xs + ys);
				clip(c.x - _CutoffXL);
				clip(_CutoffXR - c.x);
				clip((1 - _InnerRadius) - (1 - ci));
				clip((1 - ci) - (1 - _MaxRadius * 0.5));
				float timeFrac = frac(_Time.a / (1 / _Frequency));
				float ui = ci + ci * _RippleSize * sin(_RippleNum * atan(y/x) + timeFrac * _RippleRotate);
				clip(sin((2 * 3.1415926) / _Thickness * (ui - timeFrac)) - _Offset);
				float4 color = { i.color, (_MaxRadius * 0.5 - ci + _InnerRadius) };
				float4 tex = tex2D(_Texture, i.uv);
				tex.a = color.a;
                return color;
            }
            ENDCG
		}
	}
}
