using UnityEngine;

namespace Synthium.Backend.MenuComponents
{
    public class ColorLerp : MonoBehaviour
    {
        private MeshRenderer meshrenderer;
        private Color start;
        private Color end;
        private float time;
        private bool guishader;
        public void Initialize(MeshRenderer renderer, Color first, Color last, float t, bool seethrough)
        {
            meshrenderer = renderer;
            start = first;
            end = last;
            time = t;
            guishader = seethrough;
        }
        void Start()
        {
            if (guishader)
                meshrenderer.material.shader = Shader.Find("GUI/Text Shader");
        }

        void Update()
        {
            meshrenderer.material.color = Color.Lerp(start, end, Mathf.PingPong(Time.time * time, 1f));
        }
    }
}
