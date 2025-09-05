using UnityEngine;

public class danceController : MonoBehaviour
{
    [SerializeField] private Animator[] animators;
    [SerializeField] private AudioClip[] audios;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject[] characters;
    public int indexCharacter = 0;
    public bool baila = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (indexCharacter <= characters.Length-2)
            {
                indexCharacter++;
            }else
            {
                indexCharacter = 0;
            }

            characters[indexCharacter].SetActive(false);

            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].SetActive(false);
            }
            characters[indexCharacter].SetActive(true);

            if (baila)
            {
                animators[indexCharacter].SetBool("baila", true);
                audioSource.clip = audios[indexCharacter];

                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
                else
                {
                    animators[indexCharacter].SetBool("baila", false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))      
        {
            baila = true;
            animators[indexCharacter].SetBool("baila", true);
            audioSource.clip=audios[indexCharacter];

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            baila = false;
            animators[indexCharacter].SetBool("baila", false);
            audioSource.Stop();
        }
    }
}
