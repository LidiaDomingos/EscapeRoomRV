using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SeuScript : MonoBehaviour
{

    string[] ordemDasTags = { "Tag1", "Tag2", "Tag3" };

    void Update()
    {
        // Acesse o objeto pai
        Transform pai = transform;

        // Itere sobre todos os filhos do objeto pai
        foreach (Transform filho in pai)
        {
            // Acesse o objeto Socket dentro de cada filho
            XRSocketInteractor socketInteractor = filho.GetComponentInChildren<XRSocketInteractor>();

            // Verifique se o Socket foi encontrado
            if (socketInteractor != null)
            {
                // Acesse o objeto que est� interagindo com o Socket
#pragma warning disable CS0618 // Type or member is obsolete
                XRBaseInteractable interagivelAtual = socketInteractor.selectTarget;
#pragma warning restore CS0618 // Type or member is obsolete

                // Verifique se h� um objeto interagindo
                if (interagivelAtual != null)
                {
                    // Acesse a tag do objeto interagindo
                    string tagDoObjetoInteragindo = interagivelAtual.gameObject.tag;

                    // Fa�a algo com a tag (por exemplo, imprima no console)
                    Debug.Log("Tag do objeto interagindo: " + tagDoObjetoInteragindo);
                }
            }
        }
    }

    bool VerificarOrdemDasTags(string tagAtual)
    {
        int contador = 0;
        // Itere sobre a ordem desejada das tags
        for (int i = 0; i < ordemDasTags.Length; i++)
        {
            // Verifique se a tag atual corresponde � ordem
            if (tagAtual == ordemDasTags[i])
            {
                contador++;
            }
        }
        if(contador == ordemDasTags.Length )
        {
            return true;
        }
        // Se chegou at� aqui, significa que todas as tags est�o na ordem correta
        return false;
    }
}
