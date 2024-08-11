using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuggetModelController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_defaultModel;

    [SerializeField]
    private GameObject m_heartModel;

    [SerializeField]
    private GameObject m_number1Model;

    [SerializeField]
    private GameObject m_number3Model;

    [SerializeField]
    private GameObject m_number4Model;

    [SerializeField]
    private GameObject m_holeModel;

    private GameObject m_activeModel;

    public enum NuggetModelType { DEFAULT, HEART, NUMBER1, NUMBER3, NUMBER4, HOLE };

    public GameObject GetActiveModel() => m_activeModel;

    public void ScaleModel(float modelMultiplier)
    {
        m_activeModel.transform.localScale *= modelMultiplier;
    }

    public void ShowModel(NuggetModelType modelType)
    {
        m_activeModel.SetActive(false);
        ResetModel(m_activeModel);

        switch (modelType)
        {
            case NuggetModelType.DEFAULT:
                m_activeModel = m_defaultModel;
                break;
            case NuggetModelType.HEART:
                m_activeModel = m_heartModel;
                break;
            case NuggetModelType.NUMBER1:
                m_activeModel = m_number1Model;
                break;
            case NuggetModelType.NUMBER3:
                m_activeModel = m_number3Model;
                break;
            case NuggetModelType.NUMBER4:
                m_activeModel = m_number4Model;
                break;
            case NuggetModelType.HOLE:
                m_activeModel = m_holeModel;
                break;
        }
        m_activeModel.SetActive(true);
    }

    public void ResetModels()
    {
        ResetModel(m_defaultModel);
        ResetModel(m_heartModel);
        ResetModel(m_number1Model);
        ResetModel(m_number3Model);
        ResetModel(m_number4Model);
        ResetModel(m_holeModel);
    }

    private void Start()
    {
        m_activeModel = m_defaultModel;
    }

    private void ResetModel(GameObject model)
    {
        model.transform.localScale = Vector3.one * 100f;
        model.transform.localPosition = new Vector3(0f, -1.18f, 0f);
    }
}
