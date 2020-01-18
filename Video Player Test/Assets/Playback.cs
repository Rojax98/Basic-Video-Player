using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Playback : MonoBehaviour
{
    public VideoPlayer vP;
    public ulong frames;
    public GameObject slider;

    public float playbackPercent;

    bool pause;
    bool play;
    bool spacePause;

    // Start is called before the first frame update
    void Start()
    {
        vP = GetComponent<VideoPlayer>();

        vP.Prepare();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (slider.GetComponent<PlaybackSlider>().drag == false)
        {
            if(play == false && spacePause == false)
            {

                vP.Play();
                play = true;

            }

            pause = false;
            frames = vP.frameCount;

            if (Input.GetKey(KeyCode.S))
            {

                vP.frame = 500;

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (vP.isPlaying == true)
                {
                    spacePause = true;
                    vP.Pause();
                }
                else
                {

                    spacePause = false;
                    vP.Play();
                }

            }

            playbackPercent = ((float)vP.frame / 1047);

            slider.transform.localPosition = new Vector2(-245 + (490 * playbackPercent), slider.transform.localPosition.y);

        }
        else
        {
            play = false;

            if (pause == false)
            {
                vP.Pause();
                pause = true;
            }

            var currentPos = 245 + slider.transform.localPosition.x;

            var currentPercent = (currentPos / 590);

            var frames = (float)1047 * (float)currentPercent;

            vP.frame = (long)frames;

        }
    }
}
