using UnityEngine;

[System.Serializable]
public class MusicPlayer : MonoBehaviour
{

	static MusicPlayer musicPlayer;
	private AudioSource audioSrc;
	private SettingsManager settings;
	private string currentSongName;

	public float volume = 0.0f;
	public AudioMap[] audioMap;

	protected void Awake ()
	{
		musicPlayer = this;
	}

	protected void Start ()
	{
		// Prevent MusicPlayer from being destroyed on Scene Changes
		DontDestroyOnLoad (this);

		audioSrc = GetComponent<AudioSource> ();
		settings = GameObject.Find ("SettingsManager").GetComponent<SettingsManager> ();

		// hack to set the 3d distance everywhere, so 2d sound can be heard everywhere
		// what are the performance implications of this?
		audioSrc.rolloffMode = AudioRolloffMode.Linear;
		audioSrc.maxDistance = float.MaxValue;
		audioSrc.volume = settings.musicVolume;
	}

	protected void Update ()
	{
		if (audioSrc != null && settings != null) {
			audioSrc.volume = settings.musicVolume;
		}
	}

	public void ChangeAudio (string key)
	{
		int index = SceneHasAudio (key);
		AudioMap map;
		if (index > -1) {
			map = audioMap [index];
			if (currentSongName != map.clip.name) {
				currentSongName = map.clip.name;
				audioSrc.clip = map.clip;
				audioSrc.loop = map.loop == true;
				audioSrc.Play ();
			}

		} else {
			print ("[INFO] MusicPlayer - ChangeAudio() resource " + key + " not found");
		}
	}

	protected void OnDestroy ()
	{
		if (musicPlayer != null) {
			musicPlayer = null;
		}
	}

	protected void FadeOut ()
	{
		if (volume > 0.1f) {
			volume -= 0.1f * Time.deltaTime;
			audioSrc.volume = volume;
		}	
	}

	protected void FadeIn ()
	{
		if (volume < 1.0f) {
			volume += 1.0f * Time.deltaTime;
			audioSrc.volume = volume;
		}	
	}

	[System.Serializable]
	public class AudioMap
	{
		public string key;
		public AudioClip clip;
		public bool loop;
	}

	private int SceneHasAudio (string key)
	{
		int _audio = -1;
		for (int i = 0; i < audioMap.Length; i++) {
			if (audioMap [i].key == key) {
				_audio = i;
			}
		}
		return _audio;
	}
}