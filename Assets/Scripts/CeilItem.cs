using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilItem : MonoBehaviour
{
    public int rIdx { get; private set; }
    public int cIdx { get; private set; }
   
    public int number;
    private SpriteRenderer sp;

    private void Awake()
    {
        sp = transform.Find("Square").GetComponent<SpriteRenderer>();
    }


    public void Init(int number, int rIdx, int cIdx)
    {
        this.number = number;
        this.rIdx = rIdx;
        this.cIdx = cIdx;

        UpdateSp(this.number);
    }

    public void updateRandCIdx(int rIdx, int cIdx)
    {
        this.rIdx = rIdx;
        this.cIdx = cIdx;
    }

    private void OnMouseDown()
    {
        if (number == 0) return;

        var printStr = $"rIdx:{rIdx},cIdx:{cIdx},number:{number}";
        MiniGame1Manager.Inst.CheckSwap(rIdx, cIdx, number);
        Debug.Log(printStr);
    }

    public void UpdateSp(int number)
    {
        if (number == 0) {
            sp.sprite = null;
        } else {
            int idx = number - 1;
            sp.sprite = MiniGame1Manager.Inst.mapSps[idx];
        }

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
