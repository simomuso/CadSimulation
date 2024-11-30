﻿using System.Text.Json.Serialization;

namespace CadSimulation.Domain.Entities
{
    public class SerializableCircle : ISerializableShape
    {
        public SerializableCircle() { }

        [JsonPropertyName("Radius")]
        public int Radius { get; set; }
        public string Type => "Circle";

        void ISerializableShape.Accept(ISerializableShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}