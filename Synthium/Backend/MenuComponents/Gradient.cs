using UnityEngine;

namespace Synthium.Backend.MenuComponents
{
    internal class Gradient : MonoBehaviour
    {
        public Color starting;
        public Color ending;
        public float speed;
        private Material mat;
        private Texture2D tex2d;
        private float time;
        private int frameCount = 0;
        private Color[] pixels;
        public static void AddGradientComponent(GameObject obj, Color start, Color end, float speed = 0.5f)
        {
            var gradient = obj.AddComponent<Gradient>();
            gradient.starting = start;
            gradient.ending = end;
            gradient.speed = speed;
            gradient.Startup();
        }
        private void Startup()
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if (renderer == null) return;
            tex2d = new Texture2D(128, 128, TextureFormat.RGBA32, false);
            // do not change to ubershader or gradient will not work
            mat = new Material(Shader.Find("Unlit/Texture"));
            renderer.material = mat;
            mat.mainTexture = tex2d;
            pixels = new Color[128 * 128];
            UpdateTexture();
        }
        private void UpdateTexture()
        {
            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    float u = (float)x / (128 - 1);
                    float v = (float)y / (128 - 1);
                    float t = Mathf.PingPong((u + v) / 2 + time, 1f);
                    t = Interpolate(t);
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
