﻿using System;
using System.Xml.Serialization;

namespace AX9.MetaTool.Models
{
    public class KcHandleTableSizeModel : ICloneable
    {
        public KcHandleTableSizeModel()
        {
            handleTableSize = 512;
        }


        [XmlElement("HandleTableSize")]
        public ushort HandleTableSize
        {
            get => handleTableSize;
            set
            {
                if (value >= 1024) throw new ArgumentException("HandleTableSize is invalid");
                handleTableSize = value;
            }
        }


        public const int FieldSize = 10;

        private ushort handleTableSize;

        private readonly KcFlagModel capability = new KcFlagModel { EntryNumber = 15u };


        public uint CalcFlag()
        {
            capability.FieldValue = HandleTableSize;
            return capability.Flag;
        }

        public object Clone()
        {
            return new KcHandleTableSizeModel
            {
                HandleTableSize = HandleTableSize
            };
        }
    }
}
