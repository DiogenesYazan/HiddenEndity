using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QualitySettingsDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    void Start()
    {
        // Preenche o dropdown com as opções de qualidade, exceto 'very low'
        dropdown.ClearOptions();
        List<string> options = new List<string>(QualitySettings.names);
        options.RemoveAt(0); // Remove 'very low' assumindo que é o primeiro na lista
        dropdown.AddOptions(options);

        // Define o valor atual do dropdown para a qualidade atual, ajustando para o índice correto
        dropdown.value = QualitySettings.GetQualityLevel() - 1;
        dropdown.RefreshShownValue();

        // Adiciona um listener para quando o valor do dropdown mudar
        dropdown.onValueChanged.AddListener(delegate {
            SetQuality(dropdown.value);
        });
    }

    public void SetQuality(int qualityIndex)
    {
        // Muda o nível de qualidade baseado no índice selecionado, ajustando para o índice correto
        QualitySettings.SetQualityLevel(qualityIndex + 1, true);
    }
}
