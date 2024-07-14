using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _count;
    [SerializeField] private LocalDataProvider _localDataProvider;

    private void Start()
    {
        _count.text = _localDataProvider.gameProgresses.Money.ToString();
    }

    public void MoneyIncrease(int money)
    {
        var currentMoney = _localDataProvider.gameProgresses.Money;
        currentMoney += money;
        _localDataProvider.gameProgresses.Money = currentMoney;
        _localDataProvider.SavePlayerProgress();
        _count.text = currentMoney.ToString();
    }
    
}
