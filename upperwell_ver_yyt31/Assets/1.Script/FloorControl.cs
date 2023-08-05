using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControl : MonoBehaviour
{

    // 카메라.
    private GameObject main_camera = null;

    // 초기 위치.
    private Vector3 initial_position;

    // 바닥의 폭(X방향).
    public const float WIDTH = 10.0f * 4.0f;

    // 바닥 모델의 수
    public const int MODEL_NUM = 3;

    // ================================================================ //

    void Start()
    {
        // 카메라 인스턴스를 찾는다.
        this.main_camera = GameObject.FindGameObjectWithTag("MainCamera");

        this.initial_position = this.transform.position;

      //  this.GetComponent<Renderer>().enabled = SceneControl.IS_DRAW_DEBUG_FLOOR_MODEL;

    }

    void Update()
    {
        // 지속적으로 바닥의 이동이 반복되도록 설정한다.

#if true
        // 간편한 방법.
        // 바닥이 화면 밖으로 나가게 되면 플레이어의 앞이나 뒤쪽으로 이동한다.
        // 플레이어가 이동 중인 경우에는 문제 발생.


        // 배경 전체(모델 전체가 배치된 경우)의 폭.
        //
        float total_width = FloorControl.WIDTH * FloorControl.MODEL_NUM;

        // 배경 위치.
        Vector3 floor_position = this.transform.position;

        // 카메라 위치.
        Vector3 camera_position = this.main_camera.transform.position;

        if (floor_position.x + total_width / 2.0f < camera_position.x)
        {

            // 앞으로 이동.
            floor_position.x += total_width;

            this.transform.position = floor_position;
        }

        if (camera_position.x < floor_position.x - total_width / 2.0f)
        {

            // 뒤로 이동.
            floor_position.x -= total_width;

            this.transform.position = floor_position;
        }
#else
		// 플레이어 이동 시 대응 방법.

		// 배경 전체(모델 전체가 배치된 경우)의 폭.
		//
		float		total_width = FloorControl.WIDTH*FloorControl.MODEL_NUM;

		Vector3		camera_position = this.main_camera.transform.position;

		float		dist = camera_position.x - this.initial_position.x;

		// 모델은 total_width 의 정수의 배수 위치에 표시된다.
		// 초기 위치의 거리를 배경 전체의 너비로 나누고 반올림한다.

		int			n = Mathf.RoundToInt(dist/total_width);

		Vector3		position = this.initial_position;

		position.x += n*total_width;

		this.transform.position = position;
#endif
    }
}
