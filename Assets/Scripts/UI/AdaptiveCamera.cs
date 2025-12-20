using Unity.Cinemachine;
using UnityEngine;

namespace UI
{
    public class AdaptiveCamera : MonoBehaviour
    {
        [SerializeField] private CinemachineGroupFraming _cgfStage;
        [SerializeField] private CinemachineGroupFraming _cgfBoard;
        [SerializeField] private Camera _camera;

        [Space]
        [Space]
        [Header("Stage:")]
        [Header("Landscape long settings")]
        [SerializeField] private float _framingStageLL;
        [SerializeField] private Vector2 _offsetStageLL;

        [Space]
        [Header("Landscape short settings")]
        [SerializeField] private float _framingStageLS;
        [SerializeField] private Vector2 _offsetStageLS;

        [Space]
        [Header("Portrait short settings")]
        [SerializeField] private float _framingStagePS;
        [SerializeField] private Vector2 _offsetStagePS;

        [Space]
        [Header("Portrait long settings")]
        [SerializeField] private float _framingStagePL;
        [SerializeField] private Vector2 _offsetStagePL;

        [Space]
        [Space]
        [Header("Board:")]
        [Header("Landscape long settings")]
        [SerializeField] private float _framingBoardLL;
        [SerializeField] private Vector2 _offsetBoardLL;

        [Space]
        [Header("Landscape short settings")]
        [SerializeField] private float _framingBoardLS;
        [SerializeField] private Vector2 _offsetBoardLS;

        [Space]
        [Header("Portrait short settings")]
        [SerializeField] private float _framingBoardPS;
        [SerializeField] private Vector2 _offsetBoardPS;

        [Space]
        [Header("Portrait long settings")]
        [SerializeField] private float _framingBoardPL;
        [SerializeField] private Vector2 _offsetBoardPL;

        private void Update()
        {
            float aspectRatio = (float)Screen.width / Screen.height;

            switch (aspectRatio)
            {
                case >= 2f:
                    _cgfBoard.FramingSize = _framingBoardLL;
                    _cgfBoard.CenterOffset = _offsetBoardLL;
                    _cgfStage.FramingSize = _framingStageLL;
                    _cgfStage.CenterOffset = _offsetStageLL;
                    break;
                case >= 1f:
                    _cgfBoard.FramingSize = Mathf.Lerp(_framingBoardLS, _framingBoardLL, aspectRatio - 1);
                    _cgfBoard.CenterOffset = Vector2.Lerp(_offsetBoardLS, _offsetBoardLL, aspectRatio - 1);
                    _cgfStage.FramingSize = Mathf.Lerp(_framingStageLS, _framingStageLL, aspectRatio - 1);
                    _cgfStage.CenterOffset = Vector2.Lerp(_offsetStageLS, _offsetStageLL, aspectRatio - 1);
                    break;
                case >= .5f:
                    _cgfBoard.FramingSize = Mathf.Lerp(_framingBoardPL, _framingBoardPS, aspectRatio * 2 - 1);
                    _cgfBoard.CenterOffset = Vector2.Lerp(_offsetBoardPL, _offsetBoardPS, aspectRatio * 2 - 1);
                    _cgfStage.FramingSize = Mathf.Lerp(_framingStagePL, _framingStagePS, aspectRatio * 2 - 1);
                    _cgfStage.CenterOffset = Vector2.Lerp(_offsetStagePL, _offsetStagePS, aspectRatio * 2 - 1);
                    break;
                case < .5f:
                    _cgfBoard.FramingSize = _framingBoardPL;
                    _cgfBoard.CenterOffset = _offsetBoardPL;
                    _cgfStage.FramingSize = _framingStagePL;
                    _cgfStage.CenterOffset = _offsetStagePL;
                    break;
            }
        }
    }
}