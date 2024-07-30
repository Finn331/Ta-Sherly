using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Slider videoSlider;
    public Button pauseButton;
    public Button unpauseButton;
    public Button nextButton;
    public Button prevButton;
    public VideoClip[] videoClips;

    private int currentVideoIndex = 0;
    private bool isDragging;

    public Image pauseButtonImage;
    public Image unpauseButtonImage;

    void Start()
    {
        videoPlayer.clip = videoClips[currentVideoIndex];
        videoSlider.maxValue = (float)videoPlayer.length;

        videoSlider.onValueChanged.AddListener(OnSliderValueChanged);
        pauseButton.onClick.AddListener(PauseVideo);
        unpauseButton.onClick.AddListener(UnpauseVideo);
        nextButton.onClick.AddListener(NextVideo);
        prevButton.onClick.AddListener(PreviousVideo);

        // EventTrigger untuk slider
        EventTrigger trigger = videoSlider.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((eventData) => { OnPointerDown(); });
        trigger.triggers.Add(entryDown);

        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((eventData) => { OnPointerUp(); });
        trigger.triggers.Add(entryUp);

        // Image component setup
        pauseButtonImage = pauseButton.GetComponent<Image>();
        if (pauseButtonImage == null)
        {
            Debug.LogError("Pause button does not have an Image component");
        }

        unpauseButtonImage = unpauseButton.GetComponent<Image>();
        if (unpauseButtonImage == null)
        {
            Debug.LogError("Unpause button does not have an Image component");
        }

        videoPlayer.playOnAwake = false;
        videoPlayer.Play();

        // Set initial button states
        UpdateButtonStates();
    }

    void Update()
    {
        if (!isDragging && videoPlayer.isPlaying)
        {
            videoSlider.value = (float)videoPlayer.time;
        }

        if (videoPlayer.time >= videoPlayer.length)
        {
            NextVideo();
        }

        // Check video player status and update buttons
        UpdateButtonStates();
    }

    void OnSliderValueChanged(float value)
    {
        if (isDragging)
        {
            videoPlayer.time = value;
        }
    }

    public void OnPointerDown()
    {
        isDragging = true;
        videoPlayer.Pause();
    }

    public void OnPointerUp()
    {
        isDragging = false;
        videoPlayer.time = videoSlider.value;
        videoPlayer.Play();
    }

    void PauseVideo()
    {
        if (pauseButtonImage != null)
        {
            LeanTween.alpha(pauseButtonImage.rectTransform, 0, 0.5f).setOnComplete(() => {
                pauseButton.gameObject.SetActive(false);
                unpauseButton.gameObject.SetActive(true);
                if (unpauseButtonImage != null)
                {
                    LeanTween.alpha(unpauseButtonImage.rectTransform, 1, 0.5f);
                }
            });
        }
        videoPlayer.Pause();
    }

    void UnpauseVideo()
    {
        if (unpauseButtonImage != null)
        {
            LeanTween.alpha(unpauseButtonImage.rectTransform, 0, 0.5f).setOnComplete(() => {
                unpauseButton.gameObject.SetActive(false);
                pauseButton.gameObject.SetActive(true);
                if (pauseButtonImage != null)
                {
                    LeanTween.alpha(pauseButtonImage.rectTransform, 1, 0.5f);
                }
            });
        }
        videoPlayer.Play();
    }

    void NextVideo()
    {
        if (currentVideoIndex < videoClips.Length - 1)
        {
            currentVideoIndex++;
            PlayVideoAtIndex();
        }
    }

    void PreviousVideo()
    {
        if (currentVideoIndex > 0)
        {
            currentVideoIndex--;
            PlayVideoAtIndex();
        }
    }

    void PlayVideoAtIndex()
    {
        videoPlayer.clip = videoClips[currentVideoIndex];
        videoSlider.maxValue = (float)videoPlayer.length;
        videoPlayer.time = 0;
        videoSlider.value = 0;
        videoPlayer.Play();
    }

    void UpdateButtonStates()
    {
        if (videoPlayer.isPlaying)
        {
            // Ensure pause button is visible and unpause button is hidden
            if (!pauseButton.gameObject.activeSelf)
            {
                pauseButton.gameObject.SetActive(true);
                LeanTween.alpha(pauseButtonImage.rectTransform, 1, 0.5f);
            }
            if (unpauseButton.gameObject.activeSelf)
            {
                LeanTween.alpha(unpauseButtonImage.rectTransform, 0, 0.5f).setOnComplete(() => {
                    unpauseButton.gameObject.SetActive(false);
                });
            }
        }
        else
        {
            // Ensure unpause button is visible and pause button is hidden
            if (!unpauseButton.gameObject.activeSelf)
            {
                unpauseButton.gameObject.SetActive(true);
                LeanTween.alpha(unpauseButtonImage.rectTransform, 1, 0.5f);
            }
            if (pauseButton.gameObject.activeSelf)
            {
                LeanTween.alpha(pauseButtonImage.rectTransform, 0, 0.5f).setOnComplete(() => {
                    pauseButton.gameObject.SetActive(false);
                });
            }
        }
    }
}
