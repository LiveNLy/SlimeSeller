using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _mat;
    [SerializeField] private Material _secondMat;

    private Vector3 _center;

    public ParticleSystem Particles => _particle;

    private void Awake()
    {
        _particle = GetComponent<ParticleSystem>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _center = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.6f);
    }

    public void GlowUp()
    {
        if (CanGlow())
        {
            _particle.Play();
            _meshRenderer.material = _secondMat;
        }
    }

    public void StopGlowing()
    {
        _particle.Stop();
        _meshRenderer.material = _mat;
    }

    public bool CanGlow()
    {
        Collider[] colliders = Physics.OverlapSphere(_center, 0.6f);

        foreach (Collider collider in colliders)
        {
            if (collider.GetComponent<Basket>())
            {
                return false;
            }
        }

        return true;
    }
}