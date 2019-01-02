﻿using System;
namespace Game2
{
    public interface Subject
    {
        void RegisterObserver(Observer observer);
        void RemoveObserver(Observer observer);
        void NotifyObservers();
    }
}
