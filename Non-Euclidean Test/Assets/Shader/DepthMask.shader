Shader "Stencils/Masks/DepthMaskBackFaces" 
{	
	SubShader 
	{
		Tags
		{ 
			"RenderType"		= "DepthMaskBackFaces" 
			"Queue"				= "Geometry-120"
			"IgnoreProjector"	= "True"
		}

		ColorMask 0		
		Cull Front
		
		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			struct appdata 
			{
				float4 vertex : POSITION;
			};
			
			struct v2f 
			{
				float4 pos : SV_POSITION;
			};
			
			v2f vert(appdata v) 
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			half4 frag(v2f i) : COLOR 
			{
				return half4(1,1,0,1);
			}
		ENDCG
		}
	} 
}