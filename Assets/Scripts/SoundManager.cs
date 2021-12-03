using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    private AudioSource music;
   
    // Start is called before the first frame update
    private void Awake() {
        if (instance != null) {
            Destroy(this.gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        music = GetComponent<AudioSource>();
    }

    public void changeVolume(Slider slider) {
        if (music != null) {
            music.volume = slider.value;
        }
    }
}
