Shader "BOXOPHOBIC/LowPolyWater V2/ADVANCED" {
Properties {
[HideInInspector]  __dirty ("", Float) = 1.000000
[Header(Optimisations)] [Toggle]  _PerVertexSpecular ("Per Vertex Specular", Float) = 0.000000
[Toggle]  _DisableReflection ("Disable Reflection", Float) = 0.000000
[HideInInspector]  _ReflectionTex ("ReflectionTex", 2D) = "black" { }
[Header(Surface Control)]  _WaterColor ("Water Color", Color) = (0.195285,0.415326,0.632353,1.000000)
 _WaterSpecular ("Water Specular", Range(0.000000,10.000000)) = 3.000000
 _WaterGloss ("Water Gloss", Range(0.000000,10.000000)) = 3.000000
 _SmoothNormals ("Smooth Normals", Range(0.000000,1.000000)) = 0.500000
[Header(Reflection and Refraction)] [Toggle]  _UseReflectionProbe ("Use Reflection Probe", Float) = 0.000000
 _FresnelPower ("Fresnel Power", Range(0.000000,10.000000)) = 2.000000
 _DepthOffset ("Depth Offset", Float) = 1.000000
 _DepthFalloff ("Depth Falloff", Float) = 3.000000
 _AbsorptionColor ("Absorption Color", Color) = (0.000000,0.751724,1.000000,1.000000)
 _AbsorptionIntensity ("Absorption Intensity", Range(0.000000,10.000000)) = 2.000000
[Header(Edge Control)]  _EdgeColor ("Edge Color", Color) = (1.000000,1.000000,1.000000,1.000000)
 _EdgeIntensity ("Edge Intensity", Range(0.000000,1.000000)) = 1.000000
 _EdgeOffset ("Edge Offset", Float) = 0.950000
 _EdgeFalloff ("Edge Falloff", Float) = 10.000000
[IntRange]  _EdgeLevels ("Edge Levels", Range(1.000000,10.000000)) = 3.000000
[Header(Wave Control)]  _WaveHeight ("Wave Height", Float) = 0.500000
 _WaveCycles ("Wave Cycles", Float) = 1.500000
 _WaveSpeed ("Wave Speed", Float) = 25.000000
 _WaveDirectionZX ("Wave Direction Z-X", Range(0.000000,1.000000)) = 0.000000
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Transparent+0" "FORCENOSHADOWCASTING"="true" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "IsEmissive"="true" }
 GrabPass {
  "GrabScreen1"
 }
 Pass {
  Tags { "QUEUE"="Transparent+0" "FORCENOSHADOWCASTING"="true" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "IsEmissive"="true" }
CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma target 2.0
#include "UnityCG.cginc"
#pragma multi_compile_fog
#define USING_FOG (defined(FOG_LINEAR) || defined(FOG_EXP) || defined(FOG_EXP2))

// uniforms

// vertex shader input data
struct appdata {
  float3 pos : POSITION;
  half4 color : COLOR;
  UNITY_VERTEX_INPUT_INSTANCE_ID
};

// vertex-to-fragment interpolators
struct v2f {
  fixed4 color : COLOR0;
  #if USING_FOG
    fixed fog : TEXCOORD0;
  #endif
  float4 pos : SV_POSITION;
  UNITY_VERTEX_OUTPUT_STEREO
};

// vertex shader
v2f vert (appdata IN) {
  v2f o;
  UNITY_SETUP_INSTANCE_ID(IN);
  UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
  half4 color = IN.color;
  float3 eyePos = UnityObjectToViewPos (float4(IN.pos,1)).xyz;
  half3 viewDir = 0.0;
  o.color = saturate(color);
  // compute texture coordinates
  // fog
  #if USING_FOG
    float fogCoord = length(eyePos.xyz); // radial fog distance
    UNITY_CALC_FOG_FACTOR_RAW(fogCoord);
    o.fog = saturate(unityFogFactor);
  #endif
  // transform position
  o.pos = UnityObjectToClipPos(IN.pos);
  return o;
}

// fragment shader
fixed4 frag (v2f IN) : SV_Target {
  fixed4 col;
  col = IN.color;
  // fog
  #if USING_FOG
    col.rgb = lerp (unity_FogColor.rgb, col.rgb, IN.fog);
  #endif
  return col;
}
ENDCG
 }
}
CustomEditor "ASEMaterialInspector"
Fallback "Unlit/Color"
}