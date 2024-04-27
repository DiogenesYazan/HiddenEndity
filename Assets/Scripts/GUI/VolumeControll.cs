using UnityEngine;
using UnityEngine.UI; // Biblioteca UI para usar o Slider

public class VolumeControll : MonoBehaviour
{
    public Slider volumeSlider; // Referência para o Slider
    public AudioSource audioSource; // Referência para o AudioSource

    void Start()
    {
        // Inicializa o slider com o valor atual do volume
        volumeSlider.value = audioSource.volume;
    }

    public void ChangeVolume()
    {
        // Ajusta o volume com o valor atual do slider
        audioSource.volume = volumeSlider.value;
    }
}
