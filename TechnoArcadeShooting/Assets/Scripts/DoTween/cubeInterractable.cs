using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeInterractable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(2, 1f).SetEase(Ease.OutBounce));
        sequence.Append(transform.DORotate(new Vector3(0, 180, 0), 0.5f));
        //sequence.Append(transform.GetComponent<MeshRenderer>().material.DOColor(Color.red, 1f));
        sequence.Join(transform.GetComponent<MeshRenderer>().material.DOColor(Color.red, 1f));


    }
    private void OnMouseExit()
    {
        transform.DOScale(1, 1f);
    }
    private void OnMouseDown()
    {
        transform.DORotate(new Vector3(0, 180, 0), 0.5f);
        transform.GetComponent<MeshRenderer>().material.DOColor(Color.red, 1f);
    }
}
