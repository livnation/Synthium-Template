using UnityEngine;

namespace Synthium.Backend.MenuComponents
{
    internal class Gradient : MonoBehaviour
    {
        public Color starting;
        public Color ending;
        public float speed = 0.5f;
        public float spotlightRadius = 0.5f;
        private Material mat;
        private Texture2D tex2d;
        private float time;
        private int frameCount = 0;
        private Color[] pixels;

        public static void AddGradientComponent(GameObject obj, Color start, Color end, float speed = 0.5f, float radius = 0.5f)
        {
            var gradient = obj.AddComponent<Gradient>();
            gradient.starting = start;
            gradient.ending = end;
            gradient.speed = speed;
            gradient.spotlightRadius = radius;
            gradient.Startup();
        }

        private void Startup()
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if (renderer == null) return;
            tex2d = new Texture2D(128, 128, TextureFormat.RGBA32, false);
            mat = new Material(Shader.Find("Unlit/Texture"));
            renderer.material = mat;
            mat.mainTexture = tex2d;
            pixels = new Color[128 * 128];
            UpdateTexture();
        }

        private void UpdateTexture()
        {
            float centerU = 0.5f + 0.4f * Mathf.Cos(time);
            float centerV = 0.5f + 0.4f * Mathf.Sin(time);

            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    float u = (float)x / (128 - 1);
                    float v = (float)y / (128 - 1);
                    float distance = Mathf.Sqrt(Mathf.Pow(u - centerU, 2) + Mathf.Pow(v - centerV, 2));
                    float t = Mathf.Clamp01(distance / spotlightRadius);
                    t = Interpolate(t);
                    t = 1f - t;
                    Color gradientColor = Color.Lerp(starting, ending, t);
                    pixels[y * 128 + x] = gradientColor;
                }
            }
            tex2d.SetPixels(pixels);
            tex2d.Apply();
            frameCount++;
        }

        private float Interpolate(float t)
        {
            return t * t * (3f - 2f * t);
        }

        private void Update()
        {
            time += Time.deltaTime * speed;
            UpdateTexture();
        }
    }
}