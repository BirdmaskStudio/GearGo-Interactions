// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33465,y:32710,varname:node_3138,prsc:2|emission-9387-OUT,alpha-4725-OUT,clip-4886-OUT,voffset-9297-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32699,y:32854,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9926471,c2:0.3138517,c3:0.3138517,c4:0.4;n:type:ShaderForge.SFN_Tex2d,id:6534,x:32699,y:32655,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_6534,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:2,isnm:False|UVIN-4864-OUT;n:type:ShaderForge.SFN_RemapRange,id:4864,x:32524,y:32655,varname:node_4864,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8878-UVOUT;n:type:ShaderForge.SFN_ScreenPos,id:8878,x:32354,y:32655,varname:node_8878,prsc:2,sctp:1;n:type:ShaderForge.SFN_Multiply,id:9387,x:33000,y:32704,varname:node_9387,prsc:2|A-6534-RGB,B-7241-RGB;n:type:ShaderForge.SFN_Multiply,id:4725,x:33000,y:32824,varname:node_4725,prsc:2|A-6534-A,B-7241-A;n:type:ShaderForge.SFN_Multiply,id:8195,x:32914,y:32944,varname:node_8195,prsc:2|A-6534-A;n:type:ShaderForge.SFN_Multiply,id:2317,x:33197,y:32704,varname:node_2317,prsc:2|A-9387-OUT,B-7241-A;n:type:ShaderForge.SFN_Slider,id:7261,x:32709,y:33172,ptovrint:False,ptlb:OpacityClip,ptin:_OpacityClip,varname:node_7261,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4886,x:33159,y:33201,varname:node_4886,prsc:2|A-6534-A,B-7261-OUT;n:type:ShaderForge.SFN_NormalVector,id:2458,x:32728,y:33251,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9297,x:33015,y:33339,cmnt:Wind animation,varname:node_9297,prsc:2|A-2458-OUT,B-1103-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1103,x:32710,y:33442,ptovrint:False,ptlb:Inflate,ptin:_Inflate,varname:node_3208,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:7241-6534-7261-1103;pass:END;sub:END;*/

Shader "Shader Forge/OverlayEffect" {
    Properties {
        _Color ("Color", Color) = (0.9926471,0.3138517,0.3138517,0.4)
        _MainTex ("MainTex", 2D) = "black" {}
        _OpacityClip ("OpacityClip", Range(0, 1)) = 0
        _Inflate ("Inflate", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _OpacityClip;
            uniform float _Inflate;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float3 normalDir : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                v.vertex.xyz += (v.normal*_Inflate);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 normalDirection = i.normalDir;
                float2 node_4864 = (float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg*2.0+-1.0);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_4864, _MainTex));
                clip((_MainTex_var.a*_OpacityClip) - 0.5);
////// Lighting:
////// Emissive:
                float3 node_9387 = (_MainTex_var.rgb*_Color.rgb);
                float3 emissive = node_9387;
                float3 finalColor = emissive;
                return fixed4(finalColor,(_MainTex_var.a*_Color.a));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _OpacityClip;
            uniform float _Inflate;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float3 normalDir : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                v.vertex.xyz += (v.normal*_Inflate);
                o.pos = UnityObjectToClipPos( v.vertex );
                o.screenPos = o.pos;
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3 normalDirection = i.normalDir;
                float2 node_4864 = (float2(i.screenPos.x*(_ScreenParams.r/_ScreenParams.g), i.screenPos.y).rg*2.0+-1.0);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_4864, _MainTex));
                clip((_MainTex_var.a*_OpacityClip) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
