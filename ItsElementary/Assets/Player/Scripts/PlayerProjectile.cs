
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public PlayerController playerController;
    public GameManager.Element element;
    public bool basicAttack;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public Sprite basicAttackSprite;
    public Animator animator;
    public GameObject explosion;
    public Explosion explosionController;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public AudioClip explosionAudio;
    void Start()
    {

        element = playerController.elementalMode;
        if (basicAttack)
        {
            animator.SetInteger("Element",3);
            spriteRenderer.sprite = basicAttackSprite;
        }
        else
        {
            animator.SetInteger("Element",(int)element);
            spriteRenderer.sprite = spriteArray[(int)element];
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "Player" && !col.gameObject.name.Contains("Projectile") && !col.gameObject.name.Contains("Healing Orb") && !col.gameObject.name.Contains("Wizard"))
        {
            audioSource.clip = audioClips[(int)element];
            audioSource.Play();
            animator.SetBool("Hit",true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        }
    }

    public void SetBasicAttack(bool bo)
    {
        basicAttack = bo;
    }
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Exploded"))
        {
            Destroy(gameObject);      
        }
    }

    public void Explode()
    {
        audioSource.clip = explosionAudio;
        audioSource.Play();
        explosionController.element = element;
        GameObject explosionClone = Instantiate(explosion);
        explosionClone.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
    }
}
