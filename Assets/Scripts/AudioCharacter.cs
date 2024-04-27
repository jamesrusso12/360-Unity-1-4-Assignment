using UnityEngine;

public class PowerupSound : MonoBehaviour
{
    public AudioClip powerupSound;
    private AudioSource audioSource;

    private void Start()
    {
        // Add an AudioSource component to the player object if it doesn't exist
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the powerup sound to the audio source
        audioSource.clip = powerupSound;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is a powerup
        if (other.CompareTag("Powerup"))
        {
            // Calculate pitch based on the size of the powerup
            float powerupSize = other.transform.localScale.magnitude;
            float minSize = 1f; // Minimum size of the powerup
            float maxSize = 5f; // Maximum size of the powerup
            float normalizedSize = Mathf.Clamp01((powerupSize - minSize) / (maxSize - minSize));
            float pitch = Mathf.Lerp(1.5f, 0.5f, normalizedSize); // Adjust pitch range here

            // Set the pitch of the audio source
            audioSource.pitch = pitch;

            // Play the powerup sound
            audioSource.Play();
        }
    }
}
