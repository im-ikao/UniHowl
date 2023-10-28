using System.Collections;
using System.Collections.Generic;
using Plugins.CREEXTEAM.UniHowl.Domain.ValueObject;
using UnityEngine;

public interface IAudioMap<TAudio> : IEntity
{
    public TAudio Get(string key);
    public void Add(TAudio audio);
    public void Remove(TAudio audio);
    public void Clear();
    public bool IsExist(TAudio audio);
    public bool IsExist(string key);
}
