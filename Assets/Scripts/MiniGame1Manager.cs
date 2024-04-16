using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGame1Manager : MonoBehaviour
{


    public static MiniGame1Manager Inst;

    public TMP_Text winText;

    public GameObject CeilItem;

    public List<Sprite> mapSps;

    public Vector2 mapCenterOffset = Vector2.zero;

    private int row = 3;
    private int col = 3;
    int totalCeilCount;

    public List<int> numbers;

    private Dictionary<int, CeilItem> dataDict = new Dictionary<int, CeilItem>();

    void Shuffle(List<int> listObj)
    {
        for (int i = 0; i < 50; i++)
        {
            int randomMove = Random.Range(0, 4);
            int emptyIndex = listObj.IndexOf(0);
            int emptyRow = emptyIndex / col;
            int emptyCol = emptyIndex % col;

            switch (randomMove)
            {
                case 0:
                    if (emptyRow > 0)
                    {
                        int targetIndex = emptyIndex - col;
                        Swap(listObj, emptyIndex, targetIndex);
                    }
                    break;
                case 1:
                    if (emptyRow < row - 1)
                    {
                        int targetIndex = emptyIndex + col;
                        Swap(listObj, emptyIndex, targetIndex);
                    }
                    break;
                case 2:
                    if (emptyCol > 0)
                    {
                        int targetIndex = emptyIndex - 1;
                        Swap(listObj, emptyIndex, targetIndex);
                    }
                    break;
                case 3:
                    if (emptyCol < col - 1)
                    {
                        int targetIndex = emptyIndex + 1;
                        Swap(listObj, emptyIndex, targetIndex);
                    }
                    break;
            }
        }
    }

    void Swap(List<int> listObj, int index1, int index2)
    {
        int temp = listObj[index1];
        listObj[index1] = listObj[index2];
        listObj[index2] = temp;
    }

    CeilItem findCeilItem(int rIdx,int cIdx)
    {
        foreach (KeyValuePair<int,CeilItem> kv in dataDict)
        {
            if(kv.Value.rIdx==rIdx  && kv.Value.cIdx == cIdx)
            {
                return kv.Value;
            }
        }
        return null;
    }

    Vector3 getCeilItemPos(int i,int j )
    {

        Vector3 ve = default;

        ve.x = 1 * j;
        ve.y = -1 * i;
        return ve;
    }

    bool checkCeilRight(int rIdx,int cIndx)
    {
        if(rIdx < 0 || rIdx >= row || cIndx < 0 || cIndx >= col)
        {
            return false;
        }

        return true;
    }

    bool findOneZeroCeil(int rIdx,int cIndex)
    {
        if (checkCeilRight(rIdx, cIndex)==false)
        {
            return false;
        }

        CeilItem ceil = findCeilItem(rIdx, cIndex);

        if(ceil != null)
        {
            return ceil.number == 0;
        }

        return false;
    }

   public (int, int) findFourZeroCel(int rIdx, int cIdx)
    {
        List<(int, int)> dirs = new List<(int, int)>(        )
        {
            (rIdx + 1, cIdx),
            (rIdx - 1, cIdx),
            (rIdx, cIdx + 1),
            (rIdx, cIdx - 1)
        };

        for (int i = 0; i < dirs.Count; i++)
        {
            (int, int) item = dirs[i];
            if (findOneZeroCeil(item.Item1, item.Item2))
            {
                return item;
            }
        }

        return (999,999);
    }

    public void CheckSwap(int rIdx, int cIdx,int clickCeilNumber)
    {
      (int, int) res =  findFourZeroCel(rIdx, cIdx);

        if(res.Item1 != 999)
        
        {
            StartSwap(clickCeilNumber, 0);
        }
        else
        {
            Debug.Log("Invalid Swap.");
        }
    }

    void StartSwap(int clickNumber, int zeroNumber)
    {
        CeilItem clickItem = dataDict[clickNumber];
        CeilItem zeroItem = dataDict[0];

        Vector3 clickPos = clickItem.transform.position;

        clickItem.transform.position = zeroItem.transform.position;

        zeroItem.transform.position = clickPos;

        SwapData(clickItem, zeroItem);
    }


    void SwapData(CeilItem clickItem, CeilItem zeroItem)
    {

        var clickRIdx = clickItem.rIdx;
        var clickCIdx = clickItem.cIdx;


        clickItem.updateRandCIdx(zeroItem.rIdx, zeroItem.cIdx);
        zeroItem.updateRandCIdx(clickRIdx, clickCIdx);

        IsWin();
    }



    bool IsWin()
    {
        bool res = false;

        int startNum = 1;
        
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                var ceil = findCeilItem(i, j);

                if (startNum == totalCeilCount)
                {
                    res = ceil.number == 0;
                    continue;
                }

           
                if (ceil.number != startNum)
                {
                    return res;
                }

                startNum += 1;
            }
        }

       
        if (res) {
            winText.text = "You win! The password is 1234.";
        } else {
           
        }

        return res;
    }

    void InitNumbers(List<int> numbers, int totalCeilCount)
    {
        int startNum = 1;

        while (startNum < totalCeilCount)
        {
            numbers.Add(startNum);
            startNum += 1;
        }
        numbers.Add(0);
    }
    int rval;
    public int GetRval()
    {
        return rval;
    }
  
    void InitMap()
    {
        Vector3 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        
        Vector3 mapStartPosition = new Vector3(screenCenter.x - ((col - 1) * 0.5f), screenCenter.y + ((row - 1) * 0.5f), 0f);
        mapStartPosition += new Vector3(mapCenterOffset.x, mapCenterOffset.y, 0f);

        row = 3;
        col = 3;

        totalCeilCount = row * col;

        numbers = new List<int>() { };
        InitNumbers(numbers, totalCeilCount);
        Shuffle(numbers);

        int numberIdx = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Vector3 pos = getCeilItemPos(i, j) + mapStartPosition; // Adjust position based on map start position
                var go = GameObject.Instantiate(CeilItem, pos, Quaternion.identity);
                var ceilItem = go.GetComponent<CeilItem>();
                int number = numbers[numberIdx];
                ceilItem.Init(number, i, j);
                dataDict.Add(number, ceilItem);
                numberIdx += 1;
            }
        }
    }

    private void Awake()
    {
        Inst = this;
    }

    void Start()
    {
        InitMap();
    }

    void Update()
    {
        
    }
}