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
        sequence.AppendInterval(1f);
        sequence.Append(transform.DORotate(new Vector3(0, 180, 0), 0.5f));
        //sequence.Append(transform.GetComponent<MeshRenderer>().material.DOColor(Color.red, 1f));
        sequence.Join(transform.GetComponent<MeshRenderer>().material.DOColor(Color.red, 1f));

        var sequence2 = DOTween.Sequence();
        sequence2.Append(transform.DOScale(1,1).SetEase(Ease.InBounce));
        sequence2.Join(transform.GetComponent<MeshRenderer>().material.DOColor(Color.white, 1f));


        sequence.Append(sequence2);
        sequence.OnComplete(SayHi);
    }
    public void SayHi() {
        Debug.Log("fini");

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
