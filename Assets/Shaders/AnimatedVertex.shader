Shader "Custom/VertexAnim" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Dissolve ("Dissolve", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		ZWrite On
		Cull Off
      
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert addshadow 

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			fixed4 vertexColor;
			float3 worldPos;
			float4 screenPos;
		};
		
		 void vert (inout appdata_full v, out Input o) {
          UNITY_INITIALIZE_OUTPUT(Input,o);
          
        
           
          o.vertexColor = v.color;
          
          float angle= _Time * 50;
          //v.vertex.xyz *= 1- v.texcoord.y;
           v.vertex.y -= .5 * abs(sin(20*_Time + v.vertex.z * 3 )) * v.texcoord.y;
           v.vertex.x += .5 * sin(40*_Time + v.vertex.z * 4) * v.texcoord.y;
         //  v.vertex.y += .05 * (sin(10*_Time));
          //v.vertex.y += 10* sin(10 *_Time) * v.texcoord.y * v.normal.z;
      }

		half _Glossiness;
		half _Metallic;
		half _Dissolve;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
		
			float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
			screenUV *= float2(4,3);
			fixed fadeTex = tex2D (_MainTex, screenUV).r;
			clip (fadeTex - (1- _Color.a));
			
			//clip (frac((IN.worldPos.yx+IN.worldPos.z*0.1) * 25) - _Dissolve);
			o.Albedo = IN.vertexColor.rgb;
			o.Emission = _Color.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic ;
			o.Smoothness = _Glossiness ;
			o.Alpha = _Color.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
