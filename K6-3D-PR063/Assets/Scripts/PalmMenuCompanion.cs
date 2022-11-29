
using NRKernal;
using UnityEngine;
using UnityEngine.UI;
using static NRKernal.NRExamples.GestureSimpleTip;


public class PalmMenuCompanion : MonoBehaviour
{

    public HandEnum currentHand; // left or right
    public Transform menuAnchor;
    public Text gestureTxt;
    public Button mainButton;

    // demo zone

    public string[] Texts = new string[] { "Dummy", "World", "Text", "Maecenas" };

    // Update is called once per frame
    void Update()
    {
        UpdateMenuVisibility();
    }

    private void UpdateMenuVisibility()
    {
        // grab the current hand state
        var handState = NRInput.Hands.GetHandState(currentHand);

        // guard if the current hand state is not allocated or initialized
        // https://stackoverflow.com/a/62808049
        if (handState == null)
            return;

        //switch (handState.currentGesture)
        //{
        //    case HandGesture.OpenHand:
        //        //palm menu should be showen only in openHand state
        //        gestureTxt.text = GestureName.Gesture_Open_Hand;
        //        mainButton.gameObject.SetActive(true);
        //        break;
        //    default:
        //        //hide palm menu
        //        gestureTxt.text = string.Empty;
        //        mainButton.gameObject.SetActive(false);
        //        break;
        //}

        if (handState.isTracked)
        {

            switch (handState.currentGesture)
            {
                case HandGesture.OpenHand:
                    //palm menu should be showen only in openHand state
                    //gestureTxt.text = GestureName.Gesture_Open_Hand;
                    mainButton.gameObject.SetActive(true);
                    break;
                default:
                    //hide palm menu
                    //gestureTxt.text = string.Empty;
                    mainButton.gameObject.SetActive(false);
                    break;
            }

            float palmToFaceCoefficient = 0.8f;
            float currentPalmRotation = handState.GetJointPose(HandJointID.Palm).rotation.y;
            //Pose testPose = handState.GetJointPose(HandJointID.Palm);
            //gestureTxt.text = testPose.rotation.y.ToString();//testPose.ToString();

            Pose palmPose;
            if (handState.jointsPoseDict.TryGetValue(HandJointID.Palm, out palmPose))
            {
                TransformAnchorWith(palmPose.position);
            }

            //menuAnchor.gameObject.SetActive(!string.IsNullOrEmpty(gestureTxt.text));
            menuAnchor.gameObject.SetActive(mainButton.gameObject.activeSelf && (currentPalmRotation >= palmToFaceCoefficient));
        }
        else
        {
            menuAnchor.gameObject.SetActive(false);
        }
    }

    // stick to hand position
    private void TransformAnchorWith(Vector3 jointPosition)
    {
        var myDown = new Vector3(0, -5, 0);
        var vec_from_head = jointPosition - Camera.main.transform.position;
        var vec_horizontal = Vector3.Cross(Vector3.down, vec_from_head).normalized;
        //menuAnchor.position = jointPosition + Vector3.up * 0.08f - vec_horizontal * 0.015f;
        //place in hand (up/down, left/right, front/back)
        menuAnchor.position = jointPosition + Vector3.up * 0.01f - vec_horizontal * 0.005f;
        menuAnchor.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(vec_from_head, Vector3.up), Vector3.up);
    }

    // Buttons zone

    public void OnMainButtonPress()
    {
        int textIndex = UnityEngine.Random.Range(0, Texts.Length);
        gestureTxt.text = Texts[textIndex];
    }
}
