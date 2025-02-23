using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utils;
using Newtonsoft.Json.Converters;
using System.Linq;

using  GamePlay.StoryV2.Record.Factory;
namespace GamePlay.StoryV2.Record.Serializable
{
    class MyConverter :CustomCreationConverter<IDictionary<string, object>>
{
    public override IDictionary<string, object> Create(Type objectType)
    {
        return new Dictionary<string, object>();
    }

    public override bool CanConvert(Type objectType)
    {
        // Handle IDictionary<string, object> and objects that are of type List<object>
        return objectType == typeof(object) || objectType == typeof(List<object>) || base.CanConvert(objectType);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartObject || reader.TokenType == JsonToken.Null)
        {
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }

        if (reader.TokenType == JsonToken.StartArray)
        {
            return ReadArray(reader, serializer);
        }

        // If the next token is not an object or an array, fall back on the standard deserializer (strings, numbers etc.)
        return serializer.Deserialize(reader);
    }

    private object ReadArray(JsonReader reader, JsonSerializer serializer)
    {
        var list = new List<object>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.EndArray)
            {
                return list;
            }

            // For each element in the array, recursively deserialize
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    list.Add(base.ReadJson(reader, typeof(object), null, serializer));
                    break;
                case JsonToken.StartArray:
                    list.Add(ReadArray(reader, serializer));
                    break;
                default:
                    list.Add(serializer.Deserialize(reader));
                    break;
            }
        }

        throw new JsonSerializationException("Unexpected end of array.");
    }
}


    [System.Serializable]
    public class SerializableCommand
    {
        public string CommandType;
        public string Identifier;
        public SerializableDictionary<string, object> Parameters;

        // public Dictionary<string, object> GetParameters(){
        //     return Parameters != null ? Parameters: new Dictionary<string, object>();
        // }

        public static List<Base> DeserializeCommands(string json)
        {
            var wrapper = JsonConvert.DeserializeObject<IDictionary<string, object>>(
            json, new JsonConverter[] {new MyConverter()});
            // var wrapper = JsonConvert.DeserializeObject<SerializableCommandWrapper>(json);
            List<Base> commands = new List<Base>();
            foreach (var sCommand in (List<object>) wrapper["Commands"])
            {
                var sCommandDict = (Dictionary <string, object>) sCommand;
                Base command = CommandFactory.CreateCommand(sCommandDict); // Implement a factory pattern
                commands.Add(command);
            }
            return commands;
        }

        [System.Serializable]
        private class SerializableCommandWrapper
        {
            public List<SerializableCommand> Commands;
        }



    }




    [Serializable]
    public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<K> m_Keys = new List<K>();

        [SerializeField]
        private List<V> m_Values = new List<V>();

        public void OnBeforeSerialize()
        {
            m_Keys.Clear();
            m_Values.Clear();
            using Enumerator enumerator = GetEnumerator();
            while (enumerator.MoveNext())
            {
                KeyValuePair<K, V> current = enumerator.Current;
                m_Keys.Add(current.Key);
                m_Values.Add(current.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            Clear();
            for (int i = 0; i < m_Keys.Count; i++)
            {
                Add(m_Keys[i], m_Values[i]);
            }

            m_Keys.Clear();
            m_Values.Clear();
        }
    }

}