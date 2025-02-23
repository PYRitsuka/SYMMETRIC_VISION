using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.ResourceManagement.AsyncOperations;

#if UNITY_EDITOR
using GamePlay.Story;
using UnityEditor;
#endif
using UnityEngine.AddressableAssets;
using UnityEngine.Video;
using UnityEngine.Audio;

namespace Utils
{
     public class SVGraph<K,T> {
        private Dictionary<K,SVGraphNode<T>> nodes;
        public SVGraphNode<T> root {get; set;}

        public SVGraph()
        {
            nodes = new Dictionary<K, SVGraphNode<T>>();
        }
        public SVGraphNode<T> AddNode(K k, T v) {
            var node = new SVGraphNode<T>(v);
            if (!nodes.ContainsKey(k)){
                nodes[k] = node;
            }
            return nodes[k];
         }

         public SVGraphNode<T> GetNode(K k) {
            if (!nodes.ContainsKey(k)){
                return null;
            }
            return nodes[k];
         }
        public void AddEdge(K k1, K k2)
        {
            SVGraphNode<T> from;
            SVGraphNode<T> to;
            if ( (nodes.TryGetValue(k1,out from) && nodes.TryGetValue(k2,out to)) ) {
            from.AddChild(to);
            to.AddParent(from);
            Debug.Log($"Added Graph Edge {k1}---> {k2}");
            return;
            }
            Debug.LogError($"Invalid Graph Edge adding : {k1}---> {k2}");
            return;

        }
     }
    public class SVGraphNode<T> {
        public T data;
        public LinkedList< SVGraphNode<T>> children;
        public LinkedList< SVGraphNode<T>> parents;

        public SVGraphNode(T data)
        {
            this.data = data;
            children = new LinkedList<SVGraphNode<T>>();
            parents = new LinkedList<SVGraphNode<T>>();
        }

        public void AddChild(SVGraphNode<T> other) {
            children.AddLast(other);
        }
        public void AddParent(SVGraphNode<T> other) {
            parents.AddLast(other);
        }
    }

}