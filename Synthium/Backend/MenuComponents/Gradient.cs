using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public static void AddGradientComponent(GameObject obj, Color start, Color end, float flowspeed = 0.5f)
        {
            var gradient = obj.AddComponent<Gradient>();
            gradient.starting = start;
            gradient.ending = end;
            gradient.speed = flowspeed;
            gradient.Startup();
        }
        private void Startup()
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer == null) return;
            tex2d = new Texture2D(128, 128, TextureFormat.RGBA32, false);
            mat = new Material(Shader.Find("Unlit/Texture"));
            mat.mainTexture = tex2d;
            renderer.material = mat;
            pixels = new Color[128 * 128];
            UpdateText();
        }
        private void UpdateText()
        {
            for (int y = 0; y < 128; y++)
            {
                for (int x = 0; x < 128; x++)
                {
                    float u = (float)x / (128 - 1);
                    float v = (float)y / (128 - 1);
                    float t = Mathf.PingPong((u + v) / 2 + time, 1f);
                    t = SmoothStep(t);
                    Color gradientColor = Color.Lerp(starting, ending, t);
                    pixels[y * 128 + x] = gradientColor;
                }
            }
            tex2d.SetPixels(pixels);
            tex2d.Apply();
            frameCount++;
        }

        private float SmoothStep(float t)
        {
            return t * t * (3f - 2f * t);
        }

        private void Update()
        {
            time += Time.deltaTime * speed;
            UpdateText();
        }
    }
}
