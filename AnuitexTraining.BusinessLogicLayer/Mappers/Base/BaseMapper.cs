using System;
using System.Collections.Generic;

namespace AnuitexTraining.BusinessLogicLayer.Mappers.Base
{
    public abstract class BaseMapper<TFirst, TSecond>
    {
        public abstract TFirst Map(TSecond item);
        public abstract TSecond Map(TFirst item);

        public List<TFirst> Map(IEnumerable<TSecond> elements, Action<TFirst> callback = null)
        {
            var objectCollection = new List<TFirst>();
            if (elements != null)
                foreach (var element in elements)
                {
                    var newObject = Map(element);
                    if (newObject != null)
                    {
                        callback?.Invoke(newObject);
                        objectCollection.Add(newObject);
                    }
                }

            return objectCollection;
        }

        public List<TSecond> Map(IEnumerable<TFirst> elements, Action<TSecond> callback = null)
        {
            var objectCollection = new List<TSecond>();

            if (elements != null)
                foreach (var element in elements)
                {
                    var newObject = Map(element);
                    if (newObject != null)
                    {
                        callback?.Invoke(newObject);
                        objectCollection.Add(newObject);
                    }
                }

            return objectCollection;
        }
    }
}