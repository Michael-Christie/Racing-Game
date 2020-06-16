Shader "Custom/MeshColor"
{
	Properties
	{
	  _HeightMin("Height Min", Float) = -1
	  _HeightMax("Height Max", Float) = 1
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		float _HeightMin;
		float _HeightMax;

		const static int maxColorCount = 8;
		const static float epsilon = 1E-4;

		int baseColorCount;
		float3 baseColors[maxColorCount];
		float baseStartHeight[maxColorCount];
		float baseBlends[maxColorCount];


        struct Input
        {
			float3 worldPos;
        };

		float inverserLerp(float a, float b, float v) {
			return saturate((v - a) / (b - a));
		}

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
			float hPercent = inverserLerp(_HeightMin, _HeightMax, IN.worldPos.y);
			//o.Albedo = hPercent;

			for (int i = 0; i < baseColorCount; i++) {
				float drawStrength = inverserLerp(-baseBlends[i]/2, baseBlends[i]/2, hPercent - baseStartHeight[i]);
				o.Albedo = o.Albedo * (1 - drawStrength) + baseColors[i] * drawStrength;
			}
        }
        ENDCG
    }
    FallBack "Diffuse"
}
