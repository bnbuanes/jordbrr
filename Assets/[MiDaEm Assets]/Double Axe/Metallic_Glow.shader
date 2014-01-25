Shader "Metallic_Glow"
{
	Properties 
	{
_Diffuse("_Diffuse", 2D) = "gray" {}
_Normal("_Normal", 2D) = "bump" {}
_Spec_Power("_Spec_Power", Float) = 5
_Spec("_Spec", 2D) = "white" {}
_Glow_Power("_Glow_Power", Float) = 1
_Glow("_Glow", 2D) = "black" {}
_Reflection("_Reflection", Float) = 1

	}
	
	SubShader 
	{
		Tags
		{
"Queue"="Transparent"
"IgnoreProjector"="False"
"RenderType"="TransparentCutout"

		}

		
Cull Back
ZWrite On
ZTest LEqual
ColorMask RGBA
Blend SrcAlpha OneMinusSrcAlpha
Fog{
}


		CGPROGRAM
#pragma surface surf BlinnPhongEditor  vertex:vert
#pragma target 2.0


sampler2D _Diffuse;
sampler2D _Normal;
float _Spec_Power;
sampler2D _Spec;
float _Glow_Power;
sampler2D _Glow;
float _Reflection;

			struct EditorSurfaceOutput {
				half3 Albedo;
				half3 Normal;
				half3 Emission;
				half3 Gloss;
				half Specular;
				half Alpha;
				half4 Custom;
			};
			
			inline half4 LightingBlinnPhongEditor_PrePass (EditorSurfaceOutput s, half4 light)
			{
half3 spec = light.a * s.Gloss;
half4 c;
c.rgb = (s.Albedo * light.rgb + light.rgb * spec);
c.a = s.Alpha;
return c;

			}

			inline half4 LightingBlinnPhongEditor (EditorSurfaceOutput s, half3 lightDir, half3 viewDir, half atten)
			{
				half3 h = normalize (lightDir + viewDir);
				
				half diff = max (0, dot ( lightDir, s.Normal ));
				
				float nh = max (0, dot (s.Normal, h));
				float spec = pow (nh, s.Specular*128.0);
				
				half4 res;
				res.rgb = _LightColor0.rgb * diff;
				res.w = spec * Luminance (_LightColor0.rgb);
				res *= atten * 2.0;

				return LightingBlinnPhongEditor_PrePass( s, res );
			}
			
			struct Input {
				float2 uv_Diffuse;
float2 uv_Normal;
float2 uv_Glow;
float2 uv_Spec;

			};

			void vert (inout appdata_full v, out Input o) {
float4 VertexOutputMaster0_0_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_1_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_2_NoInput = float4(0,0,0,0);
float4 VertexOutputMaster0_3_NoInput = float4(0,0,0,0);


			}
			

			void surf (Input IN, inout EditorSurfaceOutput o) {
				o.Normal = float3(0.0,0.0,1.0);
				o.Alpha = 1.0;
				o.Albedo = 0.0;
				o.Emission = 0.0;
				o.Gloss = 0.0;
				o.Specular = 0.0;
				o.Custom = 0.0;
				
float4 Tex2D1=tex2D(_Diffuse,(IN.uv_Diffuse.xyxy).xy);
float4 Tex2D0=tex2D(_Normal,(IN.uv_Normal.xyxy).xy);
float4 UnpackNormal0=float4(UnpackNormal(Tex2D0).xyz, 1.0);
float4 Tex2D2=tex2D(_Glow,(IN.uv_Glow.xyxy).xy);
float4 Multiply0=Tex2D2 * _Glow_Power.xxxx;
float4 Tex2D3=tex2D(_Spec,(IN.uv_Spec.xyxy).xy);
float4 Add0=Tex2D3 + _Spec_Power.xxxx;
float4 Tex2D4=tex2D(_Spec,(IN.uv_Spec.xyxy).xy);
float4 Multiply1=Tex2D4 * _Reflection.xxxx;
float4 Master0_7_NoInput = float4(0,0,0,0);
float4 Master0_6_NoInput = float4(1,1,1,1);
o.Albedo = Tex2D1;
o.Normal = UnpackNormal0;
o.Emission = Multiply0;
o.Specular = Add0;
o.Gloss = Multiply1;
o.Alpha = Tex2D1.aaaa;

				o.Normal = normalize(o.Normal);
			}
		ENDCG
	}
	Fallback "Diffuse"
}