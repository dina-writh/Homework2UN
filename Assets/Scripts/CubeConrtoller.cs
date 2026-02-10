using UnityEngine;

public class CubeConrtoller : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;
    [SerializeField] private int _minNewCubs = 2;
    [SerializeField] private int _maxNewCubs = 6;
    [SerializeField] private float _scaleReductionFactor = 0.5f;
    [SerializeField] private float _explosionForce = 5f;
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private GameObject _cubePrefab;

    private float _randomValue;
    private int _newCubesCount;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = true;
    }

    private void OnMouseDown()
    {
        Split();
    }

    private void Split()
    {
        float randomValue = Random.value;

        if (randomValue <= _splitChance) 
        {
            int newCubesCount = Random.Range(_minNewCubs, _maxNewCubs + 1);
            Vector3 newScale = transform.localScale * _scaleReductionFactor; 

            for (int i = 0; i < newCubesCount; i++)
            {
                GameObject newCube = Instantiate(_cubePrefab, transform.position, Random.rotation);

                newCube.transform.localScale = newScale;

                Renderer newRenderer = newCube.GetComponent<Renderer>();
                if (newRenderer != null)
                    newRenderer.material.color = Random.ColorHSV();

                Rigidbody newRigidbody = newCube.GetComponent<Rigidbody>();
                if (newRigidbody != null)
                {
                    newRigidbody.useGravity = true;

                    Vector3 explosionDirection = Random.insideUnitSphere.normalized;
                    newRigidbody.AddForce(explosionDirection * _explosionForce, ForceMode.Impulse);
                }

                CubeConrtoller newController = newCube.GetComponent<CubeConrtoller>();
                if (newController != null)
                    newController._splitChance = _splitChance / 2f;
            }
        }

        Destroy(gameObject);
    }
}
