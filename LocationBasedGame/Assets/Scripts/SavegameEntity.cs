using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataBank
{
    public class SavegameEntity
    {
        public string _id;
        public string _level;
        public string _experience;
        public string _infection;
        public string _alrauneAmount;
        public string _tollkirscheAmount;
        public string _wachholderAmount;
        public string _fliegenpilzAmount;
        public string _morchelAmount;
        public string _kiefernschwammAmount;
        public SavegameEntity(string id, string level,
            string experience, string infection, string alrauneAmount,
            string tollkirscheAmount, string wachholderAmount, string fliegenpilzAmount,
            string morchelAmount, string kiefernschwammAmount)
        {
            _id = id;
            _level = level;
            _experience = experience;
            _infection = infection;
            _alrauneAmount = alrauneAmount;
            _tollkirscheAmount = tollkirscheAmount;
            _wachholderAmount = wachholderAmount;
            _fliegenpilzAmount = fliegenpilzAmount;
            _morchelAmount = morchelAmount;
            _kiefernschwammAmount = kiefernschwammAmount;
        }
    }
}