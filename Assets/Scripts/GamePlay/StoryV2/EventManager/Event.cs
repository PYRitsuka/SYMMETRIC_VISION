using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Utils;
using System.Runtime.InteropServices;


namespace GamePlay.StoryV2.Event {


    public class EventManager
    {
        //private List<Action<EventData>> subscribers = new List<Action<EventData>>();

        private SortedList<Subscriber,int> subscribers;

        public EventManager()
        {
            subscribers = new();
        }

        public void Subscribe(Action<EventData> callback,int weight)
        {
            var subscriber = new Subscriber(weight,callback);
            subscribers.Add(subscriber,0);
            //subscribers = subscribers.OrderBy(s => s.Method.MetadataToken).ToList();  // Example sorting mechanism
        }

        public void SubscribeDefault(Action subscriber) {
            Action<EventData> action = (x ) =>{subscriber();};
            Subscribe(action,1000);
        }

        public void SubscribeStopPropagate(Action subscriber) {
            Action<EventData> action = (x ) =>{
                subscriber();
                x.StopPropagation = true;
            };
            Subscribe(action,1000);
        }
    
        public void DebugLog(string str = "") {
            var s = str + string.Join(",", subscribers.Select(n => n.Key.weight.ToString()).ToArray());
            Debug.Log($"Click Callback Priority {subscribers.Count}: { str}");
        }
        public void Trigger()
        {
            List<Subscriber> toRemove = new ();
            EventData data = new EventData();
            DebugLog();
            
            foreach (var kvp in subscribers)
            {
                data.KeepOnComplete = false;
                kvp.Key.callback(data);
                if (!data.KeepOnComplete)
                    toRemove.Add(kvp.Key);
                Debug.Log($"Click Callback {kvp.Key.callback} {data.StopPropagation} {kvp.Key.weight}");
                if (data.StopPropagation)
                    break;
            }
            foreach (var subscriber in toRemove){
                subscribers.Remove(subscriber);
            }
        }
    }

    public class EventData
    {
        public bool StopPropagation { get; set; }
        public bool KeepOnComplete{ get; set; }
    }
    public class Subscriber: IComparable<Subscriber> {
        public int weight;  
        long timestamp;

        public Action<EventData> callback;

        public Subscriber(int weight,Action<EventData> callback )
        {
            long epochTicks = new DateTime(1970, 1, 1).Ticks;
            long unixTime = ((DateTime.UtcNow.Ticks - epochTicks) / TimeSpan.TicksPerSecond);
            // TODO: This has 2038 problem lol, god save us from WWIII
            this.weight = weight;
            this.timestamp = unixTime;
            this.callback = callback;
        }
        public int CompareTo(Subscriber other) {
            var weight_order = weight.CompareTo(other.weight);
            if (weight_order != 0) return weight_order;
            var time_order =  - timestamp.CompareTo(other.timestamp);
            if (time_order == 0) time_order = 1; // hack
            return time_order;
        }
    }
}