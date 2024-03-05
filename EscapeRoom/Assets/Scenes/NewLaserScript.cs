using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class NewLaserScript : MonoBehaviour
{
    [Header("Settings")]
    public LayerMask layerMask;
    public float defaultLength = 50;
    public int numberReflect = 5;


    private LineRenderer _lineRenderer;
    private RaycastHit hit;

    private Ray ray;
    private Vector3 direction;

    public float forcaDeEmpurrao = 10f;
    public string tagAlvo = "blueBall";

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ReflectLaser();

    }

    void ReflectLaser()
    {
        ray = new Ray(transform.position, transform.forward);

        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, transform.position);

        float remainLength = defaultLength;

        for (int i = 0; i < numberReflect; i++)
        {
            // Does the ray intersect any objects
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainLength, layerMask))
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, hit.point);
                remainLength -= Vector3.Distance(ray.origin, hit.point);

                Debug.Log("Raio atingiu um objeto, com a tag: " + hit.collider.tag);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

                if (hit.collider.CompareTag("BlueBall"))
                {
                    Debug.Log("Vai movimentar a tag: " + hit.collider.tag);

                    // Aplica a força ao objeto
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        Vector3 direcao = ray.direction; // Use a direção do raio como a direção da força
                        rb.AddForce(direcao * forcaDeEmpurrao, ForceMode.Impulse);
                    }
                }
                else if (hit.collider.CompareTag("Chain"))
                {
                    Debug.Log("Desativando objeto para a tag: " + hit.collider.tag);

                    // Desative o objeto atingido
                    hit.collider.gameObject.SetActive(false);

                }
                else
                {
                    _lineRenderer.positionCount += 1;
                    _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, ray.origin + (ray.direction * remainLength));
                }

            }
        }

        void NormalLaser()
        {
            _lineRenderer.SetPosition(0, transform.position);

            if (Physics.Raycast(transform.position, transform.forward, out hit, defaultLength, layerMask))
            {
                _lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                _lineRenderer.SetPosition(1, transform.position + (transform.forward * defaultLength));
            }
        }

        void TriggerBall()
        {
            RaycastHit hit;
            // Use o ponto de origem do controlador VR em vez do mouse
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o raio atingiu um objeto com a tag específica
                if (hit.collider.CompareTag("BlueBall"))
                {
                    // Aplica a força ao objeto
                    Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        Vector3 direcao = ray.direction; // Use a direção do raio como a direção da força
                        rb.AddForce(direcao * forcaDeEmpurrao, ForceMode.Impulse);
                    }
                }
                else
                {
                    Debug.Log("Raio atingiu um objeto, mas não com a tag esperada: " + hit.collider.tag);
                }
            }
            else
            {
                Debug.Log("Raio não atingiu nenhum objeto.");
            }
        }
    }
}