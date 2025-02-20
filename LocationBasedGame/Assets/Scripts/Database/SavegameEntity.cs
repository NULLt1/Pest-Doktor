﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NULLt1
namespace DatabaseN
{
    public class SavegameEntity
    {
        public string id;
        public string name;
        public string level;
        public string experience;
        public string infection;
        public string alrauneAmount;
        public string tollkirscheAmount;
        public string wachholderAmount;
        public string fliegenpilzAmount;
        public string morchelAmount;
        public string kiefernschwammAmount;

        public SavegameEntity(string id, string name, string level,
            string experience, string infection, string alrauneAmount,
            string tollkirscheAmount, string wachholderAmount, string fliegenpilzAmount,
            string morchelAmount, string kiefernschwammAmount)
        {
            this.id = id;
            this.name = name;
            this.level = level;
            this.experience = experience;
            this.infection = infection;
            this.alrauneAmount = alrauneAmount;
            this.tollkirscheAmount = tollkirscheAmount;
            this.wachholderAmount = wachholderAmount;
            this.fliegenpilzAmount = fliegenpilzAmount;
            this.morchelAmount = morchelAmount;
            this.kiefernschwammAmount = kiefernschwammAmount;
        }
    }
}