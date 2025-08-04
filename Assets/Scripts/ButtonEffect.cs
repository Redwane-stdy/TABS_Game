using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [SerializeField] private ParticleSystem particleEffect1;
    [SerializeField] private ParticleSystem particleEffect2;

    public void OnPointerEnter(PointerEventData eventData)
    {
            particleEffect1.Play();
            particleEffect2.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
            particleEffect1.Stop();
            particleEffect2.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
