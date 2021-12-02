using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Dictionary : MonoBehaviour
{
    public DictionaryUtility dictionaryUtil;
    private readonly List<string> _wordList = new List<string>();
    private int _index;
    private static readonly Random Rng = new Random();

    private void Awake()
    {
        // initialize important values
        _index = 0;
        _wordList.AddRange(dictionaryUtil.GETWordList());
        // shuffle wordList
        Shuffle(_wordList);
    }

    private void Shuffle(List<string> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Rng.Next(n + 1);
            (_wordList[k], _wordList[n]) = (_wordList[n], _wordList[k]);
        }
    }

    public string GETNewWord()
    {
        string newWord = string.Empty;
        // check if wordList is empty or null
        if (_wordList == null || _wordList.Count == 0)
            return newWord;
        newWord = _wordList[_index];
        _index++;
        // check if wordList needs to be reset
        if (_wordList.Count <= _index)
        {
            _index = 0;
            Shuffle(_wordList);
        }
        return newWord;
    }
    
}
